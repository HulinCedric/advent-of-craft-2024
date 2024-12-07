using Workshop.Tests.Verifications;
using Xunit;
using static Workshop.Tests.Builders.GiftBuilder;
using static Workshop.Tests.Builders.WorkshopBuilder;

namespace Workshop.Tests;

public class WorkshopShould
{
    private const string ToyName = "1 Super Nintendo";

    private Gift? _completedGift;
    private Workshop _workshop = null!;

    [Fact]
    public void Produced_gift_when_completing_an_existing_gift()
    {
        Given(AWorkshop().ThatCanProduce(AGift().Called(ToyName)));

        When(workshop => workshop.CompleteGift(ToyName));

        Then(gift => gift.Should().BeProduced());
    }

    [Fact]
    public void Not_produced_gift_when_completing_a_non_existing_gift()
    {
        Given(AWorkshop());

        When(workshop => workshop.CompleteGift("NonExistingToy"));

        Then(gift => gift.Should().BeNotProduced());
    }

    private void Given(Workshop workshop) => _workshop = workshop;
    private void Then(Action<Gift?> assert) => assert(_completedGift);
    private void When(Func<Workshop, Gift?> act) => _completedGift = act(_workshop);
}