namespace Communication;

public class SantaCommunicator
{
    public string ComposeMessage(
        Reindeer reindeer,
        DaysBeforeReturn daysBeforeReturn)
        => $"Dear {reindeer.Name}, please return from {reindeer.CurrentLocation} in {daysBeforeReturn} day(s) to be ready and rest before Christmas.";

    public bool IsOverdue(
        Reindeer reindeer,
        DaysBeforeReturn daysBeforeReturn,
        ILogger logger)
    {
        if (daysBeforeReturn <= 0)
        {
            logger.Log($"Overdue for {reindeer.Name} located {reindeer.CurrentLocation}.");
            return true;
        }

        return false;
    }
}