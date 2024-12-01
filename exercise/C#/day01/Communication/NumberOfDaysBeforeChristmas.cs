namespace Communication;

public record NumberOfDaysBeforeChristmas(int Value)
{
    public static implicit operator int(NumberOfDaysBeforeChristmas numberOfDaysBeforeChristmas)
        => numberOfDaysBeforeChristmas.Value;
}