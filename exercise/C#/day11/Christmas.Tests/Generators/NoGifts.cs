using FsCheck;

namespace Christmas.Tests.Generators;

public static class NoGifts
{
    public static Arbitrary<int> Generate() => Arb.Default.Int32().Filter(x => x <= 0);
}