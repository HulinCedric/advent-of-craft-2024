using Bogus;
using FluentAssertions;
using Xunit;

namespace Preparation.Tests;

public class SantaWorkshopServiceTests
{
    private const string RecommendedAge = "recommendedAge";
    private readonly Faker _faker = new();
    private readonly SantaWorkshopService _service = new();

    [Fact]
    public void PrepareGift_WithValidToy_ShouldInstantiateIt()
    {
        var giftName = _faker.Commerce.ProductName();
        var weight = _faker.Random.Double(0, 5);
        var color = _faker.Commerce.Color();
        var material = _faker.Commerce.ProductMaterial();

        _service.PrepareGift(giftName, weight, color, material)
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void RetrieveAttributeOnGift()
    {
        var giftName = _faker.Commerce.ProductName();
        var weight = _faker.Random.Double(0, 5);
        var color = _faker.Commerce.Color();
        var material = _faker.Commerce.ProductMaterial();

        var gift = _service.PrepareGift(giftName, weight, color, material);
        gift.AddAttribute(RecommendedAge, "3");

        gift.RecommendedAge()
            .Should()
            .Be(3);
    }

    [Fact]
    public void FailsForATooHeavyGift()
    {
        var giftName = _faker.Commerce.ProductName();
        var weight = _faker.Random.Double(5, 10);
        var color = _faker.Commerce.Color();
        var material = _faker.Commerce.ProductMaterial();

        var prepareGift = () => _service.PrepareGift(giftName, weight, color, material);

        prepareGift.Should()
            .Throw<ArgumentException>()
            .WithMessage("Gift is too heavy for Santa's sleigh");
    }
}