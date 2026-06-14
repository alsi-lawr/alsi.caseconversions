namespace ALSI.CaseConversions;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Converts identifier-like text to PascalCase.
/// </summary>
public readonly struct PascalCase : ICaseConversion
{
    /// <summary>
    /// Converts the specified string to PascalCase.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>The PascalCase conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(string stringToConvert) => Convert(stringToConvert.AsSpan());

    /// <summary>
    /// Converts the specified characters to PascalCase.
    /// </summary>
    /// <param name="stringToConvert">The characters to convert.</param>
    /// <returns>The PascalCase conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<PascalCaseConverter>.ConvertCase(stringToConvert);
}
