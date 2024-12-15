using LanguageExt;
using LanguageExt.Common;

namespace SantaChristmasList.Operations;

public class Business(Factory factory, Inventory inventory, WishList wishList)
{
    public Sleigh LoadGiftsInSleigh(params Child[] children)
        => new(children.ToDictionary(child => child, LoadGiftForChild));

    private Either<Error, string> LoadGiftForChild(Child child)
        => IdentifyGift(child)
            .Bind(FindManufacturedGift)
            .Bind(LoadGiftFromInventory)
            .Map(LoadToSleigh);

    private Either<Error, Gift> IdentifyGift(Child child)
        => wishList.IdentifyGift(child)
            .ToEither(() => Error.New("Missing gift: Child wasn't nice this year!"));

    private Either<Error, ManufacturedGift> FindManufacturedGift(Gift gift)
        => factory.FindManufacturedGift(gift)
            .ToEither(() => Error.New("Missing gift: Gift wasn't manufactured!"));

    private Either<Error, Gift> LoadGiftFromInventory(ManufacturedGift manufactured)
        => inventory.PickUpGift(manufactured.BarCode)
            .ToEither(() => Error.New("Missing gift: The gift has probably been misplaced by the elves!"));

    private static string LoadToSleigh(Gift loadedGift) => $"Gift: {loadedGift.Name} has been loaded!";
}