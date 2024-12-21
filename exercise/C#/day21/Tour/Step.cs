namespace Tour;

public record Step(TimeOnly Time, string Label, int DeliveryTime)
{
    public string Reprensentation() => $"{Time} : {Label} | {DeliveryTime} sec";
}