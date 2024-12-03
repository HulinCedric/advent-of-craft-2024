using Bogus;

namespace Preparation.Tests.Generators;

internal class ToyGenerator : Faker<Toy>
{
    public ToyGenerator()
    {
        RuleFor(x => x.Name, f => f.Commerce.ProductName());
        RuleFor(x => x.Weight, f => f.Random.Double(0, 5));
        RuleFor(x => x.Color, f => f.Commerce.Color());
        RuleFor(x => x.Material, f => f.Commerce.ProductMaterial());
    }
}