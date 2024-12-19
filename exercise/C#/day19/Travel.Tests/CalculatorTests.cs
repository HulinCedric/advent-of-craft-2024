using FluentAssertions;
using Xunit;
using static Travel.SantaTravelCalculator;

namespace Travel.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(5, 31)]
        [InlineData(10, 1_023)]
        [InlineData(20, 1_048_575)]
        [InlineData(30, 1_073_741_823)]
        [InlineData(32, 4_294_967_295)]
        [InlineData(50, 1_125_899_906_842_623)]
        public void Should_Calculate_The_DistanceFor(int numberOfReindeers, ulong expectedDistance)
            => CalculateTotalDistanceRecursively(numberOfReindeers)
                .Should()
                .Be(expectedDistance);
    }
}