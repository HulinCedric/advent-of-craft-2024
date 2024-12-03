using Bogus;

namespace Preparation.Tests.Generators;

internal class PrepareGiftRequestGenerator : Faker<PrepareGiftRequest>
{
    public PrepareGiftRequestGenerator()
    {
        RuleFor(x => x.GiftName, f => f.Commerce.ProductName());
        RuleFor(x => x.Weight, f => f.Random.Double(0, 5));
        RuleFor(x => x.Color, f => f.Commerce.Color());
        RuleFor(x => x.Material, f => f.Commerce.ProductMaterial());
    }
}