namespace ALSI.CaseConversions;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Converts identifier-like text to dot.case.
/// </summary>
public readonly struct DotCase : ICaseConversion
{
    /// <summary>
    /// Converts the specified string to dot.case.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>The dot.case conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(string stringToConvert) => Convert(stringToConvert.AsSpan());

    /// <summary>
    /// Converts the specified characters to dot.case.
    /// </summary>
    /// <param name="stringToConvert">The characters to convert.</param>
    /// <returns>The dot.case conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<DotCaseConverter>.ConvertCase(stringToConvert);
}
