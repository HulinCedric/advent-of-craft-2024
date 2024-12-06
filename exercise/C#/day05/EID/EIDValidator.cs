namespace EID;

// ReSharper disable once InconsistentNaming
public static class EIDValidator
{
    public static bool Validate(string input)
        => ValidateLength(input)
           && ValidateSex(input[0])
           && ValidateYear(input[1..3])
           && ValidateSerialNumber(input[3..6])
           && ValidateControlKey(input[..6], input[6..8]);

    private static bool ValidateLength(string input) => input.Length == 8;
    private static bool ValidateSex(char sex) => sex is '1' or '2' or '3';
    private static bool ValidateYear(string year) => IsANumber(year);

    private static bool ValidateSerialNumber(string serialNumber)
        => IsANumber(serialNumber) && int.Parse(serialNumber) is >= 1 and <= 999;

    private static bool ValidateControlKey(string eidWithoutKey, string controlKey)
    {
        if (!IsANumber(controlKey)) return false;

        var key = int.Parse(controlKey);

        var checksum = 97 - int.Parse(eidWithoutKey) % 97;

        return key == checksum;
    }

    private static bool IsANumber(string input) => input.All(char.IsDigit);
}