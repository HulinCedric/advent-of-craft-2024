namespace Workshop.Tests;

public class WorkshopBuilder
{
    private readonly List<Gift> _gifts = new();

    public static WorkshopBuilder AWorkshop() => new();

    public WorkshopBuilder WithGifts(params Gift[] gifts)
    {
        foreach (var gift in gifts)
        {
            _gifts.Add(gift);
        }

        return this;
    }

    public Workshop Build()
    {
        var workshop = new Workshop();
        foreach (var gift in _gifts)
        {
            workshop.AddGift(gift);
        }

        return workshop;
    }
}