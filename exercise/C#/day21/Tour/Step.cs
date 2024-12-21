namespace Tour;

public record Step(TimeOnly Time, string Label, int DeliveryTime)
{
    public override string ToString() => $"{Time} : {Label} | {DeliveryTime} sec";
}