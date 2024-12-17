using LanguageExt;

namespace EID;

public record ControlKey
{
    private const int ControlKeyComplement = 97;

    private readonly int _value;

    private ControlKey(int value) => _value = value;

    public override string ToString() => Representation(_value);

    private static string Representation(int value) => $"{value:D2}";

    internal static Either<ParsingError, ControlKey> Parse(EIDWithoutKey eidWithoutKey, string controlKeyRepresentation)
    {
        if (!controlKeyRepresentation.IsANumber()) return new ParsingError("incorrect control key");

        var controlKeyValue = int.Parse(controlKeyRepresentation);

        if (controlKeyValue != Checksum(eidWithoutKey)) return new ParsingError("incorrect control key");

        return new ControlKey(controlKeyValue);
    }

    private static int Checksum(EIDWithoutKey eidWithoutKeyValue)
        => ControlKeyComplement - eidWithoutKeyValue.GetValue() % ControlKeyComplement;

    internal static ControlKey CreateFrom(EIDWithoutKey eidWithoutKey) => new(Checksum(eidWithoutKey));
}