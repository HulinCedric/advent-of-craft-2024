using Communication.Tests.Doubles;
using FluentAssertions;
using Xunit;
using static Communication.Tests.Builders.ReindeerBuilder;
using static Communication.Tests.Builders.MessageDefaults;

namespace Communication.Tests;

public class SantaCommunicatorTests
{
    private readonly SantaCommunicator _communicator = new();
    private readonly TestLogger _logger = new();

    [Fact]
    public void ComposeMessage()
        => _communicator.ComposeMessage(
                AReindeer()
                    .Named(Dasher)
                    .LocatedAt(NorthPole),
                new DaysBeforeReturn(
                    new NumbersOfDaysForComingBack(5),
                    new NumberOfDaysBeforeChristmas(24),
                    new NumberOfDaysToRest(2)))
            .Should()
            .Be("Dear Dasher, please return from North Pole in 17 day(s) to be ready and rest before Christmas.");

    [Fact]
    public void ShouldDetectOverdueReindeer()
    {
        var overdue = _communicator.IsOverdue(
            AReindeer()
                .Named(Dasher)
                .LocatedAt(NorthPole),
            new DaysBeforeReturn(
                new NumbersOfDaysForComingBack(22),
                new NumberOfDaysBeforeChristmas(24),
                new NumberOfDaysToRest(2)),
            _logger);

        overdue.Should().BeTrue();
        _logger.LoggedMessage().Should().Be("Overdue for Dasher located North Pole.");
    }

    [Fact]
    public void ShouldReturnFalseWhenNoOverdue()
        => _communicator.IsOverdue(
                AReindeer(),
                new DaysBeforeReturn(
                    new NumbersOfDaysForComingBack(5),
                    new NumberOfDaysBeforeChristmas(24),
                    new NumberOfDaysToRest(2)),
                _logger)
            .Should()
            .BeFalse();
}