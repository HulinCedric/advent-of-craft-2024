using Communication.Tests.Doubles;
using FluentAssertions;
using Xunit;
using static Communication.Tests.Builders.MessageBuilder;
using static Communication.Tests.Builders.MessageDefaults;

namespace Communication.Tests;

public class SantaCommunicatorTests
{
    private readonly SantaCommunicator _communicator = new(NumberOfDaysToRest);
    private readonly TestLogger _logger = new();

    [Fact]
    public void ComposeMessage()
        => _communicator.ComposeMessage(
                AMessage()
                    .WithReindeerName(Dasher)
                    .WithCurrentLocation(NorthPole)
                    .WithNumbersOfDaysForComingBack(5)
                    .WithNumberOfDaysBeforeChristmas(NumberOfDayBeforeChristmas))
            .Should()
            .Be("Dear Dasher, please return from North Pole in 17 day(s) to be ready and rest before Christmas.");

    [Fact]
    public void ShouldDetectOverdueReindeer()
    {
        var overdue = _communicator.IsOverdue(
            AMessage()
                .Overdue()
                .WithReindeerName(Dasher)
                .WithCurrentLocation(NorthPole),
            _logger);

        overdue.Should().BeTrue();
        _logger.LoggedMessage().Should().Be("Overdue for Dasher located North Pole.");
    }

    [Fact]
    public void ShouldReturnFalseWhenNoOverdue()
        => _communicator.IsOverdue(
                AMessage(),
                _logger)
            .Should()
            .BeFalse();
}