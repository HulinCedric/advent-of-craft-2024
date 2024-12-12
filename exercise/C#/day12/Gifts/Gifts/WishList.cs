namespace Gifts;

public class WishList
{
    private readonly List<Toy> _wishlist;

    public WishList() => _wishlist = [];

    public WishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = [firstChoice, secondChoice, thirdChoice];

    public Toy? GetChoice(Behavior behavior)
        => behavior.Value switch
        {
            "naughty" => _wishlist[^1],
            "nice" => _wishlist[1],
            "very nice" => _wishlist[0],
            _ => null
        };
}