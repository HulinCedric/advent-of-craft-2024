using Xunit;

namespace Workshop.Tests;

public class WorkshopShould
{
    private const string ToyName = "1 Super Nintendo";

    [Fact]
    public void Mark_a_gift_as_produced_when_elves_finish_making_it()
    {
        var workshop = new Workshop();
        var gift = new Gift(ToyName);
        workshop.AddGift(gift);

        var completedGift = workshop.CompleteGift(ToyName);

        Assert.NotNull(completedGift);
        Assert.Equal(Status.Produced, completedGift.Status);
    }

    [Fact]
    public void Return_no_gift_when_elves_never_started_making_it()
    {
        var workshop = new Workshop();

        var completedGift = workshop.CompleteGift("NonExistingToy");

        Assert.Null(completedGift);
    }
}