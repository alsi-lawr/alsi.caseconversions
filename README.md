# ALSI.CaseConversions

[![NuGet Version](https://img.shields.io/nuget/v/ALSI.CaseConversions.svg?style=flat)](https://www.nuget.org/packages/ALSI.CaseConversions/)
[![Build Status](https://github.com/alsi-lawr/alsi.caseconversions/actions/workflows/deploy-nuget.yml/badge.svg)](https://github.com/alsi-lawr/ALSI.CaseConversions/actions)
[![Downloads](https://img.shields.io/nuget/dt/ALSI.CaseConversions.svg?logo=nuget&logoSize=auto)](https://www.nuget.org/packages/ALSI.CaseConversions)
[![codecov](https://codecov.io/gh/alsi-lawr/alsi.caseconversions/graph/badge.svg)](https://codecov.io/gh/alsi-lawr/alsi.caseconversions)

**ALSI.CaseConversions** is a .NET library that converts various string formats into other cases. It provides robust handling of different casing conventions, separators, and special characters, making it an ideal utility for consistent string formatting in your applications.

## Supported Case Conversions

- **PascalCase**
- **snake_case**
- **camelCase**
- **kebab-case**
- **dot.case**
- **MACRO_CASE**

## Getting Started

### Installation

Install the NuGet package using the .NET CLI:

```bash
dotnet add package ALSI.CaseConversions
```

Or via the NuGet Package Manager:

```bash
Install-Package ALSI.CaseConversions
```

### Usage

#### Basic Example

```csharp
using ALSI.CaseConversions;

string result = SnakeCase.Converter.Convert("HelloWorld");
// result: "hello_world"
```

#### Handling Various String Formats

The converters can handle can handle different types of input formats, using `snake_case` as an example:

```csharp
// PascalCase to snake_case
var pascalResult = SnakeCase.Converter.Convert("PascalCaseInput");
// pascalResult: "pascal_case_input"

// camelCase to snake_case
var camelResult = SnakeCase.Converter.Convert("camelCaseInput");
// camelResult: "camel_case_input"

// Hyphen-separated words
var hyphenResult = SnakeCase.Converter.Convert("Hello-World-Example");
// hyphenResult: "hello_world_example"

// Dot-separated words
var dotResult = SnakeCase.Converter.Convert("Hello.World.Example");
// dotResult: "hello_world_example"

// Mixed case with numbers
var mixedResult = SnakeCase.Converter.Convert("File123Name");
// mixedResult: "file123_name"
```

### Supported Conversions

- **PascalCase**: `"PascalCaseInput"` → `"pascal_case_input"`
- **camelCase**: `"camelCaseInput"` → `"camel_case_input"`
- **Hyphenated Words**: `"Hello-World-Example"` → `"hello_world_example"`
- **Dot-Separated Words**: `"Hello.World.Example"` → `"hello_world_example"`
- **Whitespace-Separated Words**: `"Hello World"` → `"hello_world"`
- **Mixed-Case with Numbers**: `"File123Name"` → `"file123_name"`
- **Special Characters**: `"Hello@world!"` → `"helloworld"`
- **Consecutive Uppercase Letters**: `"XMLRequest"` →`"xml_request"`.

### Constraints

The conversion is limited by the following:

- **Empty Strings**: Returns an empty string.
- **Null Input**: Returns an empty string.
- **Fast for small inputs**: For inputs <= 128 characters, this is extremely fast, outperforming `System.Text.Json`. Beyond that, shared array buffers are used to attempt to retain performance improvements.
- **ASCII-only**: Converting to snake case is an extended ASCII-only operation, limited to character hex codes 0x00 -> 0xFF.

## Contributing

We welcome contributions! Feel free to open an issue or submit a pull request on GitHub.

### Building Locally

Clone the repository:

```bash
git clone https://github.com/alsi-lawr/alsi.caseconversions.git
cd ALSI.CaseConversions
```

Build the project:

```bash
dotnet build
```

Run tests:

```bash
dotnet test
```
