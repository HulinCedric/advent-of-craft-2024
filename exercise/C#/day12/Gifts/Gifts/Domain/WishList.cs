using LanguageExt;

namespace Gifts.Domain;

internal class WishList
{
    private readonly Seq<Toy> _wishlist;

    private WishList() => _wishlist = Seq<Toy>.Empty;

    internal WishList(Toy firstChoice, Toy secondChoice, Toy thirdChoice)
        => _wishlist = new Seq<Toy>([firstChoice, secondChoice, thirdChoice]);

    internal static WishList Empty() => new();

    internal Option<Toy> GetFirstChoice() => _wishlist.At(0);
    
    internal Option<Toy> GetSecondChoice() => _wishlist.At(1);
    
    internal Option<Toy> GetThirdChoice() => _wishlist.At(2);
}