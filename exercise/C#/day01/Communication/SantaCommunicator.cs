namespace Communication;

public class SantaCommunicator(Configuration configuration)
{
    public string ComposeMessage(Reindeer reindeer)
        => $"Dear {reindeer.Name}, please return from {reindeer.CurrentLocation} in {DaysBeforeReturn(reindeer)} day(s) to be ready and rest before Christmas.";

    public bool IsOverdue(Reindeer reindeer, ILogger logger)
    {
        if (DaysBeforeReturn(reindeer) <= 0)
        {
            logger.Log($"Overdue for {reindeer.Name} located {reindeer.CurrentLocation}.");
            return true;
        }

        return false;
    }

    private int DaysBeforeReturn(Reindeer reindeer)
        => configuration.DaysBeforeChristmas - reindeer.DaysForComingBack - configuration.DaysToRest;
}