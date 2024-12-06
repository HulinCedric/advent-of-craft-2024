namespace EID;

// ReSharper disable once InconsistentNaming
public static class EIDValidator
{
    private const char Sloubi = '1';
    private const char Gagna = '2';
    private const char Catact = '3';

    public static bool Validate(string input)
        => ValidateLength(input)
           && ValidateSex(input[0])
           && ValidateYear(input[1..3])
           && ValidateSerialNumber(input[3..6])
           && ValidateControlKey(input[..6], input[6..8]);

    private static bool ValidateLength(string input) => input.Length == 8;
    private static bool ValidateSex(char sex) => sex is Sloubi or Gagna or Catact;
    private static bool ValidateYear(string year) => year.IsANumber();

    private static bool ValidateSerialNumber(string serialNumber)
        => serialNumber.IsANumber() && int.Parse(serialNumber) is >= 1 and <= 999;

    private static bool ValidateControlKey(string eidWithoutKey, string controlKey)
    {
        if (!controlKey.IsANumber()) return false;

        var key = int.Parse(controlKey);

        var checksum = 97 - int.Parse(eidWithoutKey) % 97;

        return key == checksum;
    }
}