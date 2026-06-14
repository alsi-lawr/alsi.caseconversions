namespace ALSI.CaseConversions.UnitTests;

using ALSI.CaseConversions;
using Shouldly;
using Xunit;

public class AsciiCaseCheckTests
{
    [Fact]
    public void IsUpper_ShouldReturnTrueForUppercaseLetters()
    {
        AsciiCaseCheck.IsUpper('A').ShouldBeTrue();
        AsciiCaseCheck.IsUpper('Z').ShouldBeTrue();
    }

    [Fact]
    public void IsUpper_ShouldReturnFalseForNonUppercaseLetters()
    {
        AsciiCaseCheck.IsUpper('a').ShouldBeFalse();
        AsciiCaseCheck.IsUpper('z').ShouldBeFalse();
        AsciiCaseCheck.IsUpper('0').ShouldBeFalse();
        AsciiCaseCheck.IsUpper(' ').ShouldBeFalse();
        AsciiCaseCheck.IsUpper('_').ShouldBeFalse();
    }

    [Fact]
    public void IsLower_ShouldReturnTrueForLowercaseLetters()
    {
        AsciiCaseCheck.IsLower('a').ShouldBeTrue();
        AsciiCaseCheck.IsLower('z').ShouldBeTrue();
    }

    [Fact]
    public void IsLower_ShouldReturnFalseForNonLowercaseLetters()
    {
        AsciiCaseCheck.IsLower('A').ShouldBeFalse();
        AsciiCaseCheck.IsLower('Z').ShouldBeFalse();
        AsciiCaseCheck.IsLower('0').ShouldBeFalse();
        AsciiCaseCheck.IsLower(' ').ShouldBeFalse();
        AsciiCaseCheck.IsLower('_').ShouldBeFalse();
    }

    [Fact]
    public void IsDelimiter_ShouldReturnTrueForDelimiterCharacters()
    {
        AsciiCaseCheck.IsDelimiter('_').ShouldBeTrue();
        AsciiCaseCheck.IsDelimiter('.').ShouldBeTrue();
        AsciiCaseCheck.IsDelimiter(' ').ShouldBeTrue();
    }

    [Fact]
    public void IsDelimiter_ShouldReturnFalseForNonDelimiterCharacters()
    {
        AsciiCaseCheck.IsDelimiter('A').ShouldBeFalse();
        AsciiCaseCheck.IsDelimiter('a').ShouldBeFalse();
        AsciiCaseCheck.IsDelimiter('0').ShouldBeFalse();
    }

    [Fact]
    public void IsDigit_ShouldReturnTrueForDigitCharacters()
    {
        AsciiCaseCheck.IsDigit('0').ShouldBeTrue();
        AsciiCaseCheck.IsDigit('9').ShouldBeTrue();
    }

    [Fact]
    public void IsDigit_ShouldReturnFalseForNonDigitCharacters()
    {
        AsciiCaseCheck.IsDigit('A').ShouldBeFalse();
        AsciiCaseCheck.IsDigit('a').ShouldBeFalse();
        AsciiCaseCheck.IsDigit(' ').ShouldBeFalse();
        AsciiCaseCheck.IsDigit('_').ShouldBeFalse();
    }

    [Fact]
    public void ShouldSkip_ShouldReturnTrueForCharactersThatShouldBeSkipped()
    {
        // Characters that are not uppercase, lowercase, or digits should be skipped
        AsciiCaseCheck.ShouldSkip(' ').ShouldBeTrue(); // Space
        AsciiCaseCheck.ShouldSkip('.').ShouldBeTrue(); // Dot (if not marked as digit/letter)
        AsciiCaseCheck.ShouldSkip('#').ShouldBeTrue(); // Some other non-letter/digit
    }

    [Fact]
    public void ShouldSkip_ShouldReturnFalseForCharactersThatShouldNotBeSkipped()
    {
        // Uppercase, lowercase, and digit characters should not be skipped
        AsciiCaseCheck.ShouldSkip('A').ShouldBeFalse();
        AsciiCaseCheck.ShouldSkip('a').ShouldBeFalse();
        AsciiCaseCheck.ShouldSkip('0').ShouldBeFalse();
    }

    [Fact]
    public void IsDelimiterChar_ShouldReturnTrueForUppercaseOrDelimiterCharacters()
    {
        AsciiCaseCheck.IsDelimiterChar('A').ShouldBeTrue(); // Uppercase letter
        AsciiCaseCheck.IsDelimiterChar('_').ShouldBeTrue(); // Delimiter
    }

    [Fact]
    public void IsDelimiterChar_ShouldReturnFalseForNonUppercaseOrDelimiterCharacters()
    {
        AsciiCaseCheck.IsDelimiterChar('a').ShouldBeFalse(); // Lowercase letter
        AsciiCaseCheck.IsDelimiterChar('0').ShouldBeFalse(); // Digit
    }

