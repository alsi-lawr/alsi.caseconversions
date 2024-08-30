namespace ALSI.CaseConversions.UnitTests;

using FluentAssertions;
using static ALSI.CaseConversions.DotCase.Converter;

public class DotCaseTests
{
    #region Basic String Conversion

    [Fact]
    public void ConvertString_SingleWord_DotCaseOutput()
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
    public void ConvertString_MultipleWords_ConvertsToDotCase()
    {
        // Arrange
        var input = "hello_world";
        var expected = "hello.world";

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
    public void ConvertString_SingleCharacter_DotCaseOutput()
    {
        // Arrange
        var input = "a";
        var expected = "a";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_TwoCharacters_DotCaseOutput()
    {
        // Arrange
        var input = "aa";
        var expected = "aa";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_SnakeCaseInput_ConvertedToDotCase()
    {
        // Arrange
        var input = "snake_case_input";
        var expected = "snake.case.input";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_PascalCaseInput_ConvertedToDotCase()
    {
        // Arrange
        var input = "PascalCaseInput";
        var expected = "pascal.case.input";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_CamelCaseInput_ConvertedToDotCase()
    {
        // Arrange
        var input = "camelCaseInput";
        var expected = "camel.case.input";

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
        var expected = "file123.name";

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
    public void ConvertString_StringWithSpaces_ConvertsToDotCase()
    {
        // Arrange
        var input = "hello world";
        var expected = "hello.world";

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
        var expected = "hello.world";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithMixedCase_ConvertedToDotCase()
    {
        // Arrange
        var input = "hello_world_example";
        var expected = "hello.world.example";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_DotCaseInput_LeavesDotCaseUnchanged()
    {
        // Arrange
        var input = "hello.world.example";
        var expected = "hello.world.example";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_StringWithHyphens_ConvertsToDotCase()
    {
        // Arrange
        var input = "hello-world-example";
        var expected = "hello.world.example";

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
    public void ConvertString_StringWithConsecutiveUppercaseLetters_InsertsDotBetweenUppercase()
    {
        // Arrange
        var input = "XMLRequest";
        var expected = "xml.request";

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
        var expected = "hello.world.example";

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
        var expected = "hello.world.example";

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
        var expected = "hello.world.exampl.e";

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertString_ExtraLongString_ConvertsToDotCase()
    {
        // Arrange
        var input = string.Concat(Enumerable.Repeat("hello_world_example", 16));
        var expected = string.Concat(Enumerable.Repeat("hello.world.example", 16));

        // Act
        var result = Convert(input);

        // Assert
        result.Should().Be(expected);
    }

    #endregion
}
