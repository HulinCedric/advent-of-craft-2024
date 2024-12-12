namespace Gifts;

public class Child
{
    public string Name { get; }
    public string Behavior { get; }
    public List<Toy> Wishlist { get; private set; }

    public Child(string name, string behavior)
    {
        Name = name;
        Behavior = behavior;
        Wishlist = [];
    }

    public void SetWishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => Wishlist = [firstChoice, secondChoice, thirdChoice];

    public Toy? GetChoice()
    {
        if (Behavior == "naughty")
            return Wishlist[^1];

        if (Behavior == "nice")
            return Wishlist[1];

        if (Behavior == "very nice")
            return Wishlist[0];

        return null;
    }
}