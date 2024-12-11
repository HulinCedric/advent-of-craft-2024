using FsCheck;

namespace Christmas.Tests.Generators.NumberOfGifts;

public static class SantaGifts
{
    public static Arbitrary<int> Generate() => Arb.Default.Int32().Filter(x => x >= 50);
}