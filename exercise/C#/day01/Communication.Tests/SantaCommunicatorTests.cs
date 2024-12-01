using Communication.Tests.Doubles;
using FluentAssertions;
using Xunit;

namespace Communication.Tests;

public class SantaCommunicatorTests
{
    private const string Dasher = "Dasher";
    private const string NorthPole = "North Pole";
    private const int NumberOfDaysToRest = 2;
    private const int NumberOfDayBeforeChristmas = 24;
    private readonly SantaCommunicator _communicator = new(NumberOfDaysToRest);
    private readonly TestLogger _logger = new();

    [Fact]
    public void ComposeMessage()
        => _communicator.ComposeMessage(new Message(new ReindeerName(Dasher), new CurrentLocation(NorthPole), 5, NumberOfDayBeforeChristmas))
            .Should()
            .Be("Dear Dasher, please return from North Pole in 17 day(s) to be ready and rest before Christmas.");

    [Fact]
    public void ShouldDetectOverdueReindeer()
    {
        var overdue = _communicator.IsOverdue(
            new Message(new ReindeerName(Dasher), new CurrentLocation(NorthPole), NumberOfDayBeforeChristmas, NumberOfDayBeforeChristmas),
            _logger);

        overdue.Should().BeTrue();
        _logger.LoggedMessage().Should().Be("Overdue for Dasher located North Pole.");
    }

    [Fact]
    public void ShouldReturnFalseWhenNoOverdue()
        => _communicator.IsOverdue(
                new Message(new ReindeerName(Dasher), new CurrentLocation(NorthPole), NumberOfDayBeforeChristmas - NumberOfDaysToRest - 1, NumberOfDayBeforeChristmas),
                _logger)
            .Should()
            .BeFalse();
}