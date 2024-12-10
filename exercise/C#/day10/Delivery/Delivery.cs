namespace Delivery;

public static class Building
{
    public static int WhichFloor(string instructions) => instructions.Sum(DetermineCalculationStrategy(instructions));

    private static Func<char, int> DetermineCalculationStrategy(string instructions)
        => instructions.Contains("🧝")
            ? ElfCalculationStrategy()
            : StandardCalculationStrategy();

    private static Func<char, int> StandardCalculationStrategy()
        => instruction => instruction switch
        {
            '(' => 1,
            ')' => -1,
            _ => 0
        };

    private static Func<char, int> ElfCalculationStrategy()
        => instruction => instruction switch
        {
            '(' => -2,
            ')' => 3,
            _ => 0
        };
}