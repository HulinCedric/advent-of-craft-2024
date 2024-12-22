using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record ControlKeyMutator() : EIDMutator(
    "Control key mutator",
    MutateWithInvalidSerialNumber)
{
    private static Gen<string> MutateWithInvalidSerialNumber(EID eid)
        => from invalidKey in GenerateInvalidKey(eid)
            select $"{eid.ToString()[..6]}{invalidKey:D2}";

    private static Gen<int> GenerateInvalidKey(EID eid)
        => Gen.Choose(0, 97)
            .Where(x => x != eid.Key());

    internal static EIDMutator Create() => new ControlKeyMutator();
}