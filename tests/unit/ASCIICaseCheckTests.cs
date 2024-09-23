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

    [Fact]
    public void GivenUpperCase_WhenConvertToLower_ShouldReturnLowercase()
    {
        ASCIICaseCheck.ToLower('A').Should().Be('a');
        ASCIICaseCheck.ToLower('Z').Should().Be('z');
        ASCIICaseCheck.ToLower('B').Should().Be('b');
        ASCIICaseCheck.ToLower('C').Should().Be('c');
        ASCIICaseCheck.ToLower('D').Should().Be('d');
        ASCIICaseCheck.ToLower('E').Should().Be('e');
        ASCIICaseCheck.ToLower('F').Should().Be('f');
        ASCIICaseCheck.ToLower('G').Should().Be('g');
        ASCIICaseCheck.ToLower('H').Should().Be('h');
        ASCIICaseCheck.ToLower('I').Should().Be('i');
        ASCIICaseCheck.ToLower('J').Should().Be('j');
        ASCIICaseCheck.ToLower('K').Should().Be('k');
        ASCIICaseCheck.ToLower('L').Should().Be('l');
        ASCIICaseCheck.ToLower('M').Should().Be('m');
        ASCIICaseCheck.ToLower('N').Should().Be('n');
        ASCIICaseCheck.ToLower('O').Should().Be('o');
        ASCIICaseCheck.ToLower('P').Should().Be('p');
        ASCIICaseCheck.ToLower('Q').Should().Be('q');
        ASCIICaseCheck.ToLower('R').Should().Be('r');
        ASCIICaseCheck.ToLower('S').Should().Be('s');
        ASCIICaseCheck.ToLower('T').Should().Be('t');
        ASCIICaseCheck.ToLower('U').Should().Be('u');
        ASCIICaseCheck.ToLower('V').Should().Be('v');
        ASCIICaseCheck.ToLower('W').Should().Be('w');
        ASCIICaseCheck.ToLower('X').Should().Be('x');
        ASCIICaseCheck.ToLower('Y').Should().Be('y');
        ASCIICaseCheck.ToLower('Z').Should().Be('z');
        ASCIICaseCheck.ToLower('0').Should().Be('0');
        ASCIICaseCheck.ToLower('1').Should().Be('1');
        ASCIICaseCheck.ToLower('2').Should().Be('2');
        ASCIICaseCheck.ToLower('3').Should().Be('3');
        ASCIICaseCheck.ToLower('4').Should().Be('4');
        ASCIICaseCheck.ToLower('5').Should().Be('5');
        ASCIICaseCheck.ToLower('6').Should().Be('6');
        ASCIICaseCheck.ToLower('7').Should().Be('7');
        ASCIICaseCheck.ToLower('8').Should().Be('8');
        ASCIICaseCheck.ToLower('9').Should().Be('9');
        ASCIICaseCheck.ToLower(' ').Should().Be(' ');
        ASCIICaseCheck.ToLower('a').Should().Be('a');
    }

    [Fact]
    public void GivenLowerCase_WhenConvertToUpper_ShouldReturnUppercase()
    {
        ASCIICaseCheck.ToUpper('a').Should().Be('A');
        ASCIICaseCheck.ToUpper('z').Should().Be('Z');
        ASCIICaseCheck.ToUpper('b').Should().Be('B');
        ASCIICaseCheck.ToUpper('c').Should().Be('C');
        ASCIICaseCheck.ToUpper('d').Should().Be('D');
        ASCIICaseCheck.ToUpper('e').Should().Be('E');
        ASCIICaseCheck.ToUpper('f').Should().Be('F');
        ASCIICaseCheck.ToUpper('g').Should().Be('G');
        ASCIICaseCheck.ToUpper('h').Should().Be('H');
        ASCIICaseCheck.ToUpper('i').Should().Be('I');
        ASCIICaseCheck.ToUpper('j').Should().Be('J');
        ASCIICaseCheck.ToUpper('k').Should().Be('K');
        ASCIICaseCheck.ToUpper('l').Should().Be('L');
        ASCIICaseCheck.ToUpper('m').Should().Be('M');
        ASCIICaseCheck.ToUpper('n').Should().Be('N');
        ASCIICaseCheck.ToUpper('o').Should().Be('O');
        ASCIICaseCheck.ToUpper('p').Should().Be('P');
        ASCIICaseCheck.ToUpper('q').Should().Be('Q');
        ASCIICaseCheck.ToUpper('r').Should().Be('R');
        ASCIICaseCheck.ToUpper('s').Should().Be('S');
        ASCIICaseCheck.ToUpper('t').Should().Be('T');
        ASCIICaseCheck.ToUpper('u').Should().Be('U');
        ASCIICaseCheck.ToUpper('v').Should().Be('V');
        ASCIICaseCheck.ToUpper('w').Should().Be('W');
        ASCIICaseCheck.ToUpper('x').Should().Be('X');
        ASCIICaseCheck.ToUpper('y').Should().Be('Y');
        ASCIICaseCheck.ToUpper('z').Should().Be('Z');
        ASCIICaseCheck.ToUpper('0').Should().Be('0');
        ASCIICaseCheck.ToUpper('0').Should().Be('0');
        ASCIICaseCheck.ToUpper('1').Should().Be('1');
        ASCIICaseCheck.ToUpper('2').Should().Be('2');
        ASCIICaseCheck.ToUpper('3').Should().Be('3');
        ASCIICaseCheck.ToUpper('4').Should().Be('4');
        ASCIICaseCheck.ToUpper('5').Should().Be('5');
        ASCIICaseCheck.ToUpper('6').Should().Be('6');
        ASCIICaseCheck.ToUpper('7').Should().Be('7');
        ASCIICaseCheck.ToUpper('8').Should().Be('8');
        ASCIICaseCheck.ToUpper('9').Should().Be('9');
        ASCIICaseCheck.ToUpper(' ').Should().Be(' ');
        ASCIICaseCheck.ToUpper('A').Should().Be('A');
    }
}
