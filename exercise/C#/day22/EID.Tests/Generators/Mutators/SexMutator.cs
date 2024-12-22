using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record SexMutator() : EIDMutator(
    "Sex mutator",
    MutateWithInvalidSex)
{
    private static Gen<string> MutateWithInvalidSex(EID eid)
        => GenerateInvalidSex()
            .Select(invalidSexNumber => $"{invalidSexNumber}{eid.ToString()[1..8]}");

    private static Gen<string> GenerateInvalidSex()
        => Gen.OneOf(
            GenerateInvalidSexValue(),
            GenerateInvalidSexChar());

    private static Gen<string> GenerateInvalidSexChar()
        => Arb.Default.Char()
            .Generator
            .Where(c => c != '1' && c != '2' && c != '3')
            .Select(c => $"{c}");

    private static Gen<string> GenerateInvalidSexValue()
        => Gen.Choose(4, 9)
            .Select(i => $"{i}");

    internal static EIDMutator Create() => new SexMutator();
}