using LanguageExt;

namespace Gifts;

public class Behavior(string value)
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
    
    public static implicit operator Behavior(string value) => new(value);
}