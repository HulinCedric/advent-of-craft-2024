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

    private Either<Failure, Gift> IdentifyGift(Child child) => wishList.IdentifyGift(child);

    private Either<Failure, ManufacturedGift> FindManufacturedGift(Gift gift) => factory.FindManufacturedGift(gift);

    private Either<Failure, Gift> LoadGiftFromInventory(ManufacturedGift gift) => inventory.PickUpGift(gift.BarCode);

    private static Either<Failure, string> LoadGiftInSleigh(Gift gift) => $"Gift: {gift.Name} has been loaded!";
}