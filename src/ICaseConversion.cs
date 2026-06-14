namespace ALSI.CaseConversions;

using System;

/// <summary>
/// Defines the public conversion methods exposed by a target case facade.
/// </summary>
public interface ICaseConversion
{
    /// <summary>
    /// Converts the specified string to the target case.
    /// </summary>
    /// <param name="stringToConvert">The string to convert.</param>
    /// <returns>The converted string.</returns>
    static abstract string Convert(string stringToConvert);

    /// <summary>
    /// Converts the specified characters to the target case.
    /// </summary>
    /// <param name="stringToConvert">The characters to convert.</param>
    /// <returns>The converted string.</returns>
    static abstract string Convert(ReadOnlySpan<char> stringToConvert);
}
