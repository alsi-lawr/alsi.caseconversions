namespace ALSI.CaseConversions.MacroCase;

using ALSI.CaseConversions;

internal readonly struct MacroCaseConverter : ICaseConverter
{
    private const char USCORE = '_';

    public static void SeparatorConversion(ref Span<char> destinationBuffer, ref int charsWritten, in char charToConvert)
    {
        destinationBuffer[charsWritten++] = USCORE;
        destinationBuffer[charsWritten++] = ASCIICaseCheck.ToUpper(charToConvert);
    }

    public static void UnseparatedConversion(ref Span<char> destinationBuffer, ref int charsWritten, in char charToConvert)
    {
        destinationBuffer[charsWritten++] = ASCIICaseCheck.ToUpper(charToConvert);
    }

    public static void FirstCharConversion(ref Span<char> destinationBuffer, ref int charsWritten, in char charToConvert)
    {
        destinationBuffer[charsWritten++] = ASCIICaseCheck.ToUpper(charToConvert);
    }
}
