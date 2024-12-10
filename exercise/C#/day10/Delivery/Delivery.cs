namespace Delivery;

public static class Building
{
    public static int WhichFloor(string instructions)
    {
        if (instructions.Contains("🧝"))
            return instructions.Sum(ElfCalculationStrategy());
        return instructions.Sum(StandardCalculationStrategy());
    }

    private static Func<char, int> StandardCalculationStrategy() => c => c == '(' ? 1 : -1;

    private static Func<char, int> ElfCalculationStrategy()
        => c =>
        {
            int j;
            if (c == ')') j = 3;
            else if (c == '(') j = -2;
            else j = 0;

            return j;
        };
}