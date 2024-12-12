namespace Gifts;

public class WishList
{
    private readonly List<Toy> _wishlist;

    public WishList() => _wishlist = [];

    public WishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = [firstChoice, secondChoice, thirdChoice];

    public Toy GetThirdChoice() => _wishlist[^1];

    public Toy GetSecondChoice() => _wishlist[1];

    public Toy GetFirstChoice() => _wishlist[0];
}