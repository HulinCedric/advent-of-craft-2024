using LanguageExt;

namespace Gifts;

internal class Behavior(string value)
{
    internal Option<Toy> GetChoice(WishList wishList)
        => value switch
        {
            "very nice" => wishList.GetFirstChoice(),
            "nice" => wishList.GetSecondChoice(),
            "naughty" => wishList.GetThirdChoice(),
            _ => Option<Toy>.None
        };
}