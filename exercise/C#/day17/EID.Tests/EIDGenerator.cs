using FsCheck;

namespace EID.Tests;

public static class EIDGenerator
{
    public static Arbitrary<EID> Generate()
        => (from sexValue in Gen.Choose(1, 3)
                let sex = Sex.Parse(sexValue)
                    .Match(s => s, _ => throw new InvalidOperationException("Invalid Sex value"))
                from yearValue in Gen.Choose(0, 99)
                let year = Year.Parse(yearValue)
                    .Match(y => y, _ => throw new InvalidOperationException("Invalid Year value"))
                from serialNumberValue in Gen.Choose(1, 999)
                let serialNumber = SerialNumber.Parse(serialNumberValue)
                    .Match(sn => sn, _ => throw new InvalidOperationException("Invalid Serial Number value"))
                select new EID(sex, year, serialNumber)
            ).ToArbitrary();
}