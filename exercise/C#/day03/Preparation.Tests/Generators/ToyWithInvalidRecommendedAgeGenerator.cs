namespace Preparation.Tests.Generators;

internal class ToyWithInvalidRecommendedAgeGenerator : ToyGenerator
{
    public ToyWithInvalidRecommendedAgeGenerator() => RuleFor(x => x.RecommendedAge, f => f.Random.String());
}