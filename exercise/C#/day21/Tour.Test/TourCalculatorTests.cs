namespace Tour.Test;

public class TourCalculatorTests
{
    private readonly List<List<Step>> _scenarios =
    [
        null!, // Null input
        new(), // Empty list
        new() // Single step
        {
            new Step(TimeOnly.Parse("08:00"), "Start", 300)
        },

        new() // Two steps unordered
        {
            new Step(TimeOnly.Parse("09:00"), "Checkpoint 1", 600),
            new Step(TimeOnly.Parse("08:00"), "Start", 300)
        },

        new() // Two steps ordered
        {
            new Step(TimeOnly.Parse("08:00"), "Start", 300),
            new Step(TimeOnly.Parse("09:00"), "Checkpoint 1", 600)
        },

        new() // Steps with duplicate times
        {
            new Step(TimeOnly.Parse("08:00"), "Start", 300),
            new Step(TimeOnly.Parse("08:00"), "Checkpoint 1", 600)
        },

        new() // Steps with identical labels
        {
            new Step(TimeOnly.Parse("08:00"), "Start", 300),
            new Step(TimeOnly.Parse("09:00"), "Start", 600)
        },

        new() // Steps with extreme delivery times
        {
            new Step(TimeOnly.Parse("08:00"), "Start", 0),
            new Step(TimeOnly.Parse("09:00"), "Checkpoint 1", int.MaxValue)
        }
    ];

    [Fact]
    public Task Calculate_ShouldMatchSnapshot()
        => Combination()
            .Verify(
                steps => new TourCalculator(steps).Calculate(),
                _scenarios);
}