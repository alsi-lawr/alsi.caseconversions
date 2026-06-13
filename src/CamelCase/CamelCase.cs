namespace ALSI.CaseConversions;

using System;

/// <summary>
/// For formatting strings to camelCase.
/// </summary>
public static class CamelCase
{
    /// <summary>
    /// Converts the specified string to camelCase.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>Camel case version of the string.</returns>
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<CamelCaseConverter>.ConvertCase(stringToConvert);
}
