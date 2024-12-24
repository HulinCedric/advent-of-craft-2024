namespace Tour;

internal record TourDeliveryTime(int TimeInSeconds)
{
    private const string Format = @"hh\:mm\:ss";

    public override string ToString() => TimeSpan.FromSeconds(TimeInSeconds).ToString(Format);

    internal static TourDeliveryTime From(IEnumerable<Step> steps) => new(steps.Sum(s => s.DeliveryTime));
}