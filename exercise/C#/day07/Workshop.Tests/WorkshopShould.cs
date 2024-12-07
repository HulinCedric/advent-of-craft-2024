using Xunit;
using static Workshop.Tests.GiftBuilder;
using static Workshop.Tests.WorkshopBuilder;

namespace Workshop.Tests;

public class WorkshopShould
{
    private const string ToyName = "1 Super Nintendo";

    private Gift? _completedGift;
    private Workshop _workshop = null!;

    [Fact]
    public void Mark_a_gift_as_produced_when_elves_finish_making_it()
    {
        Given(AWorkshop().ThatCanProduce(AGift().Called(ToyName)));

        When(workshop => workshop.CompleteGift(ToyName));

        Then(completedGift =>
            {
                Assert.NotNull(completedGift);
                Assert.Equal(Status.Produced, completedGift.Status);
            });
    }

    [Fact]
    public void Return_no_gift_when_elves_never_started_making_it()
    {
        Given(AWorkshop());

        When(workshop => workshop.CompleteGift("NonExistingToy"));

        Then(completedGift => Assert.Null(completedGift));
    }

    private void Given(Workshop workshop) => _workshop = workshop;
    private void Then(Action<Gift?> assert) => assert(_completedGift);
    private void When(Func<Workshop, Gift?> act) => _completedGift = act(_workshop);
}