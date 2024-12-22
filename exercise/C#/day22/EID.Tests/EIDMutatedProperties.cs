using System.Diagnostics.CodeAnalysis;
using FsCheck;
using FsCheck.Xunit;

namespace EID.Tests;

public class EIDMutatedProperties
{
    [Property(Arbitrary = [typeof(EIDGenerator), typeof(MutatorGenerator)])]
    public Property InvalidEIDCanNeverBeParsed(EID eid, Mutator mutator)
        => EID.Parse(mutator.Apply(eid))
            .IsLeft
            .ToProperty()
            .Classify(true, mutator.Name);

    public record Mutator(string Name, Func<EID, Gen<string>> Mutate)
    {
        public string Apply(EID eid) => Mutate(eid).Sample(0, 1).Head;
    }

    private static class MutatorGenerator
    {
        private static readonly Mutator SexMutator = new(
            "Sex mutator",
            eid =>
                Arb.Default.PositiveInt()
                    .Filter(i => i.Item > 3)
                    .Generator
                    .Select(invalidSex => invalidSex + eid.ToString()[1..8]));

        [SuppressMessage("FSCheck", "UnusedMember.Local", Justification = "Used by FSCheck")]
        public static Arbitrary<Mutator> Mutator()
            => Gen.Elements(SexMutator)
                .ToArbitrary();
    }
}