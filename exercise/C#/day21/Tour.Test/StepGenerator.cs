using FsCheck;

namespace Tour.Test;

public static class StepGenerator
{
    public static Arbitrary<Step> Generate()
        => (from time in TimeOnlyGenerator()
                from label in Arb.Generate<string>()
                from deliveryTime in Arb.Generate<int>()
                select new Step(time, label, deliveryTime))
            .ToArbitrary();

    private static Gen<TimeOnly> TimeOnlyGenerator()
        => from hour in Gen.Choose(0, 23)
            from minute in Gen.Choose(0, 59)
            from second in Gen.Choose(0, 59)
            from millisecond in Gen.Choose(0, 999)
            select new TimeOnly(hour, minute, second, millisecond);
}