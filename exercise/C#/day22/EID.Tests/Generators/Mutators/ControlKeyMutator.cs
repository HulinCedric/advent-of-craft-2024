using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record ControlKeyMutator() : EIDMutator(
    "Control key mutator",
    MutateWithInvalidControlKey)
{
    private static Gen<string> MutateWithInvalidControlKey(EID eid)
        => GenerateInvalidKey(eid)
            .Select(invalidKey => $"{eid.ToString()[..6]}{invalidKey}");

    private static Gen<string> GenerateInvalidKey(EID eid)
        => Gen.OneOf(
            GenerateDifferentControlKey(eid),
            GenerateInvalidKeyString());

    private static Gen<string> GenerateDifferentControlKey(EID eid)
        => Gen.Choose(0, 97)
            .Select(x => $"{x:d2}")
            .Where(x=> x != eid.ToString()[6..8]);

    private static Gen<string> GenerateInvalidKeyString()
        => Arb.Default.String()
            .Generator
            .Where(s => s is { Length: 2 } && !int.TryParse(s, out _));

    internal static EIDMutator Create() => new ControlKeyMutator();
}