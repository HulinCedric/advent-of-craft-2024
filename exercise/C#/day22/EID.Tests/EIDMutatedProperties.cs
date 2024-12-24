using EID.Tests.Generators;
using EID.Tests.Generators.Mutators;
using FsCheck;
using FsCheck.Xunit;

namespace EID.Tests;

public class EIDMutatedProperties
{
    [Property(Arbitrary = [typeof(EIDGenerator), typeof(EIDMutatorGenerator)])]
    public Property InvalidEIDCanNeverBeParsed(EID eid, EIDMutator eidMutator)
    {
        var mutatedEid = eidMutator.Apply(eid);
        return EID.Parse(mutatedEid)
            .IsLeft
            .ToProperty()
            .Label($"Mutated EID: {mutatedEid}")
            .Classify(true, eidMutator.Name);
    }
}