namespace ALSI.CaseConversions;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Converts identifier-like text to kebab-case.
/// </summary>
public readonly struct KebabCase : ICaseConversion
{
    /// <summary>
    /// Converts the specified string to kebab-case.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>The kebab-case conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(string stringToConvert) => Convert(stringToConvert.AsSpan());

    /// <summary>
    /// Converts the specified characters to kebab-case.
    /// </summary>
    /// <param name="stringToConvert">The characters to convert.</param>
    /// <returns>The kebab-case conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<KebabCaseConverter>.ConvertCase(stringToConvert);
}
