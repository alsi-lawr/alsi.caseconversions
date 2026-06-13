namespace ALSI.CaseConversions;

using System;

/// <summary>
/// For formatting strings to kebab-case.
/// </summary>
public static class KebabCase
{
    /// <summary>
    /// Converts the specified string to kebab-case.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>Kebab case version of the string.</returns>
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<KebabCaseConverter>.ConvertCase(stringToConvert);
}
