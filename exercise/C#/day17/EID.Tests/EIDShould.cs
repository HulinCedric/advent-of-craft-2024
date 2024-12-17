using FluentAssertions;
using FluentAssertions.LanguageExt;
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
    [InlineData("19800074", "incorrect serial number")]
    [InlineData("198007xx", "incorrect control key")]
    [InlineData("19800799", "incorrect control key")]
    [InlineData("19800701", "incorrect control key")]
    public void Not_be_parsed(string input, string reason)
        => EID.Parse(input)
            .Should()
            .Be(new ParsingError(reason));

    [Theory]
    [InlineData("19800767", "Sloubi sex")]
    [InlineData("29800774", "Gagna sex")]
    [InlineData("39800781", "Catact sex")]
    [InlineData("10000797", "Minimum year")]
    [InlineData("19900737", "Maximal year")]
    [InlineData("19800173", "Minimal serial number")]
    [InlineData("19899945", "Maximal serial number")]
    public void Be_parsed(string input, string reason)
        => EID.Parse(input)
            .Should()
            .BeRight(eid => eid.ToString().Should().Be(input, reason), reason);
}