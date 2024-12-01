namespace Communication;

public record NumberOfDaysToRest(int Value)
{
    public static implicit operator int(NumberOfDaysToRest numberOfDaysToRest)
        => numberOfDaysToRest.Value;

}