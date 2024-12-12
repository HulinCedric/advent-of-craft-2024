namespace Gifts;

public record Behavior(string Value)
{
    public Toy? GetChoice(WishList wishList)
        => Value switch
        {
            "naughty" => wishList.GetThirdChoice(),
            "nice" => wishList.GetSecondChoice(),
            "very nice" => wishList.GetFirstChoice(),
            _ => null
        };
}