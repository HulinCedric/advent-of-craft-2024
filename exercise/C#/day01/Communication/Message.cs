namespace Communication;

public record Message(
    string ReindeerName,
    string CurrentLocation,
    int NumbersOfDaysForComingBack,
    int NumberOfDaysBeforeChristmas);