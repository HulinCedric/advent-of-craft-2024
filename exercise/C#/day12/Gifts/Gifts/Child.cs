namespace Gifts;

public class Child
{
    private readonly Behavior _behavior;
    private WishList _wishlist;

    public Child(string name, string behavior)
    {
        Name = name;
        _behavior = new Behavior(behavior);
        _wishlist = new WishList();
    }

    internal string Name { get; }

    public void SetWishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = new WishList(firstChoice, secondChoice, thirdChoice);

    internal Toy? GetChoice() => _behavior.GetChoice(_wishlist);
}