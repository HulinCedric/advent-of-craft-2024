using Bogus;

namespace Preparation.Tests.Generators;

internal class PrepareTooHeavyGiftRequestGenerator : Faker<PrepareGiftRequest>
{
    public PrepareTooHeavyGiftRequestGenerator() => RuleFor(x => x.Weight, f => f.Random.Double(5, double.MaxValue));
}