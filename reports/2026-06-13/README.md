# Benchmark Report - 2026-06-13

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
- BenchmarkDotNet reported that it could not set high process priority in this run.
- Public source data: [benchmarkdotnet/results/ALSI.CaseConversions.Benchmarks.PublicConverterBenchmarks-report.csv](benchmarkdotnet/results/ALSI.CaseConversions.Benchmarks.PublicConverterBenchmarks-report.csv)

## Results

```

BenchmarkDotNet v0.15.8, Linux NixOS 26.11 (Zokor)
AMD Ryzen 7 5700X3D 3.23GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.300
  [Host]             : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3
  ShortRun-.NET 10.0 : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3

Job=ShortRun-.NET 10.0  Runtime=.NET 10.0  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```

| Method               | InputShape | Mean      | Error     | StdDev   | Gen0   | Allocated |
|--------------------- |----------- |----------:|----------:|---------:|-------:|----------:|
| **SnakeCase.Convert**    | **Pascal**     |  **44.11 ns** |  **0.771 ns** | **0.042 ns** | **0.0013** |      **64 B** |
| CamelCase.Convert    | Pascal     |  40.04 ns |  1.865 ns | 0.102 ns | 0.0011 |      56 B |
| PascalCase.Convert   | Pascal     |  41.02 ns |  2.350 ns | 0.129 ns | 0.0011 |      56 B |
| KebabCase.Convert    | Pascal     |  41.72 ns |  1.683 ns | 0.092 ns | 0.0013 |      64 B |
| DotCase.Convert      | Pascal     |  44.94 ns |  3.302 ns | 0.181 ns | 0.0013 |      64 B |
| MacroCase.Convert    | Pascal     |  45.64 ns |  2.980 ns | 0.163 ns | 0.0013 |      64 B |
| SentenceCase.Convert | Pascal     |  43.75 ns |  3.870 ns | 0.212 ns | 0.0013 |      64 B |
| **SnakeCase.Convert**    | **Camel**      |  **47.05 ns** | **27.406 ns** | **1.502 ns** | **0.0013** |      **64 B** |
| CamelCase.Convert    | Camel      |  44.69 ns |  5.685 ns | 0.312 ns | 0.0011 |      56 B |
| PascalCase.Convert   | Camel      |  39.68 ns | 15.856 ns | 0.869 ns | 0.0011 |      56 B |
| KebabCase.Convert    | Camel      |  42.34 ns | 11.949 ns | 0.655 ns | 0.0013 |      64 B |
| DotCase.Convert      | Camel      |  44.08 ns | 11.402 ns | 0.625 ns | 0.0013 |      64 B |
| MacroCase.Convert    | Camel      |  51.24 ns |  2.844 ns | 0.156 ns | 0.0013 |      64 B |
| SentenceCase.Convert | Camel      |  45.50 ns | 31.669 ns | 1.736 ns | 0.0013 |      64 B |
| **SnakeCase.Convert**    | **Acronym**    |  **40.78 ns** | **10.870 ns** | **0.596 ns** | **0.0011** |      **56 B** |
| CamelCase.Convert    | Acronym    |  39.59 ns | 11.546 ns | 0.633 ns | 0.0011 |      56 B |
| PascalCase.Convert   | Acronym    |  37.30 ns |  3.116 ns | 0.171 ns | 0.0011 |      56 B |
| KebabCase.Convert    | Acronym    |  39.44 ns |  4.413 ns | 0.242 ns | 0.0011 |      56 B |
| DotCase.Convert      | Acronym    |  41.21 ns |  3.762 ns | 0.206 ns | 0.0011 |      56 B |
| MacroCase.Convert    | Acronym    |  43.67 ns |  3.715 ns | 0.204 ns | 0.0011 |      56 B |
| SentenceCase.Convert | Acronym    |  38.07 ns |  2.576 ns | 0.141 ns | 0.0011 |      56 B |
| **SnakeCase.Convert**    | **Separators** |  **50.74 ns** |  **2.933 ns** | **0.161 ns** | **0.0013** |      **64 B** |
| CamelCase.Convert    | Separators |  44.09 ns |  8.032 ns | 0.440 ns | 0.0011 |      56 B |
| PascalCase.Convert   | Separators |  47.43 ns | 11.140 ns | 0.611 ns | 0.0011 |      56 B |
| KebabCase.Convert    | Separators |  48.97 ns |  7.074 ns | 0.388 ns | 0.0013 |      64 B |
| DotCase.Convert      | Separators |  50.80 ns |  0.089 ns | 0.005 ns | 0.0013 |      64 B |
| MacroCase.Convert    | Separators |  56.91 ns | 13.421 ns | 0.736 ns | 0.0013 |      64 B |
| SentenceCase.Convert | Separators |  50.15 ns |  6.786 ns | 0.372 ns | 0.0013 |      64 B |
| **SnakeCase.Convert**    | **Delimited**  |  **42.20 ns** |  **4.545 ns** | **0.249 ns** | **0.0013** |      **64 B** |
| CamelCase.Convert    | Delimited  |  43.92 ns |  6.369 ns | 0.349 ns | 0.0011 |      56 B |
| PascalCase.Convert   | Delimited  |  43.87 ns | 25.138 ns | 1.378 ns | 0.0011 |      56 B |
| KebabCase.Convert    | Delimited  |  47.44 ns |  2.262 ns | 0.124 ns | 0.0013 |      64 B |
| DotCase.Convert      | Delimited  |  47.55 ns | 24.216 ns | 1.327 ns | 0.0013 |      64 B |
| MacroCase.Convert    | Delimited  |  55.60 ns |  1.807 ns | 0.099 ns | 0.0013 |      64 B |
| SentenceCase.Convert | Delimited  |  45.42 ns | 39.397 ns | 2.159 ns | 0.0013 |      64 B |
| **SnakeCase.Convert**    | **Long**       | **294.57 ns** | **25.890 ns** | **1.419 ns** | **0.0067** |     **344 B** |
| CamelCase.Convert    | Long       | 306.73 ns | 16.612 ns | 0.911 ns | 0.0057 |     296 B |
| PascalCase.Convert   | Long       | 266.81 ns | 17.898 ns | 0.981 ns | 0.0057 |     296 B |
| KebabCase.Convert    | Long       | 276.54 ns | 67.416 ns | 3.695 ns | 0.0067 |     344 B |
| DotCase.Convert      | Long       | 297.91 ns | 54.178 ns | 2.970 ns | 0.0067 |     344 B |
| MacroCase.Convert    | Long       | 358.91 ns | 95.510 ns | 5.235 ns | 0.0067 |     344 B |
| SentenceCase.Convert | Long       | 299.03 ns | 19.461 ns | 1.067 ns | 0.0067 |     344 B |

