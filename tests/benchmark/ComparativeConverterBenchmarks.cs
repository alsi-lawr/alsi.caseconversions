using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ALSI.CaseConversions.Benchmarks;

[MemoryDiagnoser(true)]
[ShortRunJob(RuntimeMoniker.Net10_0)]
public class ComparativeConverterBenchmarks
{
    private const string LongIdentifier =
        "CustomerAccountIdCustomerAccountIdCustomerAccountIdCustomerAccountId"
        + "CustomerAccountIdCustomerAccountIdCustomerAccountIdCustomerAccountId";

    private string input = string.Empty;

    [Params(
        InputShape.Pascal,
        InputShape.Camel,
        InputShape.Acronym,
        InputShape.Separators,
        InputShape.Delimited,
        InputShape.Long
    )]
    public InputShape InputShape { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        input = InputShape switch
        {
            InputShape.Pascal => "CustomerAccountId",
            InputShape.Camel => "customerAccountId",
            InputShape.Acronym => "XMLHttpRequest",
            InputShape.Separators => " Customer.Account-Id ",
            InputShape.Delimited => "customer_account_id",
            InputShape.Long => LongIdentifier,
            _ => throw new InvalidOperationException($"Unknown input shape: {InputShape}"),
        };
    }

    [Benchmark(Description = "ALSI SnakeCase.Convert")]
    public string AlsiSnakeCase() => SnakeCase.Convert(input);

    [Benchmark(Description = "STJ SnakeCaseLower")]
    public string SystemTextJsonSnakeCase() =>
        System.Text.Json.JsonNamingPolicy.SnakeCaseLower.ConvertName(input);

    [Benchmark(Description = "ALSI CamelCase.Convert")]
    public string AlsiCamelCase() => CamelCase.Convert(input);

    [Benchmark(Description = "STJ CamelCase")]
    public string SystemTextJsonCamelCase() =>
        System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(input);

    [Benchmark(Description = "ALSI KebabCase.Convert")]
    public string AlsiKebabCase() => KebabCase.Convert(input);

    [Benchmark(Description = "STJ KebabCaseLower")]
    public string SystemTextJsonKebabCase() =>
        System.Text.Json.JsonNamingPolicy.KebabCaseLower.ConvertName(input);

    [Benchmark(Description = "ALSI MacroCase.Convert")]
    public string AlsiMacroCase() => MacroCase.Convert(input);

    [Benchmark(Description = "STJ SnakeCaseUpper")]
    public string SystemTextJsonMacroCase() =>
        System.Text.Json.JsonNamingPolicy.SnakeCaseUpper.ConvertName(input);
}
