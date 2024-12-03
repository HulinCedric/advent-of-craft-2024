using FluentAssertions;
using Preparation.Tests.Generators;
using Xunit;

namespace Preparation.Tests;

public class SantaWorkshopServiceTests
{
    private const string RecommendedAge = "recommendedAge";
    private readonly ToyGenerator _toy = new();
    private readonly TooHeavyToyGenerator _tooHeavyToy = new();
    private readonly SantaWorkshopService _service = new();

    [Fact]
    public void PrepareGift_WithValidToy_ShouldInstantiateIt()
    {
        var toy = _toy.Generate();

        _service.PrepareGift(toy.Name, toy.Weight, toy.Color, toy.Material)
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void RetrieveAttributeOnGift()
    {
        var toy = _toy.Generate();

        var gift = _service.PrepareGift(toy.Name, toy.Weight, toy.Color, toy.Material);
        gift.AddAttribute(RecommendedAge, "3");

        gift.RecommendedAge()
            .Should()
            .Be(3);
    }

    [Fact]
    public void FailsForATooHeavyGift()
    {
        var toy = _tooHeavyToy.Generate();

        var prepareGift = () => _service.PrepareGift(toy.Name, toy.Weight, toy.Color, toy.Material);

        prepareGift.Should()
            .Throw<ArgumentException>()
            .WithMessage("Gift is too heavy for Santa's sleigh");
    }
}