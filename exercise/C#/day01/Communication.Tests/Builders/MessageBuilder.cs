using static Communication.Tests.Builders.MessageDefaults;

namespace Communication.Tests.Builders;

public class MessageBuilder
{
    private string _currentLocation = NorthPole;
    private int _numberOfDaysBeforeChristmas = NumberOfDayBeforeChristmas;
    private int _numbersOfDaysForComingBack = NumberOfDaysToRest;
    private string _reindeerName = Dasher;

    public static MessageBuilder AMessage() => new();

    public MessageBuilder WithReindeerName(string reindeerName)
    {
        _reindeerName = reindeerName;
        return this;
    }

    public MessageBuilder WithCurrentLocation(string currentLocation)
    {
        _currentLocation = currentLocation;
        return this;
    }

    public MessageBuilder WithNumbersOfDaysForComingBack(int numbersOfDaysForComingBack)
    {
        _numbersOfDaysForComingBack = numbersOfDaysForComingBack;
        return this;
    }

    public MessageBuilder WithNumberOfDaysBeforeChristmas(int numberOfDaysBeforeChristmas)
    {
        _numberOfDaysBeforeChristmas = numberOfDaysBeforeChristmas;
        return this;
    }

    public MessageBuilder Overdue()
        => WithNumbersOfDaysForComingBack(NumberOfDayBeforeChristmas)
            .WithNumberOfDaysBeforeChristmas(NumberOfDayBeforeChristmas);

    public static implicit operator Message(MessageBuilder builder) => builder.Build();

    public Message Build()
        => new(
            new ReindeerName(_reindeerName),
            new CurrentLocation(_currentLocation),
            new NumbersOfDaysForComingBack(_numbersOfDaysForComingBack),
            new NumberOfDaysBeforeChristmas(_numberOfDaysBeforeChristmas));
}