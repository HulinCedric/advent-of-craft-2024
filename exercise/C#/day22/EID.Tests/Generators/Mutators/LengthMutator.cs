using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record LengthMutator() : EIDMutator(
    "Length mutator",
    MutateWithInvalidLength)
{
    private static Gen<string> MutateWithInvalidLength(EID eid)
        => Gen.Choose(1, 6)
            .Select(size => $"{eid.ToString()[..size]}");

    internal static EIDMutator Create() => new LengthMutator();
}