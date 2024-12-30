namespace Delivery;

using CalculationStrategy = Func<char, int>;

public static class Building
{
    private const char OpeningBracket = '(';
    private const char ClosingBracket = ')';
    private const string Elf = "🧝";

    public static int WhichFloor(string instructions) => instructions.Sum(DetermineCalculationStrategy(instructions));

    private static CalculationStrategy DetermineCalculationStrategy(string instructions)
        => instructions.Contains(Elf)
            ? ElfCalculationStrategy()
            : StandardCalculationStrategy();

    private static CalculationStrategy StandardCalculationStrategy()
        => instruction => instruction switch
        {
            OpeningBracket => 1,
            ClosingBracket => -1,
            _ => 0
        };

    private static CalculationStrategy ElfCalculationStrategy()
        => instruction => instruction switch
        {
            OpeningBracket => -2,
            ClosingBracket => 3,
            _ => 0
        };
}