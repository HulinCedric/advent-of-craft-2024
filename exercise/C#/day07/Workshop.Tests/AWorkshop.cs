using Workshop.Tests.Common;
using Workshop.Tests.Common.Verifications;
using Xunit;
using static Workshop.Tests.Common.Builders.GiftBuilder;
using static Workshop.Tests.Common.Builders.WorkshopBuilder;

namespace Workshop.Tests;

public class AWorkshop : WorkshopTest
{
    private const string ToyName = "1 Super Nintendo";

    [Fact]
    public void Can_produce_a_well_known_gift()
    {
        Given(AWorkshop().ThatCanProduce(AGift().Called(ToyName)));

        When(workshop => workshop.CompleteGift(ToyName));

        Then(gift => gift.Should().BeProduced());
    }

    [Fact]
    public void Cannot_produce_an_unknown_gift()
    {
        Given(AWorkshop());

        When(workshop => workshop.CompleteGift("NonExistingToy"));

        Then(gift => gift.Should().NotBeProduced());
    }
}