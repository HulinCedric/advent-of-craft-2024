using System.Diagnostics.CodeAnalysis;
using FsCheck;

namespace EID.Tests.Generators;

internal static class EIDMutatorGenerator
{
    private static readonly EIDMutator SexEIDMutator = new(
        "Sex mutator",
        eid =>
            Arb.Default.PositiveInt()
                .Filter(i => i.Item > 3)
                .Generator
                .Select(invalidSex => invalidSex + eid.ToString()[1..8]));

    [SuppressMessage("FSCheck", "UnusedMember.Local", Justification = "Used by FSCheck")]
    public static Arbitrary<EIDMutator> Mutator()
        => Gen.Elements(SexEIDMutator)
            .ToArbitrary();
}