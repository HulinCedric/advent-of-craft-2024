using LanguageExt;

namespace EID;

internal record SerialNumber
{
    private const int MinimumValue = 001;

    private readonly string _value;

    private SerialNumber(string value) => _value = value;

    internal static Either<ParsingError, SerialNumber> Parse(string serialNumberDescription)
    {
        if (!(serialNumberDescription.IsANumber() &&
              int.Parse(serialNumberDescription) >= MinimumValue))
            return new ParsingError("incorrect serial number");

        return new SerialNumber(serialNumberDescription);
    }

    public override string ToString() => _value;
}