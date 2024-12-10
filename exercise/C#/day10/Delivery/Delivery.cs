namespace Delivery;

using CalculationStrategy = Func<char, int>;

public static class Building
{
    public static int WhichFloor(string instructions) => instructions.Sum(DetermineCalculationStrategy(instructions));

    private static CalculationStrategy DetermineCalculationStrategy(string instructions)
        => instructions.Contains("🧝")
            ? ElfCalculationStrategy()
            : StandardCalculationStrategy();

    private static CalculationStrategy StandardCalculationStrategy()
        => instruction => instruction switch
        {
            '(' => 1,
            ')' => -1,
            _ => 0
        };

    private static CalculationStrategy ElfCalculationStrategy()
        => instruction => instruction switch
        {
            '(' => -2,
            ')' => 3,
            _ => 0
        };
}