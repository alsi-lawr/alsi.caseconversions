namespace ALSI.CaseConversions.KebabCase;

using ALSI.CaseConversions;

internal readonly struct KebabCaseConverter : ICaseConverter
{
    private const char HYPHEN = '-';

    public static void SeparatorConversion(ref Span<char> destinationBuffer, ref int charsWritten, in char charToConvert)
    {
        destinationBuffer[charsWritten++] = HYPHEN;
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
