namespace ALSI.CaseConversions.UnitTests;

using ALSI.CaseConversions;
using Shouldly;
using Xunit;

public class ASCIICaseCheckTests
{
    [Fact]
    public void IsUpper_ShouldReturnTrueForUppercaseLetters()
    {
        ASCIICaseCheck.IsUpper('A').ShouldBeTrue();
        ASCIICaseCheck.IsUpper('Z').ShouldBeTrue();
    }

    [Fact]
    public void IsUpper_ShouldReturnFalseForNonUppercaseLetters()
    {
        ASCIICaseCheck.IsUpper('a').ShouldBeFalse();
        ASCIICaseCheck.IsUpper('z').ShouldBeFalse();
        ASCIICaseCheck.IsUpper('0').ShouldBeFalse();
        ASCIICaseCheck.IsUpper(' ').ShouldBeFalse();
        ASCIICaseCheck.IsUpper('_').ShouldBeFalse();
    }

    [Fact]
    public void IsLower_ShouldReturnTrueForLowercaseLetters()
    {
        ASCIICaseCheck.IsLower('a').ShouldBeTrue();
        ASCIICaseCheck.IsLower('z').ShouldBeTrue();
    }

    [Fact]
    public void IsLower_ShouldReturnFalseForNonLowercaseLetters()
    {
        ASCIICaseCheck.IsLower('A').ShouldBeFalse();
        ASCIICaseCheck.IsLower('Z').ShouldBeFalse();
        ASCIICaseCheck.IsLower('0').ShouldBeFalse();
        ASCIICaseCheck.IsLower(' ').ShouldBeFalse();
        ASCIICaseCheck.IsLower('_').ShouldBeFalse();
    }

    [Fact]
    public void IsDelimiter_ShouldReturnTrueForDelimiterCharacters()
    {
        ASCIICaseCheck.IsDelimiter('_').ShouldBeTrue();
        ASCIICaseCheck.IsDelimiter('.').ShouldBeTrue();
        ASCIICaseCheck.IsDelimiter(' ').ShouldBeTrue();
    }

    [Fact]
    public void IsDelimiter_ShouldReturnFalseForNonDelimiterCharacters()
    {
        ASCIICaseCheck.IsDelimiter('A').ShouldBeFalse();
        ASCIICaseCheck.IsDelimiter('a').ShouldBeFalse();
        ASCIICaseCheck.IsDelimiter('0').ShouldBeFalse();
    }

    [Fact]
    public void IsDigit_ShouldReturnTrueForDigitCharacters()
    {
        ASCIICaseCheck.IsDigit('0').ShouldBeTrue();
        ASCIICaseCheck.IsDigit('9').ShouldBeTrue();
    }

    [Fact]
    public void IsDigit_ShouldReturnFalseForNonDigitCharacters()
    {
        ASCIICaseCheck.IsDigit('A').ShouldBeFalse();
        ASCIICaseCheck.IsDigit('a').ShouldBeFalse();
        ASCIICaseCheck.IsDigit(' ').ShouldBeFalse();
        ASCIICaseCheck.IsDigit('_').ShouldBeFalse();
    }

    [Fact]
    public void ShouldSkip_ShouldReturnTrueForCharactersThatShouldBeSkipped()
    {
        // Characters that are not uppercase, lowercase, or digits should be skipped
        ASCIICaseCheck.ShouldSkip(' ').ShouldBeTrue(); // Space
        ASCIICaseCheck.ShouldSkip('.').ShouldBeTrue(); // Dot (if not marked as digit/letter)
        ASCIICaseCheck.ShouldSkip('#').ShouldBeTrue(); // Some other non-letter/digit
    }

    [Fact]
    public void ShouldSkip_ShouldReturnFalseForCharactersThatShouldNotBeSkipped()
    {
        // Uppercase, lowercase, and digit characters should not be skipped
        ASCIICaseCheck.ShouldSkip('A').ShouldBeFalse();
        ASCIICaseCheck.ShouldSkip('a').ShouldBeFalse();
        ASCIICaseCheck.ShouldSkip('0').ShouldBeFalse();
    }

    [Fact]
    public void IsDelimiterChar_ShouldReturnTrueForUppercaseOrDelimiterCharacters()
    {
        ASCIICaseCheck.IsDelimiterChar('A').ShouldBeTrue(); // Uppercase letter
        ASCIICaseCheck.IsDelimiterChar('_').ShouldBeTrue(); // Delimiter
    }

    [Fact]
    public void IsDelimiterChar_ShouldReturnFalseForNonUppercaseOrDelimiterCharacters()
    {
        ASCIICaseCheck.IsDelimiterChar('a').ShouldBeFalse(); // Lowercase letter
        ASCIICaseCheck.IsDelimiterChar('0').ShouldBeFalse(); // Digit
    }

