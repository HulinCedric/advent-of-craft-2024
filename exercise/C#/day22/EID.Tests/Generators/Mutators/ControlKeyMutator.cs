using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record ControlKeyMutator() : EIDMutator(
    "Control key mutator",
    MutateWithInvalidSerialNumber)
{
    private static Gen<string> MutateWithInvalidSerialNumber(EID eid)
        => GenerateInvalidKey(eid)
            .Select(invalidKey => $"{eid.ToString()[..6]}{invalidKey}");

    private static Gen<string> GenerateInvalidKey(EID eid)
        => Gen.OneOf(
            GenerateDifferentControlKey(eid),
            GenerateInvalidKeyString());

    private static Gen<string> GenerateDifferentControlKey(EID eid)
        => Gen.Choose(0, 97)
            .Where(x => x != eid.Key())
            .Select(x => $"{x:d2}");

    private static Gen<string> GenerateInvalidKeyString()
        => Arb.Default.String()
            .Generator
            .Where(s => s is { Length: 2 } && !int.TryParse(s, out _));

    internal static EIDMutator Create() => new ControlKeyMutator();
}