using LanguageExt;
using static LanguageExt.Prelude;

namespace EID;

internal record ControlKey
{
    private const int ControlKeyComplement = 97;

    private readonly int _value;

    private ControlKey(int value) => _value = value;

    public override string ToString() => Representation(_value);

    private static string Representation(int value) => $"{value:D2}";

    internal static Either<ParsingError, ControlKey> Parse(EIDWithoutKey eidWithoutKey, string controlKeyRepresentation)
        => parseInt(controlKeyRepresentation)
            .Match(
                controlKeyValue => Parse(eidWithoutKey, controlKeyValue),
                () => new ParsingError("incorrect control key"));

    private static Either<ParsingError, ControlKey> Parse(EIDWithoutKey eidWithoutKey, int potentialControlKeyValue)
        => potentialControlKeyValue != Checksum(eidWithoutKey)
            ? new ParsingError("incorrect control key")
            : new ControlKey(potentialControlKeyValue);

    private static int Checksum(EIDWithoutKey eidWithoutKeyValue)
        => ControlKeyComplement - eidWithoutKeyValue.GetValue() % ControlKeyComplement;

    internal static ControlKey KeyFor(EIDWithoutKey eidWithoutKey) => new(Checksum(eidWithoutKey));
}