    [Fact]
    public void GivenUpperCase_WhenConvertToLower_ShouldReturnLowercase()
    {
        ASCIICaseCheck.ToLower('A').ShouldBe('a');
        ASCIICaseCheck.ToLower('Z').ShouldBe('z');
        ASCIICaseCheck.ToLower('B').ShouldBe('b');
        ASCIICaseCheck.ToLower('C').ShouldBe('c');
        ASCIICaseCheck.ToLower('D').ShouldBe('d');
        ASCIICaseCheck.ToLower('E').ShouldBe('e');
        ASCIICaseCheck.ToLower('F').ShouldBe('f');
        ASCIICaseCheck.ToLower('G').ShouldBe('g');
        ASCIICaseCheck.ToLower('H').ShouldBe('h');
        ASCIICaseCheck.ToLower('I').ShouldBe('i');
        ASCIICaseCheck.ToLower('J').ShouldBe('j');
        ASCIICaseCheck.ToLower('K').ShouldBe('k');
        ASCIICaseCheck.ToLower('L').ShouldBe('l');
        ASCIICaseCheck.ToLower('M').ShouldBe('m');
        ASCIICaseCheck.ToLower('N').ShouldBe('n');
        ASCIICaseCheck.ToLower('O').ShouldBe('o');
        ASCIICaseCheck.ToLower('P').ShouldBe('p');
        ASCIICaseCheck.ToLower('Q').ShouldBe('q');
        ASCIICaseCheck.ToLower('R').ShouldBe('r');
        ASCIICaseCheck.ToLower('S').ShouldBe('s');
        ASCIICaseCheck.ToLower('T').ShouldBe('t');
        ASCIICaseCheck.ToLower('U').ShouldBe('u');
        ASCIICaseCheck.ToLower('V').ShouldBe('v');
        ASCIICaseCheck.ToLower('W').ShouldBe('w');
        ASCIICaseCheck.ToLower('X').ShouldBe('x');
        ASCIICaseCheck.ToLower('Y').ShouldBe('y');
        ASCIICaseCheck.ToLower('Z').ShouldBe('z');
        ASCIICaseCheck.ToLower('0').ShouldBe('0');
        ASCIICaseCheck.ToLower('1').ShouldBe('1');
        ASCIICaseCheck.ToLower('2').ShouldBe('2');
        ASCIICaseCheck.ToLower('3').ShouldBe('3');
        ASCIICaseCheck.ToLower('4').ShouldBe('4');
        ASCIICaseCheck.ToLower('5').ShouldBe('5');
        ASCIICaseCheck.ToLower('6').ShouldBe('6');
        ASCIICaseCheck.ToLower('7').ShouldBe('7');
        ASCIICaseCheck.ToLower('8').ShouldBe('8');
        ASCIICaseCheck.ToLower('9').ShouldBe('9');
        ASCIICaseCheck.ToLower(' ').ShouldBe(' ');
        ASCIICaseCheck.ToLower('a').ShouldBe('a');
    }

    [Fact]
    public void GivenLowerCase_WhenConvertToUpper_ShouldReturnUppercase()
    {
        ASCIICaseCheck.ToUpper('a').ShouldBe('A');
        ASCIICaseCheck.ToUpper('z').ShouldBe('Z');
        ASCIICaseCheck.ToUpper('b').ShouldBe('B');
        ASCIICaseCheck.ToUpper('c').ShouldBe('C');
        ASCIICaseCheck.ToUpper('d').ShouldBe('D');
        ASCIICaseCheck.ToUpper('e').ShouldBe('E');
        ASCIICaseCheck.ToUpper('f').ShouldBe('F');
        ASCIICaseCheck.ToUpper('g').ShouldBe('G');
        ASCIICaseCheck.ToUpper('h').ShouldBe('H');
        ASCIICaseCheck.ToUpper('i').ShouldBe('I');
        ASCIICaseCheck.ToUpper('j').ShouldBe('J');
        ASCIICaseCheck.ToUpper('k').ShouldBe('K');
        ASCIICaseCheck.ToUpper('l').ShouldBe('L');
        ASCIICaseCheck.ToUpper('m').ShouldBe('M');
        ASCIICaseCheck.ToUpper('n').ShouldBe('N');
        ASCIICaseCheck.ToUpper('o').ShouldBe('O');
        ASCIICaseCheck.ToUpper('p').ShouldBe('P');
        ASCIICaseCheck.ToUpper('q').ShouldBe('Q');
        ASCIICaseCheck.ToUpper('r').ShouldBe('R');
        ASCIICaseCheck.ToUpper('s').ShouldBe('S');
        ASCIICaseCheck.ToUpper('t').ShouldBe('T');
        ASCIICaseCheck.ToUpper('u').ShouldBe('U');
        ASCIICaseCheck.ToUpper('v').ShouldBe('V');
        ASCIICaseCheck.ToUpper('w').ShouldBe('W');
        ASCIICaseCheck.ToUpper('x').ShouldBe('X');
        ASCIICaseCheck.ToUpper('y').ShouldBe('Y');
        ASCIICaseCheck.ToUpper('z').ShouldBe('Z');
        ASCIICaseCheck.ToUpper('0').ShouldBe('0');
        ASCIICaseCheck.ToUpper('0').ShouldBe('0');
        ASCIICaseCheck.ToUpper('1').ShouldBe('1');
        ASCIICaseCheck.ToUpper('2').ShouldBe('2');
        ASCIICaseCheck.ToUpper('3').ShouldBe('3');
        ASCIICaseCheck.ToUpper('4').ShouldBe('4');
        ASCIICaseCheck.ToUpper('5').ShouldBe('5');
        ASCIICaseCheck.ToUpper('6').ShouldBe('6');
        ASCIICaseCheck.ToUpper('7').ShouldBe('7');
        ASCIICaseCheck.ToUpper('8').ShouldBe('8');
        ASCIICaseCheck.ToUpper('9').ShouldBe('9');
        ASCIICaseCheck.ToUpper(' ').ShouldBe(' ');
        ASCIICaseCheck.ToUpper('A').ShouldBe('A');
    }
}
