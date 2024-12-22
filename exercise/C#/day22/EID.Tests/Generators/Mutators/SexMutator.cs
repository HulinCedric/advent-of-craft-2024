using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record SexMutator() : EIDMutator(
    "Sex mutator",
    eid =>
        Arb.Default.PositiveInt()
            .Filter(i => i.Item > 3)
            .Generator
            .Select(invalidSex => invalidSex + eid.ToString()[1..8]))
{
    internal static EIDMutator Create() => new SexMutator();
}