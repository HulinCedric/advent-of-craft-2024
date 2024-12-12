using LanguageExt;

namespace Gifts;

public class Child(ChildName name, Behavior behavior)
{
    private WishList _wishlist = WishList.Empty();

    public void SetWishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = new WishList(firstChoice, secondChoice, thirdChoice);

    internal Option<Toy> GetChoice() => behavior.GetChoice(_wishlist);

    internal bool IsNamed(ChildName childName) => name == childName;
}