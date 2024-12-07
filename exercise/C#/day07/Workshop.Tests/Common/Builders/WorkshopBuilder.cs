namespace Workshop.Tests.Common.Builders;

public class WorkshopBuilder
{
    private readonly List<Gift> _gifts = [];

    public static WorkshopBuilder AWorkshop() => new();

    public WorkshopBuilder ThatCanProduce(params Gift[] gifts)
    {
        foreach (var gift in gifts)
        {
            _gifts.Add(gift);
        }

        return this;
    }
    
    public static implicit operator Workshop(WorkshopBuilder builder) => builder.Build();

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