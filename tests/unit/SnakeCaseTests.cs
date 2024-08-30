namespace ALSI.CaseConversions.UnitTests;

using FluentAssertions;
using static ALSI.CaseConversions.SnakeCase.Converter;

public class SnakeCaseTests
{
    #region Basic String Conversion
    [Fact]
    public void ConvertString_SingleWord_LowercaseOutput()
    {
        // Arrange
        var input = "Hello";
        var expected = "hello";

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
        var expected = "hello_world";

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
    public void ConvertString_SingleCharacter_LowercaseOutput()
    {
        // Arrange
        var input = "A";
        var expected = "a";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_TwoCharactersCharacter_LowercaseOutput()
    {
        // Arrange
        var input = "AA";
        var expected = "aa";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_CamelCaseInput_ConvertedToSnakeCase()
    {
        // Arrange
        var input = "camelCaseInput";
        var expected = "camel_case_input";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_PascalCaseInput_ConvertedToSnakeCase()
    {
        // Arrange
        var input = "PascalCaseInput";
        var expected = "pascal_case_input";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_AllUppercaseInput_ConvertedToLowercaseWithUnderscores()
    {
        // Arrange
        var input = "HELLO_WORLD";
        var expected = "hello_world";

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
        var expected = "file123_name";

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
        var expected = "hello_world";

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
        var expected = "hello_world";

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
        var expected = "hello_world";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_SnakeCase_ConvertsToSnakeCase()
    {
        // Arrange
        var input = "hello_world_example";
        var expected = "hello_world_example";

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
        var expected = "hello_world_example";

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
        var expected = "hello_world_example";

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
        var expected = "xml_request";

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
        var expected = "hello_world_example";

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
        var expected = "hello_world_example";

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
        var expected = "hello_world_exampl_e";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_ExtraLongString_ConvertsToSnake()
    {
        // Arrange
        var input = string.Concat(Enumerable.Repeat("HelloWorldExample", 16));
        var expected = string.Concat(Enumerable.Repeat("hello_world_example_", 16))[..^1];

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }
    #endregion
}
