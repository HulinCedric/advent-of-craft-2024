using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Workshop.Tests;

public class GiftAssertions(Gift? subject) : ReferenceTypeAssertions<Gift?, GiftAssertions>(subject)
{
    protected override string Identifier => "gift";

    public AndConstraint<GiftAssertions> BeProduced(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(Subject is not null)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context:gift} to be produced{reason}, but found <null>.");

        Execute.Assertion
            .ForCondition(Subject!.Status == Status.Produced)
            .BecauseOf(because, becauseArgs)
            .FailWith(
                "Expected {context:gift} to have status {0}{reason}, but found {1}.",
                Status.Produced.ToString(),
                Subject.Status.ToString());

        return new AndConstraint<GiftAssertions>(this);
    }

    public AndConstraint<GiftAssertions> BeNotProduced(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(Subject is null)
            .BecauseOf(because, becauseArgs)
            .WithDefaultIdentifier(Identifier)
            .FailWith("Expected {context:gift} to be <null>{reason}, but found {0}.", Subject);

        return new AndConstraint<GiftAssertions>(this);
    }
}