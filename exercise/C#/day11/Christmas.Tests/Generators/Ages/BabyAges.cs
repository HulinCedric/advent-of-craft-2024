using FsCheck;

namespace Christmas.Tests.Generators.Ages;

public static class BabyAges
{
    public static Arbitrary<int> Generate() => Arb.Default.Int32().Filter(x => x <= 2);
}