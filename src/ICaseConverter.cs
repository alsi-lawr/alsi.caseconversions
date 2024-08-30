namespace ALSI.CaseConversions;

internal interface ICaseConverter
{
    public static abstract void SeparatorConversion(
        ref Span<char> destinationBuffer,
        ref int charsWritten,
        in char charToConvert
    );

    public static abstract void UnseparatedConversion(
        ref Span<char> destinationBuffer,
        ref int charsWritten,
        in char charToConvert
    );

    public static abstract void FirstCharConversion(
        ref Span<char> destinationBuffer,
        ref int charsWritten,
        in char charToConvert
    );
}
