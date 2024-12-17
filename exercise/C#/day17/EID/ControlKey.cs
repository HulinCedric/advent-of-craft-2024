using LanguageExt;

namespace EID;

public record ControlKey
{
    private const int ControlKeyComplement = 97;

    private readonly string _value;

    private ControlKey(string value) => _value = value;

    public static Either<ParsingError, ControlKey> Parse(string eidWithoutKey, string controlKey)
    {
        if (!controlKey.IsANumber()) return new ParsingError("incorrect control key");

        if (int.Parse(controlKey) != Checksum(eidWithoutKey)) return new ParsingError("incorrect control key");

        return new ControlKey(controlKey);
    }

    private static int Checksum(string eidWithoutKey)
        => ControlKeyComplement - int.Parse(eidWithoutKey) % ControlKeyComplement;
}