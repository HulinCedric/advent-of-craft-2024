using Communication.Tests.Doubles;
using FluentAssertions;
using Xunit;
using static Communication.Tests.Builders.ReindeerBuilder;
using static Communication.Tests.Builders.ReindeerDefaults;

namespace Communication.Tests;

public class SantaCommunicatorTests
{
    private static readonly NumberOfDaysBeforeChristmas NumberOfDaysBeforeChristmas = new(24);
    private static readonly NumberOfDaysToRest NumberOfDaysToRest = new(2);

    private readonly SantaCommunicator _communicator =
        new(new Configuration(NumberOfDaysToRest, NumberOfDaysBeforeChristmas));

    private readonly TestLogger _logger = new();

    [Fact]
    public void ComposeMessage()
        => _communicator.ComposeMessage(
                AReindeer()
                    .Named(Dasher)
                    .LocatedAt(NorthPole)
                    .TakesDaysForComingBack(5))
            .Should()
            .Be("Dear Dasher, please return from North Pole in 17 day(s) to be ready and rest before Christmas.");

    [Fact]
    public void ShouldDetectOverdueReindeer()
    {
        var overdue = _communicator.IsOverdue(
            AReindeer()
                .Named(Dasher)
                .LocatedAt(NorthPole)
                .TakesDaysForComingBack(NumberOfDaysBeforeChristmas),
            _logger);

        overdue.Should().BeTrue();
        _logger.LoggedMessage().Should().Be("Overdue for Dasher located North Pole.");
    }

    [Fact]
    public void ShouldReturnFalseWhenNoOverdue()
        => _communicator.IsOverdue(
                AReindeer()
                    .TakesDaysForComingBack(NumberOfDaysBeforeChristmas - NumberOfDaysToRest - 1),
                _logger)
            .Should()
            .BeFalse();
}