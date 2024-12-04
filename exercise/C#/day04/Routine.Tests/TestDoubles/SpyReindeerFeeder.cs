using FluentAssertions;

namespace Routine.Tests.TestDoubles;

public class SpyReindeerFeeder : IReindeerFeeder
{
    private bool _reindeerHaveBeenFed;

    public void FeedReindeers() => _reindeerHaveBeenFed = true;

    public void ReindeerHaveBeenFed() => _reindeerHaveBeenFed.Should().BeTrue();
}