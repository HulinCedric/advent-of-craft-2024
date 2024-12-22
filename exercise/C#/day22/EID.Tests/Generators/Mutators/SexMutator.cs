using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record SexMutator() : EIDMutator(
    "Sex mutator",
    eid => Gen.Choose(4, 9)
        .Select(invalidSex => invalidSex + eid.ToString()[1..8]))
{
    internal static EIDMutator Create() => new SexMutator();
}