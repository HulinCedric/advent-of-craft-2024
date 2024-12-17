using LanguageExt;

namespace EID;

public record SerialNumber
{
    private const int MinimumValue = 001;

    private readonly int _value;

    private SerialNumber(int value) => _value = value;

    internal static Either<ParsingError, SerialNumber> Parse(string serialNumberRepresentation)
        => serialNumberRepresentation.ToInt()
            .Match(
                Parse,
                () => new ParsingError("incorrect serial number"));

    private static Either<ParsingError, SerialNumber> Parse(int potentialSerialNumberValue)
        => potentialSerialNumberValue < MinimumValue
            ? new ParsingError("incorrect serial number")
            : new SerialNumber(potentialSerialNumberValue);

    public override string ToString() => Representation(_value);

    private static string Representation(int value) => $"{value:D3}";

    public static SerialNumber ParseUnsafe(int potentialSerialNumberValue)
        => Parse(Representation(potentialSerialNumberValue))
            .Match(
                serialNumber => serialNumber,
                error => throw new ArgumentException(error.Reason));
}