namespace ALSI.CaseConversions;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Converts identifier-like text to camelCase.
/// </summary>
public readonly struct CamelCase : ICaseConversion
{
    /// <summary>
    /// Converts the specified string to camelCase.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>The camelCase conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(string stringToConvert) => Convert(stringToConvert.AsSpan());

    /// <summary>
    /// Converts the specified characters to camelCase.
    /// </summary>
    /// <param name="stringToConvert">The characters to convert.</param>
    /// <returns>The camelCase conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<CamelCaseConverter>.ConvertCase(stringToConvert);
}
