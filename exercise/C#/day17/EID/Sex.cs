using LanguageExt;
using static LanguageExt.Prelude;

namespace EID;

public record Sex
{
    private const int SloubiSex = 1;
    private const int GagnaSex = 2;
    private const int CatactSex = 3;

    private readonly int _value;

    private Sex(int value) => _value = value;

    internal static Either<ParsingError, Sex> Parse(string sexRepresentation)
        => parseInt(sexRepresentation)
            .Match(
                Parse,
                () => new ParsingError("incorrect sex"));

    private static Either<ParsingError, Sex> Parse(int potentialSexValue)
        => potentialSexValue switch
        {
            SloubiSex => new Sex(SloubiSex),
            GagnaSex => new Sex(GagnaSex),
            CatactSex => new Sex(CatactSex),
            _ => new ParsingError("incorrect sex")
        };

    public override string ToString() => Representation(_value);

    private static string Representation(int value) => $"{value:D1}";

    public static Sex ParseUnsafe(int potentialSexValue)
        => Parse(Representation(potentialSexValue))
            .Match(
                sex => sex,
                error => throw new ArgumentException(error.Reason));
}