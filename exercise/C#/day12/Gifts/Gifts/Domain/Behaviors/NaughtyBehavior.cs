using LanguageExt;

namespace Gifts.Domain.Behaviors;

internal class NaughtyBehavior : Behavior
{
    private const string Value = "naughty";

    internal NaughtyBehavior() : base(Value)
    {
    }

    internal override Option<Toy> GetChoice(WishList wishList) => wishList.GetThirdChoice();
}