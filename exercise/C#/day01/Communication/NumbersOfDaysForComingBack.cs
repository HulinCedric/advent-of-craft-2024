namespace Communication;

public record NumbersOfDaysForComingBack(int Value)
{
    public static implicit operator int(NumbersOfDaysForComingBack numbersOfDaysForComingBack)
        => numbersOfDaysForComingBack.Value;
}