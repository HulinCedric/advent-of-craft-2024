namespace Gifts.Domain;

public record ChildName(string Name)
{
    public static implicit operator ChildName(string name) => new(name);
}