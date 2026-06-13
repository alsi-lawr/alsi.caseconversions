namespace ALSI.CaseConversions;

using System;

/// <summary>
/// For formatting strings to MACRO_CASE.
/// </summary>
public static class MacroCase
{
    /// <summary>
    /// Converts the specified string to MACRO_CASE.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>Macro case version of the string.</returns>
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<MacroCaseConverter>.ConvertCase(stringToConvert);
}
