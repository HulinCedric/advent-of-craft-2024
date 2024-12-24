using FsCheck;
using LanguageExt.UnsafeValueAccess;

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
        => from value in Gen.Elements(Sex.Values())
            select Sex.Parse(value).ValueUnsafe();

    private static Gen<Year> GenerateYear()
        => from value in Gen.Elements(Year.Values())
            select Year.Parse(value).ValueUnsafe();

    private static Gen<SerialNumber> GenerateSerialNumber()
        => from value in Gen.Elements(SerialNumber.Values())
            select SerialNumber.Parse(value).ValueUnsafe();
}