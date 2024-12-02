namespace Communication;

public record NumberOfDaysForComingBack(int Value)
{
    public static implicit operator int(NumberOfDaysForComingBack numberOfDaysForComingBack)
        => numberOfDaysForComingBack.Value;
}