namespace Workshop.Tests;

public class GiftBuilder
{
    private string _name = "Some Gift";

    public static GiftBuilder AGift() => new();

    public GiftBuilder Named(string name)
    {
        _name = name;
        return this;
    }

    public Gift Build() => new(_name);
}