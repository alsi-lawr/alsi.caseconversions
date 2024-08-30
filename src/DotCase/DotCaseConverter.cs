namespace ALSI.CaseConversions.DotCase;

using ALSI.CaseConversions;

internal readonly struct DotCaseConverter : ICaseConverter
{
    private const char DOT = '.';

    public static void SeparatorConversion(ref Span<char> destinationBuffer, ref int charsWritten, in char charToConvert)
    {
        destinationBuffer[charsWritten++] = DOT;
        destinationBuffer[charsWritten++] = ASCIICaseCheck.ToLower(charToConvert);
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
