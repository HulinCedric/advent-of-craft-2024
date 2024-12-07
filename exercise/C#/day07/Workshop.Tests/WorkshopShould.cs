using Workshop.Tests.Common;
using Workshop.Tests.Common.Verifications;
using Xunit;
using static Workshop.Tests.Common.Builders.GiftBuilder;
using static Workshop.Tests.Common.Builders.WorkshopBuilder;

namespace Workshop.Tests;

public class WorkshopShould : UseCaseTest
{
    private const string ToyName = "1 Super Nintendo";

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
}