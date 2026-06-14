#!/usr/bin/env -S dotnet --
#:property TargetFramework=net10.0
#:property PublishAot=false

using System.Diagnostics;
using System.Globalization;
using System.Text;

const string BenchmarkProject = "tests/benchmark/ALSI.CaseConversions.Benchmarks.csproj";
const string PublicBenchmark = "ALSI.CaseConversions.Benchmarks.PublicConverterBenchmarks";
const string ComparativeBenchmark =
    "ALSI.CaseConversions.Benchmarks.ComparativeConverterBenchmarks";

bool renderOnly = args.Contains("--render-only");
bool comparative = args.Contains("--comparative");
string date =
    args.FirstOrDefault(argument => !argument.StartsWith("--", StringComparison.Ordinal))
    ?? DateTime.UtcNow.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

string root = FindRoot(Environment.CurrentDirectory);
string reportDirectory = Path.Combine(root, "reports", date);
string artifactsDirectory = Path.Combine(reportDirectory, "benchmarkdotnet");
string resultsDirectory = Path.Combine(artifactsDirectory, "results");

Directory.CreateDirectory(artifactsDirectory);

if (args.Any(argument => argument is "--help" or "-h"))
{
    Console.WriteLine(
        """
        Usage:
          scripts/GenerateBenchmarkReport.cs [--comparative] [--render-only] [yyyy-mm-dd]

        By default this runs the public benchmark matrix and writes reports/<date>/README.md.
        Add --comparative to include the optional System.Text.Json comparison benchmark.
        Add --render-only to reuse existing BenchmarkDotNet Markdown output.
        """
    );
    return;
}

if (!renderOnly)
{
    RunBenchmark(root, artifactsDirectory, comparative);
}

string report = Report(date, artifactsDirectory, resultsDirectory, comparative);
string reportPath = Path.Combine(reportDirectory, "README.md");

File.WriteAllText(reportPath, report, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
Console.WriteLine($"Rendered {Path.GetRelativePath(root, reportPath)}");

static string FindRoot(string start)
{
    for (DirectoryInfo? directory = new(start); directory is not null; directory = directory.Parent)
    {
        if (Directory.Exists(Path.Combine(directory.FullName, ".git")))
        {
            return directory.FullName;
        }
    }

    throw new InvalidOperationException("Could not find repository root.");
}

static void RunBenchmark(string root, string artifactsDirectory, bool comparative)
{
    ProcessStartInfo startInfo = new()
    {
        FileName = "dotnet",
        WorkingDirectory = root,
        RedirectStandardOutput = false,
        RedirectStandardError = false,
    };

    foreach (
        string argument in new[]
        {
            "run",
            "-c",
            "Release",
            "-f",
            "net10.0",
            "--no-restore",
            "--project",
            Path.Combine(root, BenchmarkProject),
            "--",
            "--artifacts",
            artifactsDirectory,
            "--filter",
            comparative ? "*ConverterBenchmarks*" : "*PublicConverterBenchmarks*",
        }
    )
    {
        startInfo.ArgumentList.Add(argument);
    }

    using Process process =
        Process.Start(startInfo)
        ?? throw new InvalidOperationException("Failed to start BenchmarkDotNet.");

    process.WaitForExit();

    if (process.ExitCode != 0)
    {
        Environment.Exit(process.ExitCode);
    }
}

static string Report(
    string date,
    string artifactsDirectory,
    string resultsDirectory,
    bool comparative
)
{
    string publicReport = ReadBenchmarkMarkdown(resultsDirectory, PublicBenchmark);
    string comparativeReport = comparative
        ? $"""

            ## Comparative Results

            > [!NOTE]
            > These comparisons are limited to target cases with a direct `System.Text.Json.JsonNamingPolicy` counterpart. They do not cover Pascal, dot, or sentence case. Behaviors can differ on separator-heavy inputs, so treat this as an overlapping-policy comparison rather than a semantic-equivalence claim.

            {ReadBenchmarkMarkdown(resultsDirectory, ComparativeBenchmark)}
            """
        : string.Empty;

    return $"""
        # Benchmark Report - {date}

        > [!IMPORTANT]
        > This report was assembled with AI assistance from BenchmarkDotNet output. The checked-in BenchmarkDotNet artifacts are the source data, and this script renders the Markdown report for audit and regeneration.

        ## Scope

        These benchmarks cover representative identifier-like inputs. Benchmark setup selects the input; measured methods call only the converter or comparison API under test.

        The benchmark suite uses `ShortRunJob` so it is practical to rerun during package maintenance. That makes it useful for consumer visibility and regression scanning, but it is not a substitute for a long isolated performance lab run.

        ## Input Matrix

        | Label | Input | Why it is included |
        | --- | --- | --- |
        | Pascal | `CustomerAccountId` | Common .NET property/type-style identifier. |
        | Camel | `customerAccountId` | Common JSON and JavaScript-style identifier. |
        | Acronym | `XMLHttpRequest` | Uppercase run followed by normal words. |
        | Separators | ` Customer.Account-Id ` | Mixed separators and surrounding whitespace. |
        | Delimited | `customer_account_id` | Already-delimited identifier input. |
        | Long | `CustomerAccountId` repeated 8 times | Longer identifier that exercises the larger-buffer path. |

        ## Run Notes

        - Runtime/job: .NET 10 `ShortRunJob` with BenchmarkDotNet.
        - Error column: BenchmarkDotNet half-width of the 99.9% confidence interval.
        - {(
            HighPriorityWarning(artifactsDirectory)
                ? "BenchmarkDotNet reported that it could not set high process priority in this run."
                : "No high-priority warning was detected in the BenchmarkDotNet log."
        )}
        - Public source data: [benchmarkdotnet/results/{PublicBenchmark}-report.csv](benchmarkdotnet/results/{PublicBenchmark}-report.csv)

        ## Results

        {publicReport}{comparativeReport}

        ## Regenerate

        ```console
        scripts/GenerateBenchmarkReport.cs
        scripts/GenerateBenchmarkReport.cs --comparative
        scripts/GenerateBenchmarkReport.cs --render-only {date}
        ```
        """;
}

static string ReadBenchmarkMarkdown(string resultsDirectory, string benchmarkName)
{
    string path = Path.Combine(resultsDirectory, $"{benchmarkName}-report-github.md");

    if (!File.Exists(path))
    {
        throw new FileNotFoundException("BenchmarkDotNet Markdown report was not found.", path);
    }

    return File.ReadAllText(path, Encoding.UTF8).Trim();
}

static bool HighPriorityWarning(string artifactsDirectory) =>
    Directory
        .EnumerateFiles(artifactsDirectory, "*.log", SearchOption.TopDirectoryOnly)
        .SelectMany(File.ReadLines)
        .Any(line => line.Contains("Failed to set up high priority", StringComparison.Ordinal));