    [Fact]
    public void GivenUpperCase_WhenConvertToLower_ShouldReturnLowercase()
    {
        AsciiCaseCheck.ToLower('A').ShouldBe('a');
        AsciiCaseCheck.ToLower('Z').ShouldBe('z');
        AsciiCaseCheck.ToLower('B').ShouldBe('b');
        AsciiCaseCheck.ToLower('C').ShouldBe('c');
        AsciiCaseCheck.ToLower('D').ShouldBe('d');
        AsciiCaseCheck.ToLower('E').ShouldBe('e');
        AsciiCaseCheck.ToLower('F').ShouldBe('f');
        AsciiCaseCheck.ToLower('G').ShouldBe('g');
        AsciiCaseCheck.ToLower('H').ShouldBe('h');
        AsciiCaseCheck.ToLower('I').ShouldBe('i');
        AsciiCaseCheck.ToLower('J').ShouldBe('j');
        AsciiCaseCheck.ToLower('K').ShouldBe('k');
        AsciiCaseCheck.ToLower('L').ShouldBe('l');
        AsciiCaseCheck.ToLower('M').ShouldBe('m');
        AsciiCaseCheck.ToLower('N').ShouldBe('n');
        AsciiCaseCheck.ToLower('O').ShouldBe('o');
        AsciiCaseCheck.ToLower('P').ShouldBe('p');
        AsciiCaseCheck.ToLower('Q').ShouldBe('q');
        AsciiCaseCheck.ToLower('R').ShouldBe('r');
        AsciiCaseCheck.ToLower('S').ShouldBe('s');
        AsciiCaseCheck.ToLower('T').ShouldBe('t');
        AsciiCaseCheck.ToLower('U').ShouldBe('u');
        AsciiCaseCheck.ToLower('V').ShouldBe('v');
        AsciiCaseCheck.ToLower('W').ShouldBe('w');
        AsciiCaseCheck.ToLower('X').ShouldBe('x');
        AsciiCaseCheck.ToLower('Y').ShouldBe('y');
        AsciiCaseCheck.ToLower('Z').ShouldBe('z');
        AsciiCaseCheck.ToLower('0').ShouldBe('0');
        AsciiCaseCheck.ToLower('1').ShouldBe('1');
        AsciiCaseCheck.ToLower('2').ShouldBe('2');
        AsciiCaseCheck.ToLower('3').ShouldBe('3');
        AsciiCaseCheck.ToLower('4').ShouldBe('4');
        AsciiCaseCheck.ToLower('5').ShouldBe('5');
        AsciiCaseCheck.ToLower('6').ShouldBe('6');
        AsciiCaseCheck.ToLower('7').ShouldBe('7');
        AsciiCaseCheck.ToLower('8').ShouldBe('8');
        AsciiCaseCheck.ToLower('9').ShouldBe('9');
        AsciiCaseCheck.ToLower(' ').ShouldBe(' ');
        AsciiCaseCheck.ToLower('a').ShouldBe('a');
    }

    [Fact]
    public void GivenLowerCase_WhenConvertToUpper_ShouldReturnUppercase()
    {
        AsciiCaseCheck.ToUpper('a').ShouldBe('A');
        AsciiCaseCheck.ToUpper('z').ShouldBe('Z');
        AsciiCaseCheck.ToUpper('b').ShouldBe('B');
        AsciiCaseCheck.ToUpper('c').ShouldBe('C');
        AsciiCaseCheck.ToUpper('d').ShouldBe('D');
        AsciiCaseCheck.ToUpper('e').ShouldBe('E');
        AsciiCaseCheck.ToUpper('f').ShouldBe('F');
        AsciiCaseCheck.ToUpper('g').ShouldBe('G');
        AsciiCaseCheck.ToUpper('h').ShouldBe('H');
        AsciiCaseCheck.ToUpper('i').ShouldBe('I');
        AsciiCaseCheck.ToUpper('j').ShouldBe('J');
        AsciiCaseCheck.ToUpper('k').ShouldBe('K');
        AsciiCaseCheck.ToUpper('l').ShouldBe('L');
        AsciiCaseCheck.ToUpper('m').ShouldBe('M');
        AsciiCaseCheck.ToUpper('n').ShouldBe('N');
        AsciiCaseCheck.ToUpper('o').ShouldBe('O');
        AsciiCaseCheck.ToUpper('p').ShouldBe('P');
        AsciiCaseCheck.ToUpper('q').ShouldBe('Q');
        AsciiCaseCheck.ToUpper('r').ShouldBe('R');
        AsciiCaseCheck.ToUpper('s').ShouldBe('S');
        AsciiCaseCheck.ToUpper('t').ShouldBe('T');
        AsciiCaseCheck.ToUpper('u').ShouldBe('U');
        AsciiCaseCheck.ToUpper('v').ShouldBe('V');
        AsciiCaseCheck.ToUpper('w').ShouldBe('W');
        AsciiCaseCheck.ToUpper('x').ShouldBe('X');
        AsciiCaseCheck.ToUpper('y').ShouldBe('Y');
        AsciiCaseCheck.ToUpper('z').ShouldBe('Z');
        AsciiCaseCheck.ToUpper('0').ShouldBe('0');
        AsciiCaseCheck.ToUpper('0').ShouldBe('0');
        AsciiCaseCheck.ToUpper('1').ShouldBe('1');
        AsciiCaseCheck.ToUpper('2').ShouldBe('2');
        AsciiCaseCheck.ToUpper('3').ShouldBe('3');
        AsciiCaseCheck.ToUpper('4').ShouldBe('4');
        AsciiCaseCheck.ToUpper('5').ShouldBe('5');
        AsciiCaseCheck.ToUpper('6').ShouldBe('6');
        AsciiCaseCheck.ToUpper('7').ShouldBe('7');
        AsciiCaseCheck.ToUpper('8').ShouldBe('8');
        AsciiCaseCheck.ToUpper('9').ShouldBe('9');
        AsciiCaseCheck.ToUpper(' ').ShouldBe(' ');
        AsciiCaseCheck.ToUpper('A').ShouldBe('A');
    }
}
