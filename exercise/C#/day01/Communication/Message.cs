namespace Communication;

public record Message(
    ReindeerName ReindeerName,
    CurrentLocation CurrentLocation,
    NumbersOfDaysForComingBack NumbersOfDaysForComingBack,
    int NumberOfDaysBeforeChristmas);