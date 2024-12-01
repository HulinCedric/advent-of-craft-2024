namespace Communication;

public record Message(
    ReindeerName ReindeerName,
    CurrentLocation CurrentLocation,
    int NumbersOfDaysForComingBack,
    int NumberOfDaysBeforeChristmas);