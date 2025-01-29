namespace ALSI.CaseConversions.SentenceCase;

using System;

/// <summary>
/// For formatting strings to Sentence Case.
/// </summary>
public static class Converter
{
    /// <summary>
    /// Converts the specified string to Sentence Case.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>Sentence case version of the string.</returns>
    public static string Convert(ReadOnlySpan<char> stringToConvert) =>
        Converter<SentenceCaseConverter>.ConvertCase(stringToConvert);
}