## Comparative Results

> [!NOTE]
> These comparisons are limited to target cases with a direct `System.Text.Json.JsonNamingPolicy` counterpart. They do not cover Pascal, dot, or sentence case. Behaviors can differ on separator-heavy inputs, so treat this as an overlapping-policy comparison rather than a semantic-equivalence claim.

```

BenchmarkDotNet v0.15.8, Linux NixOS 26.11 (Zokor)
AMD Ryzen 7 5700X3D 3.23GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.300
  [Host]             : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3
  ShortRun-.NET 10.0 : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3

Job=ShortRun-.NET 10.0  Runtime=.NET 10.0  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```

| Method                   | InputShape | Mean        | Error      | StdDev    | Gen0   | Allocated |
|------------------------- |----------- |------------:|-----------:|----------:|-------:|----------:|
| **&#39;ALSI SnakeCase.Convert&#39;** | **Pascal**     |  **45.8995 ns** |  **9.3325 ns** | **0.5115 ns** | **0.0013** |      **64 B** |
| &#39;STJ SnakeCaseLower&#39;     | Pascal     |  56.2284 ns |  5.6377 ns | 0.3090 ns | 0.0012 |      64 B |
| &#39;ALSI CamelCase.Convert&#39; | Pascal     |  41.5470 ns |  7.3131 ns | 0.4009 ns | 0.0011 |      56 B |
| &#39;STJ CamelCase&#39;          | Pascal     |  14.7887 ns |  3.5152 ns | 0.1927 ns | 0.0011 |      56 B |
| &#39;ALSI KebabCase.Convert&#39; | Pascal     |  43.9234 ns |  3.1982 ns | 0.1753 ns | 0.0013 |      64 B |
| &#39;STJ KebabCaseLower&#39;     | Pascal     |  56.5295 ns |  1.3713 ns | 0.0752 ns | 0.0012 |      64 B |
| &#39;ALSI MacroCase.Convert&#39; | Pascal     |  49.9539 ns |  0.5657 ns | 0.0310 ns | 0.0013 |      64 B |
| &#39;STJ SnakeCaseUpper&#39;     | Pascal     |  61.5300 ns |  7.6452 ns | 0.4191 ns | 0.0012 |      64 B |
| **&#39;ALSI SnakeCase.Convert&#39;** | **Camel**      |  **41.2135 ns** |  **7.0165 ns** | **0.3846 ns** | **0.0013** |      **64 B** |
| &#39;STJ SnakeCaseLower&#39;     | Camel      |  53.2269 ns |  1.8407 ns | 0.1009 ns | 0.0013 |      64 B |
| &#39;ALSI CamelCase.Convert&#39; | Camel      |  44.3659 ns |  4.3796 ns | 0.2401 ns | 0.0011 |      56 B |
| &#39;STJ CamelCase&#39;          | Camel      |   0.6916 ns |  0.2164 ns | 0.0119 ns |      - |         - |
| &#39;ALSI KebabCase.Convert&#39; | Camel      |  44.7082 ns |  4.2503 ns | 0.2330 ns | 0.0013 |      64 B |
| &#39;STJ KebabCaseLower&#39;     | Camel      |  53.6741 ns |  8.7143 ns | 0.4777 ns | 0.0013 |      64 B |
| &#39;ALSI MacroCase.Convert&#39; | Camel      |  50.6307 ns |  9.9163 ns | 0.5435 ns | 0.0013 |      64 B |
| &#39;STJ SnakeCaseUpper&#39;     | Camel      |  59.2965 ns |  4.8976 ns | 0.2685 ns | 0.0012 |      64 B |
| **&#39;ALSI SnakeCase.Convert&#39;** | **Acronym**    |  **38.3229 ns** |  **2.0334 ns** | **0.1115 ns** | **0.0011** |      **56 B** |
| &#39;STJ SnakeCaseLower&#39;     | Acronym    |  65.5768 ns |  1.9742 ns | 0.1082 ns | 0.0011 |      56 B |
| &#39;ALSI CamelCase.Convert&#39; | Acronym    |  37.9630 ns |  8.7850 ns | 0.4815 ns | 0.0011 |      56 B |
| &#39;STJ CamelCase&#39;          | Acronym    |  18.7046 ns |  3.0478 ns | 0.1671 ns | 0.0011 |      56 B |
| &#39;ALSI KebabCase.Convert&#39; | Acronym    |  36.6394 ns |  5.3916 ns | 0.2955 ns | 0.0011 |      56 B |
| &#39;STJ KebabCaseLower&#39;     | Acronym    |  65.9210 ns |  9.1645 ns | 0.5023 ns | 0.0011 |      56 B |
| &#39;ALSI MacroCase.Convert&#39; | Acronym    |  41.4117 ns |  8.2944 ns | 0.4546 ns | 0.0011 |      56 B |
| &#39;STJ SnakeCaseUpper&#39;     | Acronym    |  62.6935 ns |  1.9881 ns | 0.1090 ns | 0.0011 |      56 B |
| **&#39;ALSI SnakeCase.Convert&#39;** | **Separators** |  **49.5798 ns** |  **4.1711 ns** | **0.2286 ns** | **0.0013** |      **64 B** |
| &#39;STJ SnakeCaseLower&#39;     | Separators |  56.1226 ns |  7.3732 ns | 0.4042 ns | 0.0013 |      64 B |
| &#39;ALSI CamelCase.Convert&#39; | Separators |  49.4465 ns |  2.9805 ns | 0.1634 ns | 0.0011 |      56 B |
| &#39;STJ CamelCase&#39;          | Separators |   0.7710 ns |  0.1415 ns | 0.0078 ns |      - |         - |
| &#39;ALSI KebabCase.Convert&#39; | Separators |  49.3891 ns |  2.5262 ns | 0.1385 ns | 0.0013 |      64 B |
| &#39;STJ KebabCaseLower&#39;     | Separators |  56.7306 ns |  3.8847 ns | 0.2129 ns | 0.0012 |      64 B |
| &#39;ALSI MacroCase.Convert&#39; | Separators |  54.4966 ns |  3.4088 ns | 0.1868 ns | 0.0013 |      64 B |
| &#39;STJ SnakeCaseUpper&#39;     | Separators |  69.4059 ns |  7.5528 ns | 0.4140 ns | 0.0012 |      64 B |
| **&#39;ALSI SnakeCase.Convert&#39;** | **Delimited**  |  **44.4964 ns** |  **1.9386 ns** | **0.1063 ns** | **0.0013** |      **64 B** |
| &#39;STJ SnakeCaseLower&#39;     | Delimited  |  48.3819 ns |  7.5814 ns | 0.4156 ns | 0.0013 |      64 B |
| &#39;ALSI CamelCase.Convert&#39; | Delimited  |  48.8227 ns |  3.9608 ns | 0.2171 ns | 0.0011 |      56 B |
| &#39;STJ CamelCase&#39;          | Delimited  |   0.9846 ns |  0.0952 ns | 0.0052 ns |      - |         - |
| &#39;ALSI KebabCase.Convert&#39; | Delimited  |  47.7894 ns |  1.7958 ns | 0.0984 ns | 0.0013 |      64 B |
| &#39;STJ KebabCaseLower&#39;     | Delimited  |  45.9791 ns |  2.5130 ns | 0.1377 ns | 0.0013 |      64 B |
| &#39;ALSI MacroCase.Convert&#39; | Delimited  |  53.9838 ns |  1.8100 ns | 0.0992 ns | 0.0013 |      64 B |
| &#39;STJ SnakeCaseUpper&#39;     | Delimited  |  60.7695 ns |  4.2475 ns | 0.2328 ns | 0.0012 |      64 B |
| **&#39;ALSI SnakeCase.Convert&#39;** | **Long**       | **290.3470 ns** | **24.0419 ns** | **1.3178 ns** | **0.0067** |     **344 B** |
| &#39;STJ SnakeCaseLower&#39;     | Long       | 344.6509 ns | 10.1083 ns | 0.5541 ns | 0.0067 |     344 B |
| &#39;ALSI CamelCase.Convert&#39; | Long       | 285.0158 ns | 77.3040 ns | 4.2373 ns | 0.0057 |     296 B |
| &#39;STJ CamelCase&#39;          | Long       |  22.7687 ns |  3.5262 ns | 0.1933 ns | 0.0059 |     296 B |
| &#39;ALSI KebabCase.Convert&#39; | Long       | 285.4479 ns |  6.6797 ns | 0.3661 ns | 0.0067 |     344 B |
| &#39;STJ KebabCaseLower&#39;     | Long       | 345.1435 ns | 13.2938 ns | 0.7287 ns | 0.0067 |     344 B |
| &#39;ALSI MacroCase.Convert&#39; | Long       | 352.7157 ns | 68.0278 ns | 3.7288 ns | 0.0067 |     344 B |
| &#39;STJ SnakeCaseUpper&#39;     | Long       | 428.3499 ns |  8.8042 ns | 0.4826 ns | 0.0067 |     344 B |

## Regenerate

```console
scripts/GenerateBenchmarkReport.cs
scripts/GenerateBenchmarkReport.cs --comparative
scripts/GenerateBenchmarkReport.cs --render-only 2026-06-13
```

