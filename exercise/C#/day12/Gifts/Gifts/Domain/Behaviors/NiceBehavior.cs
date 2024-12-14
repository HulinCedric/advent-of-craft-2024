using LanguageExt;

namespace Gifts.Domain.Behaviors;

internal class NiceBehavior : Behavior
{
    private const string Value = "nice";

    internal NiceBehavior() : base(Value)
    {
    }

    internal override Option<Toy> GetChoice(WishList wishList) => wishList.GetSecondChoice();
}