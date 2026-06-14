namespace ALSI.CaseConversions.UnitTests;

using ALSI.CaseConversions;
using Shouldly;

public class SentenceCaseTests
{
    #region Basic String Conversion
    [Fact]
    public void ConvertString_SingleWord_SameOutput()
    {
        // Arrange
        var input = "Hello";
        var expected = "Hello";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_MultipleWords_SeparatedBySpace()
    {
        // Arrange
        var input = "HelloWorld";
        var expected = "Hello World";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void ConvertString_NullInput_ReturnsEmptyString()
    {
        // Arrange
        string input = null!;

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void ConvertString_SingleCharacter_SameOutput()
    {
        // Arrange
        var input = "A";
        var expected = "A";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_TwoCharactersCharacter_SameOutput()
    {
        // Arrange
        var input = "AA";
        var expected = "AA";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_CamelCaseInput_ConvertedToSentenceCase()
    {
        // Arrange
        var input = "camelCaseInput";
        var expected = "camel Case Input";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_PascalCaseInput_ConvertedToSentenceCase()
    {
        // Arrange
        var input = "PascalCaseInput";
        var expected = "Pascal Case Input";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_AllUppercaseInput_ConvertedToSentenceCase()
    {
        // Arrange
        var input = "HELLO_WORLD";
        var expected = "HELLO WORLD";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }
    #endregion

    #region Special Characters and Numbers
    [Fact]
    public void ConvertString_StringWithNumbers_RetainsNumbers()
    {
        // Arrange
        var input = "File123Name";
        var expected = "File123 Name";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_StringWithSpecialCharacters_IgnoresSpecialCharacters()
    {
        // Arrange
        var input = "Hello@World!";
        var expected = "Hello World";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_StringWithSpaces_ConvertedToSentenceCase()
    {
        // Arrange
        var input = "Hello World";
        var expected = "Hello World";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_StringWithLeadingOrTrailingSpaces_TrimsAndConverts()
    {
        // Arrange
        var input = "  Hello World  ";
        var expected = "Hello World";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_SnakeCase_ConvertsToSentenceCase()
    {
        // Arrange
        var input = "hello_world_example";
        var expected = "hello world example";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_StringWithHyphens_ConvertedToSentenceCase()
    {
        // Arrange
        var input = "Hello-World-Example";
        var expected = "Hello World Example";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_StringWithDots_ConvertedToSentenceCase()
    {
        // Arrange
        var input = "Hello.World.Example";
        var expected = "Hello World Example";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
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
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_StringWithConsecutiveUppercaseLetters_InsertsSingleSpace()
    {
        // Arrange
        var input = "XMLRequest";
        var expected = "XML Request";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_StringWithLeadingUnderscore_HandlesLeadingUnderscoreCorrectly()
    {
        // Arrange
        var input = "_Hello.World.Example";
        var expected = "Hello World Example";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_StringWithTrailingUnderscore_HandlesTrailingUnderscoreCorrectly()
    {
        // Arrange
        var input = "Hello.World.Example_";
        var expected = "Hello World Example";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_StringWithTrailingUppercase_AppropriatelySeparatesWords()
    {
        // Arrange
        var input = "HelloWorldExamplE";
        var expected = "Hello World Exampl E";

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void ConvertString_ExtraLongString_ConvertsToSentence()
    {
        // Arrange
        var input = string.Concat(Enumerable.Repeat("HelloWorldExample", 16));
        var expected = string.Concat(Enumerable.Repeat("Hello World Example ", 16))[..^1];

        // Act
        var result = SentenceCase.Convert(input);

        // Assert
        result.ShouldBe(expected);
    }
    #endregion
}
