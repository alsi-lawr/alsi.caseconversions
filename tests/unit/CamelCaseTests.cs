namespace ALSI.CaseConversions.UnitTests;

using FluentAssertions;
using static ALSI.CaseConversions.CamelCase.Converter;

public class CamelCaseTests
{
    #region Basic String Conversion

    [Fact]
    public void ConvertString_SingleWord_LowercaseOutput()
    {
        // Arrange
        var input = "hello";
        var expected = "hello";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_MultipleWords_ConvertsToCamelCase()
    {
        // Arrange
        var input = "hello_world";
        var expected = "helloWorld";

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
    public void ConvertString_TwoCharacters_LowercaseOutput()
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
    public void ConvertString_SnakeCaseInput_ConvertedToCamelCase()
    {
        // Arrange
        var input = "snake_case_input";
        var expected = "snakeCaseInput";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_PascalCaseInput_ConvertedToCamelCase()
    {
        // Arrange
        var input = "PascalCaseInput";
        var expected = "pascalCaseInput";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_AllLowercaseInput_RemainsLowercase()
    {
        // Arrange
        var input = "hello_world";
        var expected = "helloWorld";

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
        var expected = "file123Name";

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
        var expected = "helloworld";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithSpaces_ConvertsToCamelCase()
    {
        // Arrange
        var input = "hello world";
        var expected = "helloWorld";

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
        var expected = "helloWorld";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithMixedCase_ConvertedToCamelCase()
    {
        // Arrange
        var input = "hello_world_example";
        var expected = "helloWorldExample";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithCamelCase_LeavesCamelCaseUnchanged()
    {
        // Arrange
        var input = "helloWorldExample";
        var expected = "helloWorldExample";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithHyphens_ConvertsToCamelCase()
    {
        // Arrange
        var input = "hello-world-example";
        var expected = "helloWorldExample";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithDots_ConvertsToCamelCase()
    {
        // Arrange
        var input = "hello.world.example";
        var expected = "helloWorldExample";

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
        var expected = "xmlRequest";

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
        var expected = "helloWorldExample";

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
        var expected = "helloWorldExample";

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
        var expected = "helloWorldExamplE";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_ExtraLongString_ConvertsToCamelCase()
    {
        // Arrange
        var input = string.Concat(Enumerable.Repeat("hello_world_example", 16));
        var expected = string.Concat(Enumerable.Repeat("helloWorldExample", 16));

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    #endregion
}
