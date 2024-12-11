using FsCheck;

namespace Christmas.Tests.Generators.Ages;

public static class ToddlerAges
{
    public static Arbitrary<int> Generate() => Arb.Default.Int32().Filter(x => x is > 2 and <= 5);
}