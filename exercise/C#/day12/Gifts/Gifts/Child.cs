namespace Gifts;

public class Child
{
    private readonly Behavior _behavior;
    private readonly ChildName _childName;
    private WishList _wishlist;

    public Child(string name, string behavior)
    {
        _childName = new ChildName(name);
        _behavior = new Behavior(behavior);
        _wishlist = WishList.Empty();
    }

    public void SetWishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = new WishList(firstChoice, secondChoice, thirdChoice);

    internal Toy? GetChoice() => _behavior.GetChoice(_wishlist);

    public bool IsNamed(ChildName childName) => _childName == childName;
}