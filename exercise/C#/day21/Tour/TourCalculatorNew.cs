using LanguageExt;
using static System.Environment;
using static LanguageExt.Prelude;

namespace Tour;

public class TourCalculatorNew(List<Step> steps)
{
    private readonly Seq<Step> _steps = steps.ToSeq();

    public Either<string, string> Calculate()
        => _steps.IsEmpty
            ? Left("No locations !!!")
            : Right($"{StatementFor()}{FormatTotal()}{NewLine}");

    private string StatementFor()
        => _steps.OrderBy(step => step.Time)
            .Fold(string.Empty, (statement, step) => $"{statement}{step}{NewLine}");

    private string FormatTotal() => $"Delivery time | {TourDeliveryTime.From(_steps)}";
}