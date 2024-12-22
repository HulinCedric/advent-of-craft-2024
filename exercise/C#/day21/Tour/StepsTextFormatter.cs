using LanguageExt;
using static System.Environment;
using static LanguageExt.Prelude;

namespace Tour;

public static class StepsTextFormatter
{
    public static Either<SantaError, string> Calculate(Seq<Step> steps)
        => steps.IsEmpty
            ? new SantaError("No locations !!!")
            : $"{StatementFor(steps)}{FormatTotal(steps)}{NewLine}";

    private static string StatementFor(Seq<Step> steps)
        => steps.OrderBy(step => step.Time)
            .Fold(string.Empty, (statement, step) => $"{statement}{step}{NewLine}");

    private static string FormatTotal(Seq<Step> steps) => $"Delivery time | {TourDeliveryTime.From(steps)}";
}

public record SantaError(string Message);
