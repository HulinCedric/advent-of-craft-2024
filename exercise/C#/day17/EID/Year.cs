using LanguageExt;

namespace EID;

internal record Year
{
    private readonly string _value;

    private Year(string value) => _value = value;

    internal static Either<ParsingError, Year> Parse(string yearDescription)
    {
        if (!yearDescription.IsANumber())
            return new ParsingError("incorrect year");

        return new Year(yearDescription);
    }

    public override string ToString() => _value;
}