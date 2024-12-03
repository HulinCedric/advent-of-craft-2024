using Bogus;

namespace Preparation.Tests.Generators;

internal class TooHeavyToyGenerator : Faker<Toy>
{
    public TooHeavyToyGenerator() => RuleFor(x => x.Weight, f => f.Random.Double(5, double.MaxValue));
}