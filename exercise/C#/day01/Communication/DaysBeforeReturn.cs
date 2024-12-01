namespace Communication;

public record DaysBeforeReturn(int Value)
{
    public static DaysBeforeReturn Compute(
        NumberOfDaysForComingBack numberOfDaysForComingBack,
        NumberOfDaysBeforeChristmas numberOfDaysBeforeChristmas,
        NumberOfDaysToRest numberOfDaysToRest)
        => new(numberOfDaysBeforeChristmas - numberOfDaysForComingBack - numberOfDaysToRest);

    public static implicit operator int(DaysBeforeReturn daysBeforeReturn)
        => daysBeforeReturn.Value;

    public override string ToString() => $"{Value}";
}