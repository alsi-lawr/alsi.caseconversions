namespace ALSI.CaseConversions.SnakeCase;

using System;

/// <summary>
/// For formatting strings to snake_case.
/// </summary>
public static class Converter
{
    /// <summary>
    /// Converts the specified string to snake_case.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>Snake case version of the string.</returns>
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        Converter<SnakeCaseConverter>.ConvertCase(stringToConvert);
}
