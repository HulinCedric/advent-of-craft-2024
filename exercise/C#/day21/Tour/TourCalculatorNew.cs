using LanguageExt;
using static LanguageExt.Prelude;

namespace Tour;

public class TourCalculatorNew(List<Step> steps)
{
    private readonly Seq<Step> _steps = steps.ToSeq();

    public Either<string, string> Calculate()
        => HasNotLocations()
            ? ToNoLocationsFailure()
            : ToCalculationSuccess();

    private Either<string, string> ToCalculationSuccess()
        => Right($"{TourDetails()}{DeliveryTimes()}{Environment.NewLine}");

    private static Either<string, string> ToNoLocationsFailure() => Left("No locations !!!");

    private bool HasNotLocations() => _steps.IsNull() || _steps.Count == 0;

    private string TourDetails()
        => _steps
            .OrderBy(x => x.Time)
            .Aggregate(string.Empty, (tour, step) => $"{tour}{step}{Environment.NewLine}");

    private string DeliveryTimes() => $"Delivery time | {TourDeliveryTime.From(_steps)}";
}

internal record TourDeliveryTime(int TimeInSeconds)
{
    private const string Format = @"hh\:mm\:ss";

    public override string ToString() => TimeSpan.FromSeconds(TimeInSeconds).ToString(Format);

    internal static TourDeliveryTime From(IEnumerable<Step> steps) => new(steps.Sum(s => s.DeliveryTime));
}