using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record YearMutator() : EIDMutator(
    "Year mutator",
    MutateWithInvalidYear)
{
    private static Gen<string> MutateWithInvalidYear(EID eid)
        => from invalidYear in GenerateInvalidYear()
            select $"{eid.ToString()[..1]}{invalidYear}{eid.ToString()[3..8]}";

    private static Gen<string> GenerateInvalidYear()
        => Arb.Default.String()
            .Generator
            .Where(s => s is { Length: 2 } && !int.TryParse(s, out _));

    internal static EIDMutator Create() => new YearMutator();
}