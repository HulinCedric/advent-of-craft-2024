namespace Travel
{
public static class SantaTravelCalculator
{
    public static ulong CalculateTotalDistance(int numberOfReindeers)
    {
        ulong distance = 0;
        for (int i = 0; i < numberOfReindeers; i++)
        {
            distance = checked(2 * distance + 1);
        }
        return distance;
    }
}
}