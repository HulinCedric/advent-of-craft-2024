namespace Communication;

public class SantaCommunicator(int numberOfDaysToRest)
{
    public string ComposeMessage(Message message)
    {
        var daysBeforeReturn = DaysBeforeReturn(
            message.NumbersOfDaysForComingBack,
            message.NumberOfDaysBeforeChristmas);
        return
            $"Dear {message.ReindeerName}, please return from {message.CurrentLocation} in {daysBeforeReturn} day(s) to be ready and rest before Christmas.";
    }

    public bool IsOverdue(
        string reindeerName,
        string currentLocation,
        int numbersOfDaysForComingBack,
        int numberOfDaysBeforeChristmas,
        ILogger logger)
    {
        if (DaysBeforeReturn(numbersOfDaysForComingBack, numberOfDaysBeforeChristmas) <= 0)
        {
            logger.Log($"Overdue for {reindeerName} located {currentLocation}.");
            return true;
        }

        return false;
    }

    private int DaysBeforeReturn(int numbersOfDaysForComingBack, int numberOfDaysBeforeChristmas)
        => numberOfDaysBeforeChristmas - numbersOfDaysForComingBack - numberOfDaysToRest;
}