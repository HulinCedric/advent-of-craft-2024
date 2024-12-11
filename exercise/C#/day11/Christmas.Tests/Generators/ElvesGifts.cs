using FsCheck;

namespace Christmas.Tests.Generators;

public static class ElvesGifts
{
    public static Arbitrary<int> Generate() => Arb.Default.Int32().Filter(x => x is > 0 and < 50);
}