using FsCheck;
using FsCheck.Xunit;
using LanguageExt;

namespace Tour.Test;

public class TourCalculatorTests
{
    [Property(Arbitrary = [typeof(StepGenerator)])]
    public Property Calculation_properties(List<Step> steps)
        => (ToV1Result(steps.ToSeq()) == new TourCalculator(steps).Calculate()).ToProperty();
    
    private static Either<string, string> ToV1Result(Seq<Step> steps)
        => StepsTextFormatter.Calculate(steps).MapLeft(err => err.Message);
}