namespace ALSI.CaseConversions.UnitTests;

using FluentAssertions;
using static ALSI.CaseConversions.MacroCase.Converter;

public class MacroCaseTests
{
    #region Basic String Conversion
    [Fact]
    public void ConvertString_SingleWord_UppercaseOutput()
    {
        // Arrange
        var input = "Hello";
        var expected = "HELLO";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_MultipleWords_SeparatedByUnderscores()
    {
        // Arrange
        var input = "HelloWorld";
        var expected = "HELLO_WORLD";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = Convert(input);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void ConvertString_NullInput_ReturnsEmptyString()
    {
        // Arrange
        string? input = null;

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(string.Empty);
    }

    [Fact]
    public void ConvertString_SingleCharacter_UppercaseOutput()
    {
        // Arrange
        var input = "a";
        var expected = "A";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_TwoCharacters_UppercaseOutput()
    {
        // Arrange
        var input = "aa";
        var expected = "AA";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_CamelCaseInput_ConvertedToMacroCase()
    {
        // Arrange
        var input = "camelCaseInput";
        var expected = "CAMEL_CASE_INPUT";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_PascalCaseInput_ConvertedToMacroCase()
    {
        // Arrange
        var input = "PascalCaseInput";
        var expected = "PASCAL_CASE_INPUT";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_AllLowercaseInput_ConvertedToUppercaseWithUnderscores()
    {
        // Arrange
        var input = "hello_world";
        var expected = "HELLO_WORLD";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }
    #endregion

    #region Special Characters and Numbers
    [Fact]
    public void ConvertString_StringWithNumbers_RetainsNumbers()
    {
        // Arrange
        var input = "File123Name";
        var expected = "FILE123_NAME";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithSpecialCharacters_IgnoresSpecialCharacters()
    {
        // Arrange
        var input = "Hello@World!";
        var expected = "HELLO_WORLD";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithSpaces_ConvertedToUnderscores()
    {
        // Arrange
        var input = "Hello World";
        var expected = "HELLO_WORLD";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithLeadingOrTrailingSpaces_TrimsAndConverts()
    {
        // Arrange
        var input = "  Hello World  ";
        var expected = "HELLO_WORLD";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_MacroCase_ConvertsToMacroCase()
    {
        // Arrange
        var input = "HELLO_WORLD_EXAMPLE";
        var expected = "HELLO_WORLD_EXAMPLE";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithHyphens_ConvertedToUnderscores()
    {
        // Arrange
        var input = "Hello-World-Example";
        var expected = "HELLO_WORLD_EXAMPLE";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithDots_ConvertedToUnderscores()
    {
        // Arrange
        var input = "Hello.World.Example";
        var expected = "HELLO_WORLD_EXAMPLE";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region Edge Cases
    [Fact]
    public void ConvertString_AllWhitespaceString_ReturnsEmptyString()
    {
        // Arrange
        var input = " \t\r\n";
        var expected = "";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithConsecutiveUppercaseLetters_InsertsSingleUnderscore()
    {
        // Arrange
        var input = "XMLRequest";
        var expected = "XML_REQUEST";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithLeadingUnderscore_HandlesLeadingUnderscoreCorrectly()
    {
        // Arrange
        var input = "_Hello.World.Example";
        var expected = "HELLO_WORLD_EXAMPLE";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithTrailingUnderscore_HandlesTrailingUnderscoreCorrectly()
    {
        // Arrange
        var input = "Hello.World.Example_";
        var expected = "HELLO_WORLD_EXAMPLE";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithTrailingUppercase_AppropriatelySeparatesWords()
    {
        // Arrange
        var input = "HelloWorldExamplE";
        var expected = "HELLO_WORLD_EXAMPL_E";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_ExtraLongString_ConvertsToMacro()
    {
        // Arrange
        var input = string.Concat(Enumerable.Repeat("HelloWorldExample", 16));
        var expected = string.Concat(Enumerable.Repeat("HELLO_WORLD_EXAMPLE_", 16))[..^1];

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }
    #endregion
}
