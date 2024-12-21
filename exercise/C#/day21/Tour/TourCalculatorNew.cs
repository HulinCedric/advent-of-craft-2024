using System.Text;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Tour;

public class TourCalculatorNew(List<Step> steps)
{
    private readonly Seq<Step> _steps = steps.ToSeq();

    public Either<string, string> Calculate()
    {
        if (_steps.IsNull() || _steps.Count == 0)
        {
            return Left("No locations !!!");
        }

        return Right($"{TourDetails()}{TourDeliveryTime()}{Environment.NewLine}");
    }

    private string TourDetails()
        => _steps.OrderBy(x => x.Time)
            .Aggregate(string.Empty, (acc, s1) => acc + s1 + Environment.NewLine);

    private string TourDeliveryTime()
    {
        var tourDeliveryTime = _steps.Select(s => s.DeliveryTime).Sum();

        string hhMmSs = @"hh\:mm\:ss";
        string str = TimeSpan.FromSeconds(tourDeliveryTime).ToString(hhMmSs);
        var toutDeliveryTimeRepresentation = $"Delivery time | {str}";
        return toutDeliveryTimeRepresentation;
    }
}