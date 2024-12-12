using LanguageExt;

namespace Gifts;

internal class Behavior(string value)
{
    private const string VeryNice = "very nice";
    private const string Nice = "nice";
    private const string Naughty = "naughty";

    internal Option<Toy> GetChoice(WishList wishList)
        => value switch
        {
            VeryNice => wishList.GetFirstChoice(),
            Nice => wishList.GetSecondChoice(),
            Naughty => wishList.GetThirdChoice(),
            _ => Option<Toy>.None
        };
}