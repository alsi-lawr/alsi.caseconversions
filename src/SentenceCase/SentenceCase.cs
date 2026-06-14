namespace ALSI.CaseConversions;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Converts identifier-like text to Sentence Case.
/// </summary>
public readonly struct SentenceCase : ICaseConversion
{
    /// <summary>
    /// Converts the specified string to Sentence Case.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>The Sentence Case conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(string stringToConvert) => Convert(stringToConvert.AsSpan());

    /// <summary>
    /// Converts the specified characters to Sentence Case.
    /// </summary>
    /// <param name="stringToConvert">The characters to convert.</param>
    /// <returns>The Sentence Case conversion.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        ConversionEngine<SentenceCaseConverter>.ConvertCase(stringToConvert);
}
