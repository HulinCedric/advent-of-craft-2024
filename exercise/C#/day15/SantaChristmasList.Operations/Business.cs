using LanguageExt;
using LanguageExt.Common;

namespace SantaChristmasList.Operations;

public class Business(Factory factory, Inventory inventory, WishList wishList)
{
    public Sleigh LoadGiftsInSleigh(params Child[] children)
    {
        var list = new Sleigh();
        foreach (var child in children)
        {
            LoadGiftForChild(list, child);
        }

        return list;
    }

    private void LoadGiftForChild(Sleigh sleigh, Child child)
        => IdentifyGift(child)
            .Match(
                gift =>
                {
                    FindManufacturedGift(gift)
                        .Match(
                            manufacturedGift =>
                            {
                                LoadGiftFromInventory(manufacturedGift)
                                    .Match(
                                        finalGift => sleigh.Add(child, $"Gift: {finalGift.Name} has been loaded!"),
                                        failure => sleigh.Add(child, failure));
                            },
                            failure => sleigh.Add(child, failure));
                },
                failure => sleigh.Add(child, failure));

    private Either<Error, Gift> LoadGiftFromInventory(ManufacturedGift manufacturedGift)
    {
        var finalGift = inventory.PickUpGift(manufacturedGift.BarCode);
        return finalGift is not null
            ? finalGift
            : Error.New("Missing gift: The gift has probably been misplaced by the elves!");
    }

    private Either<Error, ManufacturedGift> FindManufacturedGift(Gift gift)
    {
        var manufacturedGift = factory.FindManufacturedGift(gift);
        return manufacturedGift is not null
            ? manufacturedGift
            : Error.New("Missing gift: Gift wasn't manufactured!");
    }

    private Either<Error, Gift> IdentifyGift(Child child)
    {
        var gift = wishList.IdentifyGift(child);
        return gift is not null
            ? gift
            : Error.New("Missing gift: Child wasn't nice this year!");
    }
}