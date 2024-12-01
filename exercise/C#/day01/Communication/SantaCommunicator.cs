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
        Message message,
        ILogger logger)
    {
        if (DaysBeforeReturn(message.NumbersOfDaysForComingBack, message.NumberOfDaysBeforeChristmas) <= 0)
        {
            logger.Log($"Overdue for {message.ReindeerName} located {message.CurrentLocation}.");
            return true;
        }

        return false;
    }

    private int DaysBeforeReturn(NumbersOfDaysForComingBack numbersOfDaysForComingBack, int numberOfDaysBeforeChristmas)
        => numberOfDaysBeforeChristmas - numbersOfDaysForComingBack - numberOfDaysToRest;
}