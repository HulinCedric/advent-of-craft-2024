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

    private static string LoadToSleigh(Gift loadedGift) => $"Gift: {loadedGift.Name} has been loaded!";

    private Either<Error, Gift> LoadGiftFromInventory(ManufacturedGift manufacturedGift)
        => inventory.PickUpGift(manufacturedGift.BarCode)
            .Match(
                Either<Error, Gift>.Right,
                () => Error.New("Missing gift: The gift has probably been misplaced by the elves!"));

    private Either<Error, ManufacturedGift> FindManufacturedGift(Gift gift)
        => factory.FindManufacturedGift(gift)
            .Match(
                Either<Error, ManufacturedGift>.Right,
                () => Error.New("Missing gift: Gift wasn't manufactured!"));

    private Either<Error, Gift> IdentifyGift(Child child)
    {
        var gift = wishList.IdentifyGift(child);
        return gift is not null
            ? gift
            : Error.New("Missing gift: Child wasn't nice this year!");
    }
}