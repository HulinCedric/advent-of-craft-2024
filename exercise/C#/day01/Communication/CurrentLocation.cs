namespace Communication;

public record CurrentLocation(string Value)
{
    public override string ToString() => Value;
}