using LanguageExt;

namespace EID;

// ReSharper disable once InconsistentNaming
public record EID
{
    private const char SloubiSex = '1';
    private const char GagnaSex = '2';
    private const char CatactSex = '3';
    private const int ControlKeyComplement = 97;
    private const int ValidLength = 8;
    private const int MinimumSerialNumberValue = 001;
    private readonly string _value;

    private EID(string value) => _value = value;

    public override string ToString() => _value;

    public static implicit operator string(EID eid) => eid._value;

    private static bool ValidateLength(string input) => input.Length == ValidLength;

    private static bool ValidateSex(char sex) => sex is SloubiSex or GagnaSex or CatactSex;

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
    {
        if (input.Length < ValidLength)
            return new ParsingError("too short");
        
        if (!(ValidateLength(input)
              && ValidateSex(input[0])
              && ValidateYear(input[1..3])
              && ValidateSerialNumber(input[3..6])
              && ValidateControlKey(input[..6], input[6..8])))
            return new ParsingError("unknown reason");

        return new EID(input);
    }
}

public record ParsingError(string Reason);