using Xunit;
using static Workshop.Tests.GiftBuilder;
using static Workshop.Tests.WorkshopBuilder;

namespace Workshop.Tests;

public class WorkshopShould
{
    private const string ToyName = "1 Super Nintendo";

    [Fact]
    public void Mark_a_gift_as_produced_when_elves_finish_making_it()
    {
        var workshop = AWorkshop().WithGifts(AGift().Named(ToyName).Build()).Build();

        var completedGift = workshop.CompleteGift(ToyName);

        Assert.NotNull(completedGift);
        Assert.Equal(Status.Produced, completedGift.Status);
    }

    [Fact]
    public void Return_no_gift_when_elves_never_started_making_it()
    {
        var workshop = AWorkshop().Build();

        var completedGift = workshop.CompleteGift("NonExistingToy");

        Assert.Null(completedGift);
    }
}