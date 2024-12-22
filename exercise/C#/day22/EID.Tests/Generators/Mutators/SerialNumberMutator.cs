using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record SerialNumberMutator() : EIDMutator(
    "Serial number mutator",
    MutateWithInvalidSerialNumber)
{
    private static Gen<string> MutateWithInvalidSerialNumber(EID eid)
        => GenerateInvalidSerialNumber()
            .Select(invalidSerialNumber => $"{eid.ToString()[..3]}{invalidSerialNumber}{eid.ToString()[6..8]}");

    private static Gen<string> GenerateInvalidSerialNumber()
        => Gen.OneOf(
            GenerateInvalidSerialNumberString(),
            GenerateInvalidSerialNumberValue());

    private static Gen<string> GenerateInvalidSerialNumberString()
        => Arb.Default.String()
            .Generator
            .Where(x => x is { Length: 3 } && !int.TryParse(x, out _));

    private static Gen<string> GenerateInvalidSerialNumberValue() => Gen.Elements(0).Select(x => $"{x:d3}");

    internal static EIDMutator Create() => new SerialNumberMutator();
}