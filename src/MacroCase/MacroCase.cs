namespace ALSI.CaseConversions;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Converts identifier-like text to MACRO_CASE.
/// </summary>
public readonly struct MacroCase : ICaseConversion
{
    /// <summary>
    /// Converts the specified string to MACRO_CASE.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>The MACRO_CASE conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(string stringToConvert) => Convert(stringToConvert.AsSpan());

    /// <summary>
    /// Converts the specified characters to MACRO_CASE.
    /// </summary>
    /// <param name="stringToConvert">The characters to convert.</param>
    /// <returns>The MACRO_CASE conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<MacroCaseConverter>.ConvertCase(stringToConvert);
}
