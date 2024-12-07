namespace Workshop.Tests.Builders;

public class GiftBuilder
{
    private string _name = "Some Gift";

    public static GiftBuilder AGift() => new();

    public GiftBuilder Called(string name)
    {
        _name = name;
        return this;
    }
    
    public static implicit operator Gift(GiftBuilder builder) => builder.Build();

    public Gift Build() => new(_name);
}