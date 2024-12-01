namespace Communication;

public record Message(
    ReindeerName ReindeerName,
    string CurrentLocation,
    int NumbersOfDaysForComingBack,
    int NumberOfDaysBeforeChristmas);