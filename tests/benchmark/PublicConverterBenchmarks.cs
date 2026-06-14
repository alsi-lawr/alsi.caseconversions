using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ALSI.CaseConversions.Benchmarks;

[MemoryDiagnoser(true)]
[ShortRunJob(RuntimeMoniker.Net10_0)]
public class PublicConverterBenchmarks
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

    [Benchmark(Description = "SnakeCase.Convert")]
    public string ToSnakeCase() => SnakeCase.Convert(input);

    [Benchmark(Description = "CamelCase.Convert")]
    public string ToCamelCase() => CamelCase.Convert(input);

    [Benchmark(Description = "PascalCase.Convert")]
    public string ToPascalCase() => PascalCase.Convert(input);

    [Benchmark(Description = "KebabCase.Convert")]
    public string ToKebabCase() => KebabCase.Convert(input);

    [Benchmark(Description = "DotCase.Convert")]
    public string ToDotCase() => DotCase.Convert(input);

    [Benchmark(Description = "MacroCase.Convert")]
    public string ToMacroCase() => MacroCase.Convert(input);

    [Benchmark(Description = "SentenceCase.Convert")]
    public string ToSentenceCase() => SentenceCase.Convert(input);
}

public enum InputShape
{
    Pascal,
    Camel,
    Acronym,
    Separators,
    Delimited,
    Long,
}
