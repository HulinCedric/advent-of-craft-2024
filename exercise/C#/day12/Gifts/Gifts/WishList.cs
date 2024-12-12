namespace Gifts;

internal class WishList
{
    private readonly List<Toy> _wishlist;

    internal WishList() => _wishlist = [];

    internal WishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = [firstChoice, secondChoice, thirdChoice];

    internal Toy GetThirdChoice() => _wishlist[^1];

    internal Toy GetSecondChoice() => _wishlist[1];

    internal Toy GetFirstChoice() => _wishlist[0];
}