using LanguageExt;
using static LanguageExt.Prelude;

namespace EID;

public record SerialNumber
{
    private const int MinimumValue = 001;

    private readonly int _value;

    private SerialNumber(int value) => _value = value;

    internal static Either<ParsingError, SerialNumber> Parse(string serialNumberRepresentation)
        => parseInt(serialNumberRepresentation)
            .Match(
                Parse,
                () => new ParsingError("incorrect serial number"));

    public static Either<ParsingError, SerialNumber> Parse(int potentialSerialNumberValue)
        => potentialSerialNumberValue < MinimumValue
            ? new ParsingError("incorrect serial number")
            : new SerialNumber(potentialSerialNumberValue);

    public override string ToString() => Representation(_value);

    private static string Representation(int value) => $"{value:D3}";
}