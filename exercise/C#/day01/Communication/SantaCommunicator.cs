namespace Communication;

public class SantaCommunicator(NumberOfDaysToRest numberOfDaysToRest)
{
    public string ComposeMessage(
        Reindeer reindeer,
        DaysBeforeReturn daysBeforeReturn_New)
    {
        var daysBeforeReturn = DaysBeforeReturn(
            daysBeforeReturn_New.NumbersOfDaysForComingBack,
            daysBeforeReturn_New.NumberOfDaysBeforeChristmas);
        return
            $"Dear {reindeer.Name}, please return from {reindeer.CurrentLocation} in {daysBeforeReturn} day(s) to be ready and rest before Christmas.";
    }

    public bool IsOverdue(
        Reindeer reindeer,
        DaysBeforeReturn daysBeforeReturn,
        ILogger logger)
    {
        if (DaysBeforeReturn(
                daysBeforeReturn.NumbersOfDaysForComingBack,
                daysBeforeReturn.NumberOfDaysBeforeChristmas) <= 0)
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