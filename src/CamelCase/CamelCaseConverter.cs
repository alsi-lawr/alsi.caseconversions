namespace ALSI.CaseConversions.CamelCase;

using ALSI.CaseConversions;

internal readonly struct CamelCaseConverter : ICaseConverter
{
    public static void SeparatorConversion(ref Span<char> destinationBuffer, ref int charsWritten, in char charToConvert)
    {
        destinationBuffer[charsWritten++] = ASCIICaseCheck.ToUpper(charToConvert);
    }

    public static void UnseparatedConversion(ref Span<char> destinationBuffer, ref int charsWritten, in char charToConvert)
    {
        destinationBuffer[charsWritten++] = ASCIICaseCheck.ToLower(charToConvert);
    }

    public static void FirstCharConversion(ref Span<char> destinationBuffer, ref int charsWritten, in char charToConvert)
    {
        destinationBuffer[charsWritten++] = ASCIICaseCheck.ToLower(charToConvert);
    }
}
