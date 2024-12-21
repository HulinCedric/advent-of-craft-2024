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
        
        var result = new StringBuilder();

        var tourStepDetails = _steps.OrderBy(x => x.Time)
            .Aggregate(string.Empty, (acc, s) => acc + s + Environment.NewLine);
        
        var tourDeliveryTime = _steps.Select(s => s.DeliveryTime).Sum();

        string hhMmSs = @"hh\:mm\:ss";
        string str = TimeSpan.FromSeconds(tourDeliveryTime).ToString(hhMmSs);
       
        result.Append(tourStepDetails);
        result.AppendLine($"Delivery time | {str}");

        return Right(result.ToString());
    }
}