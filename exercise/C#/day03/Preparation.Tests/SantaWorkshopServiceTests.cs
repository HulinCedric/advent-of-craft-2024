using FluentAssertions;
using Preparation.Tests.Generators;
using Xunit;

namespace Preparation.Tests;

public class SantaWorkshopServiceTests
{
    private const string RecommendedAge = "recommendedAge";
    private readonly PrepareGiftRequestGenerator _prepareGiftRequest = new();
    private readonly PrepareTooHeavyGiftRequestGenerator _prepareTooHeavyGiftRequest = new();
    private readonly SantaWorkshopService _service = new();

    [Fact]
    public void PrepareGift_WithValidToy_ShouldInstantiateIt()
    {
        var request = _prepareGiftRequest.Generate();

        _service.PrepareGift(request.GiftName, request.Weight, request.Color, request.Material)
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void RetrieveAttributeOnGift()
    {
        var request = _prepareGiftRequest.Generate();

        var gift = _service.PrepareGift(request.GiftName, request.Weight, request.Color, request.Material);
        gift.AddAttribute(RecommendedAge, "3");

        gift.RecommendedAge()
            .Should()
            .Be(3);
    }

    [Fact]
    public void FailsForATooHeavyGift()
    {
        var request = _prepareTooHeavyGiftRequest.Generate();

        var prepareGift = () => _service.PrepareGift(request.GiftName, request.Weight, request.Color, request.Material);

        prepareGift.Should()
            .Throw<ArgumentException>()
            .WithMessage("Gift is too heavy for Santa's sleigh");
    }
}