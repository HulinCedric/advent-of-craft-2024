namespace Gifts;

public class WishList
{
    private readonly List<Toy> _wishlist;

    public WishList() => _wishlist = [];

    public WishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = [firstChoice, secondChoice, thirdChoice];

    public Toy? GetChoice(Behavior behavior)
    {
        if (behavior.Value == "naughty")
            return _wishlist[^1];

        if (behavior.Value == "nice")
            return _wishlist[1];

        if (behavior.Value == "very nice")
            return _wishlist[0];

        return null;
    }
}