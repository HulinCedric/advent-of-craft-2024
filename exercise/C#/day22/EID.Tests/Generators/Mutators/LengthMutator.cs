using FsCheck;

namespace EID.Tests.Generators.Mutators;

internal record LengthMutator() : EIDMutator(
    "Length mutator",
    MutateWithInvalidLength)
{
    private static Gen<string> MutateWithInvalidLength(EID eid)
        => Gen.OneOf(
            TruncationMutation(eid),
            AdditionMutation(eid));

    private static Gen<string> AdditionMutation(EID eid)
        => Gen.Choose(1, 1000)
            .Select(number => $"{eid.ToString()}{number}");

    private static Gen<string> TruncationMutation(EID eid)
        => Gen.Choose(1, 7)
            .Select(size => $"{eid.ToString()[..size]}");

    internal static EIDMutator Create() => new LengthMutator();
}