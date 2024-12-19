using LanguageExt;
using static LanguageExt.Prelude;

namespace EID;

public record SerialNumber
{
    private const int MinimumValue = 001;
    private const int MaximumValue = 999;

    private readonly int _value;

    private SerialNumber(int value) => _value = value;

    internal static Either<ParsingError, SerialNumber> Parse(string serialNumberRepresentation)
        => parseInt(serialNumberRepresentation)
            .Match(
                Parse,
                () => new ParsingError("incorrect serial number"));

    public static Either<ParsingError, SerialNumber> Parse(int potentialSerialNumberValue)
        => potentialSerialNumberValue is >= MinimumValue and <= MaximumValue
            ? new SerialNumber(potentialSerialNumberValue)
            : new ParsingError("incorrect serial number");

    public override string ToString() => Representation(_value);

    private static string Representation(int value) => $"{value:D3}";

    public static IEnumerable<int> Values() => Range(MinimumValue, MaximumValue - MinimumValue + 1);
}