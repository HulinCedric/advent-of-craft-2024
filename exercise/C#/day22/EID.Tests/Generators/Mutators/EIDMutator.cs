using FsCheck;

namespace EID.Tests.Generators.Mutators;

public record EIDMutator(string Name, Func<EID, Gen<string>> Mutate)
{
    public string Apply(EID eid) => Mutate(eid).Sample(0, 1).Head;
}