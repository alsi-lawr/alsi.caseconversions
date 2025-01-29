namespace ALSI.CaseConversions.MacroCase
{
    using System;

    /// <summary>
    /// For formatting strings to MACRO_CASE.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts the specified string to MACRO_CASE.
        /// </summary>
        /// <param name="stringToConvert">The string to convert.</param>
        /// <returns>Macro case version of the string.</returns>
        public static string Convert(ReadOnlySpan<char> stringToConvert) =>
            Converter<MacroCaseConverter>.ConvertCase(stringToConvert);
    }
}
