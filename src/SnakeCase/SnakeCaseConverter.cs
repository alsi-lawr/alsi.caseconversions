namespace ALSI.CaseConversions.SnakeCase;

using ALSI.CaseConversions;

internal readonly struct SnakeCaseConverter : ICaseConverter
{
    private const char USCORE = '_';

    public static void SeparatorConversion(ref Span<char> destinationBuffer, ref int charsWritten, in char charToConvert)
    {
        destinationBuffer[charsWritten++] = USCORE;
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
