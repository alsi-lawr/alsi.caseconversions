namespace ALSI.CaseConversions.SentenceCase;

using ALSI.CaseConversions;

internal readonly struct SentenceCaseConverter : ICaseConverter
{
    public static void SeparatorConversion(
        ref Span<char> destinationBuffer,
        ref int charsWritten,
        in char charToConvert
    )
    {
        destinationBuffer[charsWritten++] = ' ';
        destinationBuffer[charsWritten++] = charToConvert;
    }

    public static void UnseparatedConversion(
        ref Span<char> destinationBuffer,
        ref int charsWritten,
        in char charToConvert
    )
    {
        destinationBuffer[charsWritten++] = charToConvert;
    }

    public static void FirstCharConversion(
        ref Span<char> destinationBuffer,
        ref int charsWritten,
        in char charToConvert
    )
    {
        destinationBuffer[charsWritten++] = charToConvert;
    }
}
