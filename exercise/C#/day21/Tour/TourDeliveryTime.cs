using LanguageExt;
using static System.TimeSpan;

namespace Tour;

internal record TourDeliveryTime(int TimeInSeconds)
{
    private const string Format = @"hh\:mm\:ss";

    public override string ToString() => FromSeconds(TimeInSeconds).ToString(Format);

    internal static TourDeliveryTime From(Seq<Step> steps) => new(steps.Sum(s => s.DeliveryTime));
}