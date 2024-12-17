namespace EID;

public static class ValidationExtensions
{
    public static bool IsANumber(this string input) => input.All(char.IsDigit);
}