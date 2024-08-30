namespace ALSI.CaseConversions.UnitTests;

using FluentAssertions;
using static ALSI.CaseConversions.PascalCase.Converter;

public class PascalCaseTests
{
    #region Basic String Conversion

    [Fact]
    public void ConvertString_SingleWord_PascalCaseOutput()
    {
        // Arrange
        var input = "hello";
        var expected = "Hello";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_MultipleWords_ConvertsToPascalCase()
    {
        // Arrange
        var input = "hello_world";
        var expected = "HelloWorld";

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
    public void ConvertString_SingleCharacter_PascalCaseOutput()
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
    public void ConvertString_TwoCharacters_PascalCaseOutput()
    {
        // Arrange
        var input = "aa";
        var expected = "Aa";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_SnakeCaseInput_ConvertedToPascalCase()
    {
        // Arrange
        var input = "snake_case_input";
        var expected = "SnakeCaseInput";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_CamelCaseInput_ConvertedToPascalCase()
    {
        // Arrange
        var input = "camelCaseInput";
        var expected = "CamelCaseInput";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_AllLowercaseInput_ConvertedToPascalCase()
    {
        // Arrange
        var input = "hello_world";
        var expected = "HelloWorld";

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
        var input = "file123_name";
        var expected = "File123Name";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithSpecialCharacters_IgnoresSpecialCharacters()
    {
        // Arrange
        var input = "hello@world!";
        var expected = "Helloworld";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithSpaces_ConvertsToPascalCase()
    {
        // Arrange
        var input = "hello world";
        var expected = "HelloWorld";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithLeadingOrTrailingSpaces_TrimsAndConverts()
    {
        // Arrange
        var input = "  hello world  ";
        var expected = "HelloWorld";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithMixedCase_ConvertedToPascalCase()
    {
        // Arrange
        var input = "hello_world_example";
        var expected = "HelloWorldExample";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithPascalCase_LeavesPascalCaseUnchanged()
    {
        // Arrange
        var input = "HelloWorldExample";
        var expected = "HelloWorldExample";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithHyphens_ConvertsToPascalCase()
    {
        // Arrange
        var input = "hello-world-example";
        var expected = "HelloWorldExample";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithDots_ConvertsToPascalCase()
    {
        // Arrange
        var input = "hello.world.example";
        var expected = "HelloWorldExample";

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
    public void ConvertString_StringWithConsecutiveUppercaseLetters_InsertsSingleUppercase()
    {
        // Arrange
        var input = "XMLRequest";
        var expected = "XmlRequest";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithLeadingUnderscore_HandlesLeadingUnderscoreCorrectly()
    {
        // Arrange
        var input = "_hello.world.example";
        var expected = "HelloWorldExample";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithTrailingUnderscore_HandlesTrailingUnderscoreCorrectly()
    {
        // Arrange
        var input = "hello.world.example_";
        var expected = "HelloWorldExample";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithTrailingUppercase_AppropriatelyCapitalizesWords()
    {
        // Arrange
        var input = "hello_world_examplE";
        var expected = "HelloWorldExamplE";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_ExtraLongString_ConvertsToPascalCase()
    {
        // Arrange
        var input = string.Concat(Enumerable.Repeat("hello_world_example_", 16));
        var expected = string.Concat(Enumerable.Repeat("HelloWorldExample", 16));

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    #endregion
}
