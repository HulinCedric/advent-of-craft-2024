namespace Communication;

public record ReindeerName(string Value)
{
    public override string ToString() => Value;
}