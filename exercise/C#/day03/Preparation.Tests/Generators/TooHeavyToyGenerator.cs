namespace Preparation.Tests.Generators;

internal class TooHeavyToyGenerator : ToyGenerator
{
    public TooHeavyToyGenerator() => RuleFor(x => x.Weight, f => f.Random.Double(5, double.MaxValue));
}