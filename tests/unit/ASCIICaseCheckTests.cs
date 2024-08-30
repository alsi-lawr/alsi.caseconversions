namespace ALSI.CaseConversions.UnitTests;

using ALSI.CaseConversions;
using FluentAssertions;
using Xunit;

public class ASCIICaseCheckTests
{
    [Fact]
    public void IsUpper_ShouldReturnTrueForUppercaseLetters()
    {
        ASCIICaseCheck.IsUpper('A').Should().BeTrue();
        ASCIICaseCheck.IsUpper('Z').Should().BeTrue();
    }

    [Fact]
    public void IsUpper_ShouldReturnFalseForNonUppercaseLetters()
    {
        ASCIICaseCheck.IsUpper('a').Should().BeFalse();
        ASCIICaseCheck.IsUpper('z').Should().BeFalse();
        ASCIICaseCheck.IsUpper('0').Should().BeFalse();
        ASCIICaseCheck.IsUpper(' ').Should().BeFalse();
        ASCIICaseCheck.IsUpper('_').Should().BeFalse();
    }

    [Fact]
    public void IsLower_ShouldReturnTrueForLowercaseLetters()
    {
        ASCIICaseCheck.IsLower('a').Should().BeTrue();
        ASCIICaseCheck.IsLower('z').Should().BeTrue();
    }

    [Fact]
    public void IsLower_ShouldReturnFalseForNonLowercaseLetters()
    {
        ASCIICaseCheck.IsLower('A').Should().BeFalse();
        ASCIICaseCheck.IsLower('Z').Should().BeFalse();
        ASCIICaseCheck.IsLower('0').Should().BeFalse();
        ASCIICaseCheck.IsLower(' ').Should().BeFalse();
        ASCIICaseCheck.IsLower('_').Should().BeFalse();
    }

    [Fact]
    public void IsDelimiter_ShouldReturnTrueForDelimiterCharacters()
    {
        ASCIICaseCheck.IsDelimiter('_').Should().BeTrue();
        ASCIICaseCheck.IsDelimiter('.').Should().BeTrue();
        ASCIICaseCheck.IsDelimiter(' ').Should().BeTrue();
    }

    [Fact]
    public void IsDelimiter_ShouldReturnFalseForNonDelimiterCharacters()
    {
        ASCIICaseCheck.IsDelimiter('A').Should().BeFalse();
        ASCIICaseCheck.IsDelimiter('a').Should().BeFalse();
        ASCIICaseCheck.IsDelimiter('0').Should().BeFalse();
    }

    [Fact]
    public void IsDigit_ShouldReturnTrueForDigitCharacters()
    {
        ASCIICaseCheck.IsDigit('0').Should().BeTrue();
        ASCIICaseCheck.IsDigit('9').Should().BeTrue();
    }

    [Fact]
    public void IsDigit_ShouldReturnFalseForNonDigitCharacters()
    {
        ASCIICaseCheck.IsDigit('A').Should().BeFalse();
        ASCIICaseCheck.IsDigit('a').Should().BeFalse();
        ASCIICaseCheck.IsDigit(' ').Should().BeFalse();
        ASCIICaseCheck.IsDigit('_').Should().BeFalse();
    }

    [Fact]
    public void ShouldSkip_ShouldReturnTrueForCharactersThatShouldBeSkipped()
    {
        // Characters that are not uppercase, lowercase, or digits should be skipped
        ASCIICaseCheck.ShouldSkip(' ').Should().BeTrue(); // Space
        ASCIICaseCheck.ShouldSkip('.').Should().BeTrue(); // Dot (if not marked as digit/letter)
        ASCIICaseCheck.ShouldSkip('#').Should().BeTrue(); // Some other non-letter/digit
    }

    [Fact]
    public void ShouldSkip_ShouldReturnFalseForCharactersThatShouldNotBeSkipped()
    {
        // Uppercase, lowercase, and digit characters should not be skipped
        ASCIICaseCheck.ShouldSkip('A').Should().BeFalse();
        ASCIICaseCheck.ShouldSkip('a').Should().BeFalse();
        ASCIICaseCheck.ShouldSkip('0').Should().BeFalse();
    }

    [Fact]
    public void IsDelimiterChar_ShouldReturnTrueForUppercaseOrDelimiterCharacters()
    {
        ASCIICaseCheck.IsDelimiterChar('A').Should().BeTrue(); // Uppercase letter
        ASCIICaseCheck.IsDelimiterChar('_').Should().BeTrue(); // Delimiter
    }

    [Fact]
    public void IsDelimiterChar_ShouldReturnFalseForNonUppercaseOrDelimiterCharacters()
    {
        ASCIICaseCheck.IsDelimiterChar('a').Should().BeFalse(); // Lowercase letter
        ASCIICaseCheck.IsDelimiterChar('0').Should().BeFalse(); // Digit
    }
}
