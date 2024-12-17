using LanguageExt;

namespace EID;

// ReSharper disable once InconsistentNaming
public record EID
{
    private const int ControlKeyComplement = 97;
    private const int ValidLength = 8;
    private const int MinimumSerialNumberValue = 001;
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
    
    private static bool ValidateYear(string year) => year.IsANumber();

    private static bool ValidateSerialNumber(string serialNumber)
        => serialNumber.IsANumber() &&
           int.Parse(serialNumber) >= MinimumSerialNumberValue;

    private static bool ValidateControlKey(string eidWithoutKey, string controlKey)
    {
        if (!controlKey.IsANumber()) return false;

        return int.Parse(controlKey) == Checksum(eidWithoutKey);
    }

    private static int Checksum(string eidWithoutKey)
        => ControlKeyComplement - int.Parse(eidWithoutKey) % ControlKeyComplement;

    public static Either<ParsingError, EID> Parse(string input)
        => ValidateLength(input)
            .Bind(_ => Sex.Parse(input[0]))
            .Bind(_ => ContinueParse(input));

    private static Either<ParsingError, EID> ContinueParse(string input)
    {
        if (!(ValidateYear(input[1..3])
              && ValidateSerialNumber(input[3..6])
              && ValidateControlKey(input[..6], input[6..8])))
            return new ParsingError("unknown reason");

        return new EID(input);
    }
}

internal record Sex
{
    private const char SloubiSex = '1';
    private const char GagnaSex = '2';
    private const char CatactSex = '3';

    private readonly char _value;

    private Sex(char value) => _value = value;

    public static Either<ParsingError, Sex> Parse(char sexDescription)
        => sexDescription switch
        {
            SloubiSex => new Sex(SloubiSex),
            GagnaSex => new Sex(GagnaSex),
            CatactSex => new Sex(CatactSex),
            _ => new ParsingError("incorrect sex")
        };
}

public record ParsingError(string Reason);