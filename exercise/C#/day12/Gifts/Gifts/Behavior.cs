using LanguageExt;

namespace Gifts;

public class Behavior(string value)
{
    private const string VeryNiceValue = "very nice";
    private const string NiceValue = "nice";
    private const string NaughtyValue = "naughty";
    
    public static readonly Behavior VeryNice = new(VeryNiceValue);
    public static readonly Behavior Nice = new(NiceValue);
    public static readonly Behavior Naughty = new(NaughtyValue);

    internal Option<Toy> GetChoice(WishList wishList)
        => value switch
        {
            VeryNiceValue => wishList.GetFirstChoice(),
            NiceValue => wishList.GetSecondChoice(),
            NaughtyValue => wishList.GetThirdChoice(),
            _ => Option<Toy>.None
        };
}
