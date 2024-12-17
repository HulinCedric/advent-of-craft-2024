using LanguageExt;

namespace EID;

public record EID
{
    private const int ValidLength = 8;
    private readonly ControlKey _controlKey;
    private readonly SerialNumber _serialNumber;
    private readonly Sex _sex;
    private readonly Year _year;

    private EID(Sex sex, Year year, SerialNumber serialNumber, ControlKey controlKey)
    {
        _sex = sex;
        _year = year;
        _serialNumber = serialNumber;
        _controlKey = controlKey;
    }

    public EID(Sex sex, Year year, SerialNumber serialNumber)
    {
        _sex = sex;
        _year = year;
        _serialNumber = serialNumber;
        _controlKey = ControlKey.Create($"{_sex}{_year}{_serialNumber}");
    }

    public override string ToString() => $"{_sex}{_year}{_serialNumber}{_controlKey}";

    public static implicit operator string(EID eid) => eid.ToString();

    private static Either<ParsingError, Unit> ValidateLength(string input)
        => input.Length switch
        {
            < ValidLength => new ParsingError("too short"),
            > ValidLength => new ParsingError("too long"),
            _ => Unit.Default
        };

    public static Either<ParsingError, EID> Parse(string input)
        => from _ in ValidateLength(input)
            from sex in Sex.Parse(input[0].ToString())
            from year in Year.Parse(input[1..3])
            from serialNumber in SerialNumber.Parse(input[3..6])
            from controlKey in ControlKey.Parse(input[..6], input[6..8])
            select new EID(sex, year, serialNumber, controlKey);
}