namespace Gifts;

public class Child
{
    private WishList _wishlist;
    private readonly string _behavior;
    public string Name { get; }

    public Child(string name, string behavior)
    {
        Name = name;
        _behavior = behavior;
        _wishlist = new WishList();
    }

    public void SetWishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = new WishList(firstChoice, secondChoice, thirdChoice);

    public Toy? GetChoice() => _wishlist.GetChoice(_behavior);
}