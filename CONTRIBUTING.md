# Contributing to ALSI.CaseConversions

Thanks for taking the time to improve `ALSI.CaseConversions`.

This project is a small NuGet package with a narrow public surface: fast, static case conversion for ASCII-oriented identifier-like strings. Keep contributions focused on that purpose.

## Local Setup

Clone the repository and run the test suite:

```bash
git clone https://github.com/alsi-lawr/alsi.caseconversions.git
cd alsi.caseconversions
dotnet test
```

The solution targets `net8.0` and `net10.0`.

## Project Shape

- Public APIs live in the `ALSI.CaseConversions` namespace.
- Each target case exposes a root facade, for example `SnakeCase.Convert(...)`, `KebabCase.Convert(...)`, and `PascalCase.Convert(...)`.
- The shared conversion implementation lives behind `ConversionEngine<TConverter>`.
- Case-specific behavior is implemented by internal converter structs such as `SnakeCaseConverter` and `PascalCaseConverter`.
- Tests live under `tests/unit` and use xUnit with Shouldly.

> [!TIP]
> If you add a new target case, follow the existing folder shape: public facade plus internal converter struct, with matching unit tests.

## Development Workflow

1. Create a branch from `master`.
2. Make the smallest coherent change for the issue or feature.
3. Add or update tests when behavior changes.
4. Run the relevant checks locally.
5. Open a pull request back to `master`.

Useful commands:

```bash
dotnet build
dotnet test
```

## Code Style

The repository uses StyleCop analyzers during builds. Keep code consistent with the surrounding files:

- Prefer existing patterns over new abstractions.
- Keep public API additions deliberate and documented.
- Keep converter logic allocation-conscious.
- Avoid unrelated formatting churn.

If you use a formatter locally, review the diff and keep it scoped to the files you intentionally changed.

## Testing Expectations

For behavior changes, add tests that cover:

- The direct public facade call, for example `SnakeCase.Convert(...)`.
- Empty and null string input where relevant.
- Existing separated input such as `_`, `-`, `.`, and whitespace.
- PascalCase, camelCase, uppercase runs, and digits when they matter to the change.

Run:

```bash
dotnet test
```

## Performance Expectations

Performance is part of this package's value. Changes to the conversion engine or character handling should preserve the low-allocation design:

- Use `Span<T>`, `ReadOnlySpan<T>`, `stackalloc`, and pooled buffers where the existing code already does.
- Avoid adding allocations on hot paths without a clear reason.
- Use the benchmark project under `tests/benchmark` when changing conversion internals or making performance claims.

To run the public benchmark matrix and render the dated consumer-facing report:

```console
scripts/GenerateBenchmarkReport.cs
```

To include the optional `System.Text.Json` comparison suite:

```console
scripts/GenerateBenchmarkReport.cs --comparative
```

To regenerate the Markdown report from existing BenchmarkDotNet CSV output without rerunning benchmarks:

```console
scripts/GenerateBenchmarkReport.cs --render-only 2026-06-13
```

> [!IMPORTANT]
> Do not include broad performance claims in documentation unless they are backed by current benchmark output.

## Pull Requests

Please include:

- What changed and why.
- Any public API or behavior change.
- What you ran to verify it.
- Any known tradeoffs or follow-up work.

GitHub Actions run unit tests and coverage reporting for pull requests and pushes to `master`.
