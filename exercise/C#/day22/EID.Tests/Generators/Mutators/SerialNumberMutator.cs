using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record SerialNumberMutator() : EIDMutator(
    "Serial number mutator",
    MutateWithInvalidSerialNumber)
{
    private static Gen<string> MutateWithInvalidSerialNumber(EID eid)
        => from invalidSerialNumber in GenerateInvalidSerialNumberString()
            select $"{eid.ToString()[..3]}{invalidSerialNumber}{eid.ToString()[6..8]}";

    private static Gen<string> GenerateInvalidSerialNumberString()
        => Arb.Default.String()
            .Generator
            .Where(s => s is { Length: 3 } && !int.TryParse(s, out _));

    internal static EIDMutator Create() => new SerialNumberMutator();
}