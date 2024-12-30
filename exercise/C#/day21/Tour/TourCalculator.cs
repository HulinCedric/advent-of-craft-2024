using LanguageExt;
using static LanguageExt.Prelude;

namespace Tour
{
    public class TourCalculator(List<Step> steps)
    {
        private readonly Seq<Step> _steps = steps.ToSeq();

        public Either<string, string> Calculate()
            => HasNoLocations()
                ? ToNoLocationsFailure()
                : ToCalculationSuccess();

        private Either<string, string> ToCalculationSuccess()
            => Right($"{TourDetails()}{DeliveryTimes()}{Environment.NewLine}");

        private static Either<string, string> ToNoLocationsFailure() => Left("No locations !!!");

        private bool HasNoLocations() => _steps.IsNull() || _steps.Count == 0;

        private string TourDetails()
            => _steps
                .OrderBy(x => x.Time)
                .Aggregate(string.Empty, (tour, step) => $"{tour}{step.Reprensentation()}{Environment.NewLine}");

        private string DeliveryTimes() => $"Delivery time | {TourDeliveryTime.From(_steps)}";
    }
}