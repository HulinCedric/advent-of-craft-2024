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
    {
        var gift = wishList.IdentifyGift(child);
        if (gift is null)
        {
            sleigh.Add(child, Error.New("Missing gift: Child wasn't nice this year!"));
            return;
        }
            
        var manufactured = factory.FindManufacturedGift(gift);
        if (manufactured is null)
        {
            sleigh.Add(child, Error.New("Missing gift: Gift wasn't manufactured!"));
            return;
        }

        var finalGift = inventory.PickUpGift(manufactured.BarCode);
        if (finalGift is null)
        {
            sleigh.Add(child, Error.New("Missing gift: The gift has probably been misplaced by the elves!"));
            return;
        }

        sleigh.Add(child, $"Gift: {finalGift.Name} has been loaded!");
    }
}