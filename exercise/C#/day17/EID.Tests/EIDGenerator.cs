using FsCheck;

namespace EID.Tests;

public static class EIDGenerator
{
    public static Arbitrary<EID> Generate()
        => (from sex in Gen.Choose(1, 3)
                from year in Gen.Choose(0, 99)
                from serialNumber in Gen.Choose(1, 999)
                select new EID(
                    Sex.ParseUnsafe(sex),
                    Year.ParseUnsafe(year),
                    SerialNumber.ParseUnsafe(serialNumber))
            ).ToArbitrary();
}