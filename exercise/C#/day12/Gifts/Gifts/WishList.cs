namespace Gifts;

internal class WishList
{
    private readonly List<Toy> _wishlist;

    private WishList() => _wishlist = [];

    internal WishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = [firstChoice, secondChoice, thirdChoice];

    internal static WishList Empty() => new();

    internal Toy? GetThirdChoice() => _wishlist.Count <= 2 ? null : _wishlist[2];

    internal Toy? GetSecondChoice() => _wishlist.Count <= 1 ? null : _wishlist[1];

    internal Toy? GetFirstChoice() => _wishlist.Count <= 0 ? null : _wishlist[0];
}