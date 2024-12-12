namespace Gifts;

internal class Behavior(string value)
{
    internal Toy? GetChoice(WishList wishList)
        => value switch
        {
            "naughty" => wishList.GetThirdChoice(),
            "nice" => wishList.GetSecondChoice(),
            "very nice" => wishList.GetFirstChoice(),
            _ => null
        };
}