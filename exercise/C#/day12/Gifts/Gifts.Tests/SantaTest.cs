global using Xunit;
using FluentAssertions;
using Gifts.Adapters;
using Gifts.Domain;
using Gifts.Domain.Behaviors;
using Gifts.Services;

namespace Gifts.Tests;

public class SantaTest
{
    private static readonly Toy Playstation = new("playstation");
    private static readonly Toy Ball = new("ball");
    private static readonly Toy Plush = new("plush");

    [Fact]
    public void GivenNaughtyChildWhenDistributingGiftsThenChildReceivesThirdChoice()
    {
        var bobby = new Child("bobby", Behavior.Naughty);
        bobby = bobby.SetWishList(Playstation, Plush, Ball);
        var santa = new Santa(new InMemoryChildrenRepository());
        santa.AddChild(bobby);
        var got = santa.ChooseToyForChild("bobby");

        got.Should().Be(Ball);
    }

    [Fact]
    public void GivenNiceChildWhenDistributingGiftsThenChildReceivesSecondChoice()
    {
        var bobby = new Child("bobby", Behavior.Nice);
        bobby = bobby.SetWishList(Playstation, Plush, Ball);
        var santa = new Santa(new InMemoryChildrenRepository());
        santa.AddChild(bobby);
        var got = santa.ChooseToyForChild("bobby");

        got.Should().Be(Plush);
    }

    [Fact]
    public void GivenVeryNiceChildWhenDistributingGiftsThenChildReceivesFirstChoice()
    {
        var bobby = new Child("bobby", Behavior.VeryNice);
        bobby = bobby.SetWishList(Playstation, Plush, Ball);
        var santa = new Santa(new InMemoryChildrenRepository());
        santa.AddChild(bobby);
        var got = santa.ChooseToyForChild("bobby");

        got.Should().Be(Playstation);
    }

    [Fact]
    public void GivenNonExistingChildWhenDistributingGiftsThenExceptionThrown()
    {
        var santa = new Santa(new InMemoryChildrenRepository());
        var bobby = new Child("bobby", Behavior.VeryNice);
        bobby = bobby.SetWishList(Playstation, Plush, Ball);
        santa.AddChild(bobby);

        var chooseToyForChild = () => santa.ChooseToyForChild("alice");
        chooseToyForChild.Should()
            .Throw<InvalidOperationException>()
            .WithMessage("No such child found");
    }
}