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

        double deliveryTime = 0;

        var result = new StringBuilder();

        foreach (var s in _steps.OrderBy(x => x.Time))
        {
            deliveryTime += s.DeliveryTime;
            result.AppendLine(s.ToString());
        }

        string hhMmSs = @"hh\:mm\:ss";
        string str = TimeSpan.FromSeconds(deliveryTime).ToString(hhMmSs);
        result.AppendLine($"Delivery time | {str}");

        return Right(result.ToString());
    }
}