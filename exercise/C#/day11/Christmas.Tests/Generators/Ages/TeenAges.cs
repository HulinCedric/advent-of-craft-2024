using FsCheck;

namespace Christmas.Tests.Generators.Ages;

public static class TeenAges
{
    public static Arbitrary<int> Generate() => Arb.Default.Int32().Filter(x => x > 12);
}