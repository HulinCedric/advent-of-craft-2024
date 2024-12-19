namespace Travel;

public static class SantaTravelCalculator
{
    public static ulong CalculateTotalDistance(int numberOfReindeers) => (1UL << numberOfReindeers) - 1;
}