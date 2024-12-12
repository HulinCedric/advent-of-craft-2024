namespace Gifts;

public class Child
{
    private List<Toy> _wishlist;
    private readonly string _behavior;
    public string Name { get; }

    public Child(string name, string behavior)
    {
        Name = name;
        _behavior = behavior;
        _wishlist = [];
    }

    public void SetWishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = [firstChoice, secondChoice, thirdChoice];

    public Toy? GetChoice()
    {
        if (_behavior == "naughty")
            return _wishlist[^1];

        if (_behavior == "nice")
            return _wishlist[1];

        if (_behavior == "very nice")
            return _wishlist[0];

        return null;
    }
}