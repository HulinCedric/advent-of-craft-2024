using LanguageExt;
using static LanguageExt.Prelude;

namespace EID;

public record Year
{
    private readonly int _value;

    private Year(int value) => _value = value;

    internal static Either<ParsingError, Year> Parse(string yearRepresentation)
        => parseInt(yearRepresentation)
            .Match<Either<ParsingError, Year>>(
                yearValue => Parse(yearValue),
                () => new ParsingError("incorrect year"));

    public static Either<ParsingError, Year> Parse(int yearValue) => new Year(yearValue);

    public override string ToString() => Representation(_value);

    private static string Representation(int value) => $"{value:D2}";
}