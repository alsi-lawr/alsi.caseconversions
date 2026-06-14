<div align="center">

# ALSI.CaseConversions

[![NuGet Version](https://img.shields.io/nuget/v/ALSI.CaseConversions.svg?style=flat)](https://www.nuget.org/packages/ALSI.CaseConversions/)
[![Build Status](https://github.com/alsi-lawr/alsi.caseconversions/actions/workflows/deploy-nuget.yml/badge.svg)](https://github.com/alsi-lawr/ALSI.CaseConversions/actions)
[![Downloads](https://img.shields.io/nuget/dt/ALSI.CaseConversions.svg?logo=nuget&logoSize=auto)](https://www.nuget.org/packages/ALSI.CaseConversions)
[![codecov](https://codecov.io/gh/alsi-lawr/alsi.caseconversions/graph/badge.svg)](https://codecov.io/gh/alsi-lawr/alsi.caseconversions)

**Convert naming conventions without ceremony.**

Small, allocation-conscious .NET string case conversion for identifiers, keys, generated names, and other ASCII-oriented application text.

</div>

`ALSI.CaseConversions` turns identifier-like strings into the case your boundary needs: JSON property names, route keys, generated code symbols, file names, configuration keys, and similar application text.

> [!TIP]
> The public API is intentionally direct: use `SnakeCase.Convert(...)`, `KebabCase.Convert(...)`, `PascalCase.Convert(...)`, and the other target-case facades without aliases, services, or setup.

```csharp
using ALSI.CaseConversions;

string routeKey = KebabCase.Convert("CustomerAccountId");
string jsonName = SnakeCase.Convert("CustomerAccountId");
string typeName = PascalCase.Convert("customer_account_id");
```

## Why Use It

<table>
  <tr>
    <td><strong>Clear API</strong></td>
    <td>One static facade per target case, all using <code>Convert(...)</code>.</td>
  </tr>
  <tr>
    <td><strong>Flexible inputs</strong></td>
    <td>Handles camelCase, PascalCase, snake_case, kebab-case, dot.case, spaces, uppercase runs, and digits.</td>
  </tr>
  <tr>
    <td><strong>Low overhead</strong></td>
    <td>Uses stack-allocated buffers for short inputs and shared array pool buffers for longer inputs.</td>
  </tr>
  <tr>
    <td><strong>No setup</strong></td>
    <td>No services, options objects, extension registration, or converter aliases.</td>
  </tr>
</table>

## Install

```bash
dotnet add package ALSI.CaseConversions
```

Package Manager Console:

```powershell
Install-Package ALSI.CaseConversions
```

## Quick Start

```csharp
using ALSI.CaseConversions;

var jsonProperty = SnakeCase.Convert("CustomerAccountId");
// "customer_account_id"

var routeSegment = KebabCase.Convert("CustomerAccountId");
// "customer-account-id"

var generatedTypeName = PascalCase.Convert("customer_account_id");
// "CustomerAccountId"
```

> [!NOTE]
> Every converter follows the same naming pattern. Pick the target case first, then call `Convert`.

```csharp
SnakeCase.Convert("HelloWorld");      // "hello_world"
CamelCase.Convert("hello-world");     // "helloWorld"
PascalCase.Convert("hello world");    // "HelloWorld"
KebabCase.Convert("XMLRequest");      // "xml-request"
DotCase.Convert("File123Name");       // "file123.name"
MacroCase.Convert("helloWorld");      // "HELLO_WORLD"
SentenceCase.Convert("hello_world");  // "hello world"
```

## Supported Targets

| Target | API | Example |
| --- | --- | --- |
| `snake_case` | `SnakeCase.Convert(...)` | `"CustomerId"` -> `"customer_id"` |
| `camelCase` | `CamelCase.Convert(...)` | `"customer-id"` -> `"customerId"` |
| `PascalCase` | `PascalCase.Convert(...)` | `"customer_id"` -> `"CustomerId"` |
| `kebab-case` | `KebabCase.Convert(...)` | `"CustomerId"` -> `"customer-id"` |
| `dot.case` | `DotCase.Convert(...)` | `"CustomerId"` -> `"customer.id"` |
| `MACRO_CASE` | `MacroCase.Convert(...)` | `"CustomerId"` -> `"CUSTOMER_ID"` |
| `Sentence Case` | `SentenceCase.Convert(...)` | `"CustomerId"` -> `"Customer Id"` |

## Input Handling

Converters are designed for strings that already behave like identifiers or keys.

They handle:

- Existing separated text: `hello_world`, `hello-world`, `hello.world`, `hello world`
- PascalCase and camelCase inputs
- Runs of uppercase letters such as `XMLRequest`
- Digits inside names, for example `File123Name`
- Leading and trailing separators
- Empty input and null string input, which return `string.Empty`

For example:

```csharp
SnakeCase.Convert("PascalCaseInput");      // "pascal_case_input"
SnakeCase.Convert("camelCaseInput");       // "camel_case_input"
SnakeCase.Convert("Hello-World-Example");  // "hello_world_example"
SnakeCase.Convert("Hello.World.Example");  // "hello_world_example"
SnakeCase.Convert("File123Name");          // "file123_name"
```

## Notes and Limits

> [!IMPORTANT]
> This package is focused on ASCII identifier conversion. It is not intended to be a culture-aware natural-language casing engine.

- Inputs should be limited to characters in the `0x00` to `0xFF` range.
- ASCII letters and digits are retained.
- Other characters are treated as delimiters or skipped according to the converter's internal character table.
- Converters are static and configuration-free by design.

## Benchmarks

Public benchmark reports are checked into the repository for auditability.

> [!NOTE]
> Benchmarks measure the public converter methods directly. Inputs are selected outside the measured methods so the timings are focused on the package code under test.

See the latest checked-in report: [reports/2026-06-13](reports/2026-06-13).

## License

This project is licensed under the terms in [LICENCE](LICENCE).
