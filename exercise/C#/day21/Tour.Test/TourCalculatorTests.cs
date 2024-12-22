using FsCheck;
using FsCheck.Xunit;

namespace Tour.Test;

public class TourCalculatorTests
{
    [Property(Arbitrary = [typeof(StepGenerator)])]
    public Property Calculation_properties(List<Step> steps)
        => (StepsTextFormatter.Calculate(steps.ToSeq()) == new TourCalculator(steps).Calculate()).ToProperty();
}