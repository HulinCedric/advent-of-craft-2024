namespace Gifts;

public class WishList
{
    private readonly List<Toy> _wishlist;

    public WishList() => _wishlist = [];

    public WishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = [firstChoice, secondChoice, thirdChoice];

    public Toy? GetChoice(string behavior)
    {
        if (behavior == "naughty")
            return _wishlist[^1];

        if (behavior == "nice")
            return _wishlist[1];

        if (behavior == "very nice")
            return _wishlist[0];

        return null;
    }
}