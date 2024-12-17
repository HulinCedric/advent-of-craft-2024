using LanguageExt;

namespace EID;

public record EID
{
    private const int ValidLength = 8;

    private readonly ControlKey _controlKey;

    private readonly EIDWithoutKey _eidWithoutKey;

    public EID(Sex sex, Year year, SerialNumber serialNumber) : this(new EIDWithoutKey(sex, year, serialNumber))
    {
    }

    private EID(EIDWithoutKey eidWithoutKey) : this(eidWithoutKey, ControlKey.KeyFor(eidWithoutKey))
    {
    }

    private EID(EIDWithoutKey eidWithoutKey, ControlKey controlKey)
    {
        _eidWithoutKey = eidWithoutKey;
        _controlKey = controlKey;
    }

    public override string ToString() => $"{_eidWithoutKey}{_controlKey}";

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
            let eidWithoutKey = new EIDWithoutKey(sex, year, serialNumber)
            from controlKey in ControlKey.Parse(eidWithoutKey, input[6..8])
            select new EID(eidWithoutKey, controlKey);
}