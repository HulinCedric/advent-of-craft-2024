namespace Communication;

public class SantaCommunicator(NumberOfDaysToRest numberOfDaysToRest)
{
    public string ComposeMessage(
        Reindeer reindeer,
        NumbersOfDaysForComingBack numbersOfDaysForComingBack,
        NumberOfDaysBeforeChristmas numberOfDaysBeforeChristmas)
    {
        var daysBeforeReturn = DaysBeforeReturn(
            numbersOfDaysForComingBack,
            numberOfDaysBeforeChristmas);
        return
            $"Dear {reindeer.Name}, please return from {reindeer.CurrentLocation} in {daysBeforeReturn} day(s) to be ready and rest before Christmas.";
    }

    public bool IsOverdue(
        Reindeer reindeer,
        NumbersOfDaysForComingBack numbersOfDaysForComingBack,
        NumberOfDaysBeforeChristmas numberOfDaysBeforeChristmas,
        ILogger logger)
    {
        if (DaysBeforeReturn(numbersOfDaysForComingBack, numberOfDaysBeforeChristmas) <= 0)
        {
            logger.Log($"Overdue for {reindeer.Name} located {reindeer.CurrentLocation}.");
            return true;
        }

        return false;
    }

    private int DaysBeforeReturn(
        NumbersOfDaysForComingBack numbersOfDaysForComingBack,
        NumberOfDaysBeforeChristmas numberOfDaysBeforeChristmas)
        => numberOfDaysBeforeChristmas - numbersOfDaysForComingBack - numberOfDaysToRest;
}