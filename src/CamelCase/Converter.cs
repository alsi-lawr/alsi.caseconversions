namespace ALSI.CaseConversions.CamelCase;

using System;

/// <summary>
/// For formatting strings to camelCase.
/// </summary>
public static class Converter
{
    /// <summary>
    /// Converts the specified string to camelCase.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>Camel case version of the string.</returns>
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        Converter<CamelCaseConverter>.ConvertCase(stringToConvert);
}
