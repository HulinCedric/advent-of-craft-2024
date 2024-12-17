using LanguageExt;

namespace EID;

public record Year
{
    private readonly int _value;

    private Year(int value) => _value = value;

    internal static Either<ParsingError, Year> Parse(string yearRepresentation)
    {
        if (!yearRepresentation.IsANumber())
            return new ParsingError("incorrect year");

        var potentialYearValue = int.Parse(yearRepresentation);

        return new Year(potentialYearValue);
    }

    public override string ToString() => Representation(_value);

    private static string Representation(int value) => $"{value:D2}";

    public static Year ParseUnsafe(int yearRepresentation)
        => Parse(Representation(yearRepresentation))
            .Match(
                year => year,
                error => throw new ArgumentException(error.Reason));
}