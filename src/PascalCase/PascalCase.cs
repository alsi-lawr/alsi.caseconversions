namespace ALSI.CaseConversions;

using System;

/// <summary>
/// For formatting strings to PascalCase.
/// </summary>
public static class PascalCase
{
    /// <summary>
    /// Converts the specified string to PascalCase.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>Pascal case version of the string.</returns>
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<PascalCaseConverter>.ConvertCase(stringToConvert);
}
