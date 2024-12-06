using FluentAssertions;
using Xunit;

namespace EID.Tests;

// Following Canon TDD here is the list of tests that should be implemented:
// EID year should be between 00 and 99
// EID serial number should be between 001 and 999
// EID control key should be between 01 and 99
// EID control key should be valid (complement to 97 of the number formed by the first 6 digits of the EID modulo 97)
// ReSharper disable once InconsistentNaming
public class EIDShould
{
    [Theory]
    [InlineData("1", "too short")]
    [InlineData("198007671", "too long")]
    [InlineData("a9800767", "contains letters")]
    [InlineData("49800767", "incorrect sex")]
    public void Be_invalid(string input, string reason)
        => Validate(input)
            .Should()
            .BeFalse(reason);

    [Fact]
    public void Be_valid()
        => Validate("19800767")
            .Should()
            .BeTrue();

    private static bool Validate(string input)
        => ValidateLength(input)
           && ValidateIsNumber(input)
           && ValidateSex(input);

    private static bool ValidateSex(string input) => input[0] is '1' or '2' or '3';

    private static bool ValidateIsNumber(string input) => input.All(char.IsDigit);

    private static bool ValidateLength(string input) => input.Length == 8;
}