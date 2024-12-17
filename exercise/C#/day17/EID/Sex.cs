using LanguageExt;

namespace EID;

internal record Sex
{
    private const char SloubiSex = '1';
    private const char GagnaSex = '2';
    private const char CatactSex = '3';

    private readonly char _value;

    private Sex(char value) => _value = value;

    internal static Either<ParsingError, Sex> Parse(char sexDescription)
        => sexDescription switch
        {
            SloubiSex => new Sex(SloubiSex),
            GagnaSex => new Sex(GagnaSex),
            CatactSex => new Sex(CatactSex),
            _ => new ParsingError("incorrect sex")
        };
}