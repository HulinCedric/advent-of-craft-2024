namespace Workshop.Tests.Common;

public class WorkshopTest
{
    private Gift? _completedGift;
    private Workshop _workshop = null!;

    protected void Given(Workshop workshop) => _workshop = workshop;
    protected void Then(Action<Gift?> assert) => assert(_completedGift);
    protected void When(Func<Workshop, Gift?> act) => _completedGift = act(_workshop);
}