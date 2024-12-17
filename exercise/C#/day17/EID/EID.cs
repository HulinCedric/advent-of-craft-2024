using LanguageExt;

namespace EID;

// ReSharper disable once InconsistentNaming
public record EID
{
    private const int ValidLength = 8;
    private readonly string _value;

    private EID(string value) => _value = value;

    public override string ToString() => _value;

    public static implicit operator string(EID eid) => eid._value;

    private static Either<ParsingError, Unit> ValidateLength(string input)
        => input.Length switch
        {
            < ValidLength => new ParsingError("too short"),
            > ValidLength => new ParsingError("too long"),
            _ => Unit.Default
        };

    public static Either<ParsingError, EID> Parse(string input)
        => from _ in ValidateLength(input)
            from sex in Sex.Parse(input[0])
            from year in Year.Parse(input[1..3])
            from serialNumber in SerialNumber.Parse(input[3..6])
            from controlKey in ControlKey.Parse(input[..6], input[6..8])
            select new EID(input);
}