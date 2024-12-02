using static Communication.Tests.Builders.ReindeerDefaults;

namespace Communication.Tests.Builders;

public class ReindeerBuilder
{
    private string _currentLocation = NorthPole;
    private int _numberOfDaysForComingBack = SmallNumberOfDaysForComingBack;
    private string _reindeerName = Dasher;

    public static ReindeerBuilder AReindeer() => new();

    public ReindeerBuilder Named(string reindeerName)
    {
        _reindeerName = reindeerName;
        return this;
    }

    public ReindeerBuilder LocatedAt(string currentLocation)
    {
        _currentLocation = currentLocation;
        return this;
    }

    public ReindeerBuilder TakesDaysForComingBack(int numberOfDaysForComingBack)
    {
        _numberOfDaysForComingBack = numberOfDaysForComingBack;
        return this;
    }

    public static implicit operator Reindeer(ReindeerBuilder builder) => builder.Build();

    public Reindeer Build()
        => new(
            new ReindeerName(_reindeerName),
            new Location(_currentLocation),
            new NumberOfDaysForComingBack(_numberOfDaysForComingBack));
}