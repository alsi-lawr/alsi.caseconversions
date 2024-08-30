namespace ALSI.CaseConversions;

using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using static ALSI.CaseConversions.ASCIICaseCheck;

internal static class Converter<TConverter>
    where TConverter : ICaseConverter
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string ConvertCase(ReadOnlySpan<char> stringToConvert)
    {
        if (stringToConvert.IsEmpty)
        {
            return string.Empty;
        }

        char[]? rentedBuffer = null;

        int maxStackSize = 256;
        Span<char> destinationBuffer =
            stringToConvert.Length < maxStackSize
                ? stackalloc char[stringToConvert.Length * 2]
                : (rentedBuffer = ArrayPool<char>.Shared.Rent(stringToConvert.Length * 2));

        int charsWritten = WriteToBuffer(stringToConvert, ref destinationBuffer);

        string result = new(destinationBuffer[..charsWritten]);

        if (rentedBuffer is not null)
        {
            destinationBuffer[..charsWritten].Clear();
            ArrayPool<char>.Shared.Return(rentedBuffer);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private static int WriteToBuffer(ReadOnlySpan<char> stringToConvert, ref Span<char> destinationBuffer)
    {
        int charsWritten = 0;
        for (int i = 0; i < stringToConvert.Length; i++)
        {
            if (ShouldSkip(stringToConvert[i]))
            {
                continue;
            }

            if (
                i != 0
                && charsWritten != 0
                && (
                    (
                        IsUpper(stringToConvert[i])
                        && (
                            !IsUpper(stringToConvert[i - 1])
                            || !IsDelimiterChar(i == stringToConvert.Length - 1 ? NUL : stringToConvert[i + 1])
                        )
                    ) || IsDelimiter(stringToConvert[i - 1])
                )
            )
            {
                TConverter.SeparatorConversion(ref destinationBuffer, ref charsWritten, stringToConvert[i]);
            }
            else if (charsWritten == 0)
            {
                TConverter.FirstCharConversion(ref destinationBuffer, ref charsWritten, stringToConvert[i]);
            }
            else
            {
                TConverter.UnseparatedConversion(ref destinationBuffer, ref charsWritten, stringToConvert[i]);
            }
        }

        return charsWritten;
    }
}
