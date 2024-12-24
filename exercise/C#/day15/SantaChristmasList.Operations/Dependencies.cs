using LanguageExt;

namespace SantaChristmasList.Operations;

public class Factory : Dictionary<Gift, ManufacturedGift>
{
    public Either<Failure, ManufacturedGift> FindManufacturedGift(Gift gift)
    {
        return ContainsKey(gift) ? this[gift] : Failure.New("Missing gift: Gift wasn't manufactured!");
    }
}

public class Inventory : Dictionary<string, Gift>
{
    public Either<Failure, Gift> PickUpGift(string barCode)
    {
        return ContainsKey(barCode) ? this[barCode] : Failure.New("Missing gift: The gift has probably been misplaced by the elves!");
    }
}

public class WishList : Dictionary<Child, Gift>
{
    public Either<Failure, Gift> IdentifyGift(Child child)
    {
        return ContainsKey(child) ? this[child] : Failure.New("Missing gift: Child wasn't nice this year!");
    }
}