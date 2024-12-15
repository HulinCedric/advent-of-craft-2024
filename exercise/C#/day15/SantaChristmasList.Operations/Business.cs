using LanguageExt.Common;

namespace SantaChristmasList.Operations;

public class Business(Factory factory, Inventory inventory, WishList wishList)
{
    public Sleigh LoadGiftsInSleigh(params Child[] children)
    {
        var list = new Sleigh();
        foreach (var child in children)
        {
            var gift = wishList.IdentifyGift(child);
            if (gift is null)
            {
                list.Add(child, Error.New("Missing gift: Child wasn't nice this year!"));
                continue;
            }
            
            var manufactured = factory.FindManufacturedGift(gift);
            if (manufactured is null)
            {
                list.Add(child, Error.New("Missing gift: Gift wasn't manufactured!"));
                continue;
            }

            var finalGift = inventory.PickUpGift(manufactured.BarCode);
            if (finalGift is null)
            {
                list.Add(child, Error.New("Missing gift: The gift has probably been misplaced by the elves!"));
                continue;
            }

            list.Add(child, $"Gift: {finalGift.Name} has been loaded!");
        }
        return list;
    }
}