using BenchmarkDotNet.Attributes;

namespace ALSI.CaseConversions.IntegrationTests;

[MemoryDiagnoser(true)]
public class SnakeCaseFormatterTests
{
    [Benchmark]
    public string ALSI_CaseConversions_SnakeConversion_RentedBuffer()
    {
        var input = string.Concat(Enumerable.Repeat("HelloWorldExample", 16));

        return SnakeCase.Convert(input);
    }

    [Benchmark]
    public string System_Text_Json_SnakeConversion_RentedBuffer()
    {
        var input = string.Concat(Enumerable.Repeat("HelloWorldExample", 16));

        return System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(input);
    }

    [Benchmark]
    public string ALSI_CaseConversions_SnakeConversion()
    {
        var result = SnakeCase.Convert("Hello");

        result += SnakeCase.Convert("HelloWorld");
        result += SnakeCase.Convert(string.Empty);
        result += SnakeCase.Convert(null);
        result += SnakeCase.Convert("A");
        result += SnakeCase.Convert("AA");
        result += SnakeCase.Convert("camelCaseInput");
        result += SnakeCase.Convert("PascalCaseInput");
        result += SnakeCase.Convert("HELLO_WORLD");
        result += SnakeCase.Convert("File123Name");
        result += SnakeCase.Convert("Hello@World!");
        result += SnakeCase.Convert("Hello World");
        result += SnakeCase.Convert("  Hello World  ");
        result += SnakeCase.Convert("HelloWorldExample");
        result += SnakeCase.Convert("hello_world_example");
        result += SnakeCase.Convert("Hello-World-Example");
        result += SnakeCase.Convert("Hello.World.Example");
        result += SnakeCase.Convert(" \t\r\n");
        result += SnakeCase.Convert("XMLRequest");
        result += SnakeCase.Convert("_Hello.World.Example");
        result += SnakeCase.Convert("Hello.World.Example_");
        result += SnakeCase.Convert("HelloWorldExamplE");
        return result;
    }

    [Benchmark]
    public string System_Text_Json_SnakeConversion()
    {
        var result = System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("Hello");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("HelloWorld");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(string.Empty);
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(string.Empty);
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
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(
            "hello_world_example"
        );
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(
            "Hello-World-Example"
        );
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(
            "Hello.World.Example"
        );
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(" \t\r\n");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("XMLRequest");
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(
            "_Hello.World.Example"
        );
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(
            "Hello.World.Example_"
        );
        result += System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName("HelloWorldExamplE");
        return result;
    }
}
