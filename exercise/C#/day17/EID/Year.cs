using LanguageExt;
using static LanguageExt.Prelude;

namespace EID;

public record Year
{
    private const int MinimumValue = 00;
    private const int MaximumValue = 99;
    private readonly int _value;

    private Year(int value) => _value = value;

    internal static Either<ParsingError, Year> Parse(string yearRepresentation)
        => parseInt(yearRepresentation)
            .Match(
                Parse,
                () => new ParsingError("incorrect year"));

    public static Either<ParsingError, Year> Parse(int yearValue)
        => yearValue is >= MinimumValue and <= MaximumValue
            ? new Year(yearValue)
            : new ParsingError("incorrect year");

    public override string ToString() => Representation(_value);

    private static string Representation(int value) => $"{value:D2}";

    public static IEnumerable<int> Values() => Range(MinimumValue, MaximumValue - MinimumValue + 1);
}