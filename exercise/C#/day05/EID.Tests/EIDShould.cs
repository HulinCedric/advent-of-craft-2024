using FluentAssertions;
using Xunit;

namespace EID.Tests;

// ReSharper disable once InconsistentNaming
public class EIDShould
{
    [Theory]
    [InlineData("1", "too short")]
    [InlineData("198007671", "too long")]
    [InlineData("49800767", "incorrect sex")]
    [InlineData("1xx00767", "incorrect year")]
    [InlineData("198xxx67", "incorrect serial number")]
    [InlineData("19800067", "incorrect serial number")]
    [InlineData("198007xx", "incorrect control key")]
    [InlineData("19800799", "incorrect control key")]
    [InlineData("19800701", "incorrect control key")]
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
           && ValidateSex(input[0])
           && ValidateYear(input[1..3])
           && ValidateSerialNumber(input[3..6])
           && ValidateControlKey(input[..6], input[6..8]);

    private static bool ValidateLength(string input) => input.Length == 8;

    private static bool ValidateSex(char sex) => sex is '1' or '2' or '3';

    private static bool ValidateYear(string year) => IsANumber(year);

    private static bool ValidateSerialNumber(string serialNumber)
        => IsANumber(serialNumber) && int.Parse(serialNumber) is >= 1 and <= 999;

    private static bool ValidateControlKey(string eidWithoutKey, string controlKey)
    {
        if (!IsANumber(controlKey)) return false;

        var key = int.Parse(controlKey);

        var checksum = 97 - int.Parse(eidWithoutKey) % 97;

        return key == checksum;
    }

    private static bool IsANumber(string input) => input.All(char.IsDigit);
}