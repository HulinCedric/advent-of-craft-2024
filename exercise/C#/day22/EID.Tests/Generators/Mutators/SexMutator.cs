using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record SexMutator() : EIDMutator(
    "Sex mutator",
    GenerateInvalidSex)
{
    private static Gen<string> GenerateInvalidSex(EID eid)
        => Gen.OneOf(
            GenerateInvalidSexNumber(eid),
            GenerateInvalidSexChar(eid));

    private static Gen<string> GenerateInvalidSexChar(EID eid)
        => from invalidSexNumber in Arb.Default.Char()
                .Generator
                .Where(c => c != '1' && c != '2' && c != '3')
            select $"{invalidSexNumber}{eid.ToString()[1..8]}";

    private static Gen<string> GenerateInvalidSexNumber(EID eid)
        => from invalidSexNumber in Gen.Choose(4, 9)
            select $"{invalidSexNumber}{eid.ToString()[1..8]}";

    internal static EIDMutator Create() => new SexMutator();
}