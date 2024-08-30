using System.Globalization;
using System.Text.RegularExpressions;
using ALSI.CaseConversions;
using BenchmarkDotNet.Attributes;

namespace ALSI.CaseConversions.IntegrationTests;

//[MemoryDiagnoser(true)]
public class SnakeCaseFormatterTests
{
    // [Benchmark]
    // public string ALSI_CaseConversions_SnakeConversion_RentedBuffer()
    // {
    //     var input = string.Concat(Enumerable.Repeat("HelloWorldExample", 16));

    //     return SnakeCase.Converter.ToSnakeCase(input);
    // }

    // [Benchmark]
    // public string System_Text_Json_SnakeConversion_RentedBuffer()
    // {
    //     var input = string.Concat(Enumerable.Repeat("HelloWorldExample", 16));

    //     return System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(input);
    // }

    [Benchmark]
    public string ALSI_CaseConversions_SnakeConversion()
    {
        var result = SnakeCase.Converter.Convert("Hello");

        result += SnakeCase.Converter.Convert("HelloWorld");
        result += SnakeCase.Converter.Convert(string.Empty);
        result += SnakeCase.Converter.Convert(null);
        result += SnakeCase.Converter.Convert("A");
        result += SnakeCase.Converter.Convert("AA");
        result += SnakeCase.Converter.Convert("camelCaseInput");
        result += SnakeCase.Converter.Convert("PascalCaseInput");
        result += SnakeCase.Converter.Convert("HELLO_WORLD");
        result += SnakeCase.Converter.Convert("File123Name");
        result += SnakeCase.Converter.Convert("Hello@World!");
        result += SnakeCase.Converter.Convert("Hello World");
        result += SnakeCase.Converter.Convert("  Hello World  ");
        result += SnakeCase.Converter.Convert("HelloWorldExample");
        result += SnakeCase.Converter.Convert("hello_world_example");
        result += SnakeCase.Converter.Convert("Hello-World-Example");
        result += SnakeCase.Converter.Convert("Hello.World.Example");
        result += SnakeCase.Converter.Convert(" \t\r\n");
        result += SnakeCase.Converter.Convert("XMLRequest");
        result += SnakeCase.Converter.Convert("_Hello.World.Example");
        result += SnakeCase.Converter.Convert("Hello.World.Example_");
        result += SnakeCase.Converter.Convert("HelloWorldExamplE");
        return result;
    }

    [Benchmark]
    public string System_Text_Json_SnakeConversion()
    {
        var result = System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("Hello");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("HelloWorld");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(string.Empty);
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(null ?? string.Empty);
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("A");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("AA");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("camelCaseInput");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("PascalCaseInput");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("HELLO_WORLD");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("File123Name");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("Hello@World!");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("Hello World");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("  Hello World  ");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("HelloWorldExample");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("hello_world_example");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("Hello-World-Example");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("Hello.World.Example");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(" \t\r\n");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("XMLRequest");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("_Hello.World.Example");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("Hello.World.Example_");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("HelloWorldExamplE");
        return result;
    }
}
