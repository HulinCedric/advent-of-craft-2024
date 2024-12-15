using LanguageExt;
using LanguageExt.Common;

namespace SantaChristmasList.Operations;

public class Business(Factory factory, Inventory inventory, WishList wishList)
{
    public Sleigh LoadGiftsInSleigh(params Child[] children)
        => new(children.ToDictionary(child => child, LoadGiftInSleighForChild));

    private Either<Error, string> LoadGiftInSleighForChild(Child child)
        => IdentifyGift(child)
            .Bind(FindManufacturedGift)
            .Bind(LoadGiftFromInventory)
            .Map(LoadGiftInSleigh);

    private Either<Error, Gift> IdentifyGift(Child child)
        => wishList.IdentifyGift(child)
            .ToEither(() => Error.New("Missing gift: Child wasn't nice this year!"));

    private Either<Error, ManufacturedGift> FindManufacturedGift(Gift gift)
        => factory.FindManufacturedGift(gift)
            .ToEither(() => Error.New("Missing gift: Gift wasn't manufactured!"));

    private Either<Error, Gift> LoadGiftFromInventory(ManufacturedGift gift)
        => inventory.PickUpGift(gift.BarCode)
            .ToEither(() => Error.New("Missing gift: The gift has probably been misplaced by the elves!"));

    private static string LoadGiftInSleigh(Gift gift) => $"Gift: {gift.Name} has been loaded!";
}