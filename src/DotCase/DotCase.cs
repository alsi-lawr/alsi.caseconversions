namespace ALSI.CaseConversions;

using System;

/// <summary>
/// For formatting strings to dot.case.
/// </summary>
public static class DotCase
{
    /// <summary>
    /// Converts the specified string to dot.case.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>Dot case version of the string.</returns>
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<DotCaseConverter>.ConvertCase(stringToConvert);
}
