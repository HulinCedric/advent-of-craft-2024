using System.Diagnostics.CodeAnalysis;
using EID.Tests.Generators.Mutators;
using FsCheck;
using LanguageExt.UnitsOfMeasure;

namespace EID.Tests.Generators;

internal static class EIDMutatorGenerator
{
    [SuppressMessage("FSCheck", "UnusedMember.Local", Justification = "Used by FSCheck")]
    public static Arbitrary<EIDMutator> Mutator()
        => Gen.Elements(
                SexMutator.Create(),
                YearMutator.Create(),
                SerialNumberMutator.Create(),
                ControlKeyMutator.Create(),
                LengthMutator.Create())
            .ToArbitrary();
}