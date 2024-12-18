using FsCheck;

namespace EID.Tests;

public static class EIDGenerator
{
    public static Arbitrary<EID> Generate()
        => (from sex in GenerateSex()
                from year in GenerateYear()
                from serialNumber in GenerateSerialNumber()
                select new EID(sex, year, serialNumber))
            .ToArbitrary();

    private static Gen<Sex> GenerateSex()
        => from value in Gen.Choose(1, 3)
            select Sex.Parse(value)
                .Match(
                    s => s,
                    error => throw new InvalidOperationException(error.Reason));

    private static Gen<Year> GenerateYear()
        => from value in Gen.Choose(0, 99)
            select Year.Parse(value)
                .Match(
                    y => y,
                    error => throw new InvalidOperationException(error.Reason));

    private static Gen<SerialNumber> GenerateSerialNumber()
        => from value in Gen.Choose(1, 999)
            select SerialNumber.Parse(value)
                .Match(
                    sn => sn,
                    error => throw new InvalidOperationException(error.Reason));
}