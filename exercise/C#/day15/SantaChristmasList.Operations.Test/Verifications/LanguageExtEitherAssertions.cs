namespace SantaChristmasList.Operations.Test.Verifications;

public static class LanguageExtEitherAssertions
{
    public static AndConstraint<LanguageExtEitherAssertions<TL, TR>> BeFailure<TL, TR>(
        this LanguageExtEitherAssertions<TL, TR> @this,
        string expected,
        string because = "",
        params object[] becauseArgs)
        => @this.Subject.Should()
            .BeLeft(failure => failure.Should().BeEquivalentTo(Failure.New(expected), because, becauseArgs));
}