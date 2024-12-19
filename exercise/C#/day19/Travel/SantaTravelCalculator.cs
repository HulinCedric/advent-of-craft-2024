namespace Travel;

public static class SantaTravelCalculator
{
    public static ulong CalculateTotalDistanceBitwise(int numberOfReindeers) => (1UL << numberOfReindeers) - 1;
    
    public static ulong CalculateTotalDistanceIterative(int numberOfReindeers)
    {
        ulong distance = 0;
        for (var i = 0; i < numberOfReindeers; i++)
        {
            distance = 2 * distance + 1;
        }

        return distance;
    }
    
    public static ulong CalculateTotalDistanceRecursively(int numberOfReindeers)
    {
        if (numberOfReindeers == 1) return 1;
        checked
        {
            return 2 * CalculateTotalDistanceRecursively(numberOfReindeers - 1) + 1;
        }
    }
}