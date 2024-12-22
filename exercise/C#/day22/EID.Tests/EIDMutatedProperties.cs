using EID.Tests.Generators;
using EID.Tests.Generators.Mutators;
using FsCheck;
using FsCheck.Xunit;

namespace EID.Tests;

public class EIDMutatedProperties
{
    [Property(Arbitrary = [typeof(EIDGenerator), typeof(EIDMutatorGenerator)])]
    public Property InvalidEIDCanNeverBeParsed(EID eid, EIDMutator eidMutator)
        => EID.Parse(eidMutator.Apply(eid))
            .IsLeft
            .ToProperty()
            .Classify(true, eidMutator.Name);
}