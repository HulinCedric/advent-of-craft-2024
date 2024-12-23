using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record YearMutator() : EIDMutator(
    "Year mutator",
    MutateWithInvalidYear)
{
    private static Gen<string> MutateWithInvalidYear(EID eid)
        => GenerateInvalidYear()
            .Select(invalidYear => $"{eid.ToString()[..1]}{invalidYear}{eid.ToString()[3..8]}");

    private static Gen<string> GenerateInvalidYear()
        => Gen.OneOf(
            GenerateInvalidYearString(),
            GenerateInvalidYearSpace());

    private static Gen<string> GenerateInvalidYearString()
        => Arb.Default.String()
            .Generator
            .Where(s => s is { Length: 2 } && !int.TryParse(s, out _));

    private static Gen<string> GenerateInvalidYearSpace() => Gen.Choose(0, 9).Select(x => $"{x,2}");

    internal static EIDMutator Create() => new YearMutator();
}