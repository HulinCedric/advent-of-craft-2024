using Bogus;
using FluentAssertions;
using Xunit;

namespace Preparation.Tests;

public class SantaWorkshopServiceTests
{
    private const string RecommendedAge = "recommendedAge";

    private readonly Faker<PrepareGiftRequest> _faker = new Faker<PrepareGiftRequest>()
        .RuleFor(x => x.GiftName, f => f.Commerce.ProductName())
        .RuleFor(x => x.Weight, f => f.Random.Double(0, 5))
        .RuleFor(x => x.Color, f => f.Commerce.Color())
        .RuleFor(x => x.Material, f => f.Commerce.ProductMaterial());

    private readonly SantaWorkshopService _service = new();

    [Fact]
    public void PrepareGift_WithValidToy_ShouldInstantiateIt()
    {
        var request = _faker.Generate();

        _service.PrepareGift(request.GiftName, request.Weight, request.Color, request.Material)
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void RetrieveAttributeOnGift()
    {
        var request = _faker.Generate();

        var gift = _service.PrepareGift(request.GiftName, request.Weight, request.Color, request.Material);
        gift.AddAttribute(RecommendedAge, "3");

        gift.RecommendedAge()
            .Should()
            .Be(3);
    }

    [Fact]
    public void FailsForATooHeavyGift()
    {
        var request = _faker
            .Clone()
            .RuleFor(x => x.Weight, f => f.Random.Double(5, 10))
            .Generate();

        var prepareGift = () => _service.PrepareGift(request.GiftName, request.Weight, request.Color, request.Material);

        prepareGift.Should()
            .Throw<ArgumentException>()
            .WithMessage("Gift is too heavy for Santa's sleigh");
    }
}

internal class PrepareGiftRequest
{
    public required string GiftName { get; init; }
    public required double Weight { get; init; }
    public required string Color { get; init; }
    public required string Material { get; init; }
}