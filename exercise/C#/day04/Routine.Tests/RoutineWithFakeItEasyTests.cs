using FakeItEasy;
using Xunit;

namespace Routine.Tests;

public class RoutineWithFakeItEasyTests
{
    private readonly IEmailService _emailService;
    private readonly IReindeerFeeder _reindeerFeeder;
    private readonly Routine _routine;
    private readonly IScheduleService _scheduleService;

    public RoutineWithFakeItEasyTests()
    {
        _emailService = A.Fake<IEmailService>();
        _reindeerFeeder = A.Fake<IReindeerFeeder>();
        _scheduleService = A.Fake<IScheduleService>();
        _routine = new Routine(_emailService, _scheduleService, _reindeerFeeder);
    }

    [Fact]
    public void StartRoutine_With_FakeItEasy()
    {
        // Given
        var todaySchedule = new Schedule
        {
            Tasks = ["Task 1", "Task 2"]
        };

        A.CallTo(() => _scheduleService.TodaySchedule()).Returns(todaySchedule);

        // When
        _routine.Start();

        // Then
        A.CallTo(() => _scheduleService.OrganizeMyDay(todaySchedule)).MustHaveHappened();
        A.CallTo(() => _reindeerFeeder.FeedReindeers()).MustHaveHappened();
        A.CallTo(() => _emailService.ReadNewEmails()).MustHaveHappened();
        A.CallTo(() => _scheduleService.Continue()).MustHaveHappened();
    }
}