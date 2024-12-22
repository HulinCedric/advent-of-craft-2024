using LanguageExt;
using static System.Environment;
using static LanguageExt.Prelude;

namespace Tour;

public static class StepsTextFormatter
{
    public static Either<string, string> Calculate(Seq<Step> steps)
        => steps.IsEmpty
            ? Left("No locations !!!")
            : Right($"{StatementFor(steps)}{FormatTotal(steps)}{NewLine}");

    private static string StatementFor(Seq<Step> steps)
        => steps.OrderBy(step => step.Time)
            .Fold(string.Empty, (statement, step) => $"{statement}{step}{NewLine}");

    private static string FormatTotal(Seq<Step> steps) => $"Delivery time | {TourDeliveryTime.From(steps)}";
}