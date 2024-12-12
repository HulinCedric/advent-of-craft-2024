namespace Gifts;

public class Child(string name, string behavior)
{
    private readonly Behavior _behavior = new(behavior);
    private readonly ChildName _childName = new(name);
    private WishList _wishlist = WishList.Empty();

    public void SetWishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = new WishList(firstChoice, secondChoice, thirdChoice);

    internal Toy? GetChoice() => _behavior.GetChoice(_wishlist);

    public bool IsNamed(ChildName childName) => _childName == childName;
}