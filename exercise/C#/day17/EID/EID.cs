using LanguageExt;

namespace EID;

public record EID(Sex Sex, Year Year, SerialNumber SerialNumber)
{
    private const int ValidLength = 8;

    public override string ToString() => $"{Sex}{Year}{SerialNumber}{Key()}";

    private ControlKey Key() => ControlKey.KeyFor(new EIDWithoutKey(Sex, Year, SerialNumber));

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
            from controlKey in ControlKey.Validate(eidWithoutKey, input[6..8])
            select new EID(sex, year, serialNumber);
}