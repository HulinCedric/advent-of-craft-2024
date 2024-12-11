using FsCheck;

namespace Christmas.Tests.Generators.Ages;

public static class ChildAges
{
    public static Arbitrary<int> Generate() => Arb.Default.Int32().Filter(x => x is > 5 and <= 12);
}