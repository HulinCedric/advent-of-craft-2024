namespace Communication.Tests.Builders;

public class DaysBeforeReturnBuilder
{
    private const int NumberOfDaysBeforeChristmas = 24;
    private const int NumberOfDaysToRest = 2;
    private int _numberOfDaysForComingBack;

    public static DaysBeforeReturnBuilder Overdue()
        => new DaysBeforeReturnBuilder()
            .WithNumberOfDaysForComingBack(24);

    public static DaysBeforeReturnBuilder OnTime()
        => new DaysBeforeReturnBuilder()
            .WithNumberOfDaysForComingBack(5);

    private DaysBeforeReturnBuilder WithNumberOfDaysForComingBack(int numbersOfDaysForComingBack)
    {
        _numberOfDaysForComingBack = numbersOfDaysForComingBack;
        return this;
    }

    public static DaysBeforeReturn DaysBeforeReturn(int value) => new(value);

    public static implicit operator DaysBeforeReturn(DaysBeforeReturnBuilder builder) => builder.Build();

    public DaysBeforeReturn Build()
        => Communication.DaysBeforeReturn.Compute(
            new NumberOfDaysForComingBack(_numberOfDaysForComingBack),
            new NumberOfDaysBeforeChristmas(NumberOfDaysBeforeChristmas),
            new NumberOfDaysToRest(NumberOfDaysToRest));
}