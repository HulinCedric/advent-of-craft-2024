namespace Gifts;

public class Child
{
    private WishList _wishlist;
    private readonly Behavior _behavior;
    public string Name { get; }

    public Child(string name, string behavior)
    {
        Name = name;
        _behavior = new Behavior(behavior);
        _wishlist = new WishList();
    }

    public void SetWishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = new WishList(firstChoice, secondChoice, thirdChoice);

    public Toy? GetChoice() => _wishlist.GetChoice(_behavior);
}