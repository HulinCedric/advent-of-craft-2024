using LanguageExt;

namespace Gifts;

internal class Behavior(string value)
{
    internal Option<Toy> GetChoice(WishList wishList)
        => value switch
        {
            "naughty" => wishList.GetThirdChoice(),
            "nice" => wishList.GetSecondChoice(),
            "very nice" => wishList.GetFirstChoice(),
            _ => Option<Toy>.None
        };
}