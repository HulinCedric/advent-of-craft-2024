namespace Communication;

public record DaysBeforeReturn(
    NumbersOfDaysForComingBack NumbersOfDaysForComingBack,
    NumberOfDaysBeforeChristmas NumberOfDaysBeforeChristmas,
    NumberOfDaysToRest NumberOfDaysToRest)
{
    public static implicit operator int(DaysBeforeReturn daysBeforeReturn) => Compute(daysBeforeReturn);

    private static int Compute(DaysBeforeReturn daysBeforeReturn)
        => daysBeforeReturn.NumberOfDaysBeforeChristmas -
           daysBeforeReturn.NumbersOfDaysForComingBack -
           daysBeforeReturn.NumberOfDaysToRest;

    public override string ToString() => $"{Compute(this)}";
}