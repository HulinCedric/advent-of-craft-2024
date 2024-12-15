using LanguageExt;

namespace SantaChristmasList.Operations;

public class Business(Factory factory, Inventory inventory, WishList wishList)
{
    public Sleigh LoadGiftsInSleigh(params Child[] children)
        => new(children.ToDictionary(child => child, LoadGiftInSleighForChild));

    private Either<Failure, string> LoadGiftInSleighForChild(Child child)
        => IdentifyGift(child)
            .Bind(FindManufacturedGift)
            .Bind(LoadGiftFromInventory)
            .Bind(LoadGiftInSleigh);

    private Either<Failure, Gift> IdentifyGift(Child child)
        => wishList.IdentifyGift(child)
            .ToEither(() => Failure.New("Missing gift: Child wasn't nice this year!"));

    private Either<Failure, ManufacturedGift> FindManufacturedGift(Gift gift)
        => factory.FindManufacturedGift(gift)
            .ToEither(() => Failure.New("Missing gift: Gift wasn't manufactured!"));

    private Either<Failure, Gift> LoadGiftFromInventory(ManufacturedGift gift)
        => inventory.PickUpGift(gift.BarCode)
            .ToEither(() => Failure.New("Missing gift: The gift has probably been misplaced by the elves!"));

    private static Either<Failure, string> LoadGiftInSleigh(Gift gift) => $"Gift: {gift.Name} has been loaded!";
}