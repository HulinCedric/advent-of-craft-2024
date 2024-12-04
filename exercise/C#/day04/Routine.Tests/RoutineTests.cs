using FakeItEasy;
using Xunit;

namespace Routine.Tests;

public class RoutineTests
{
    [Fact]
    public void StartRoutine_With_FakeItEasy()
    {
        // Given
        var emailService = A.Fake<IEmailService>();
        var scheduleService = A.Fake<IScheduleService>();
        var reindeerFeeder = A.Fake<IReindeerFeeder>();

        var schedule = new Schedule
        {
            Tasks = ["Task 1", "Task 2"]
        };

        A.CallTo(() => scheduleService.TodaySchedule()).Returns(schedule);

        var routine = new Routine(emailService, scheduleService, reindeerFeeder);

        // When
        routine.Start();

        // Then
        A.CallTo(() => scheduleService.OrganizeMyDay(schedule)).MustHaveHappened();
        A.CallTo(() => reindeerFeeder.FeedReindeers()).MustHaveHappened();
        A.CallTo(() => emailService.ReadNewEmails()).MustHaveHappened();
        A.CallTo(() => scheduleService.Continue()).MustHaveHappened();
    }

    [Fact]
    public void StartRoutine_With_Manual_Test_Doubles()
    {
        // Write a test using your own Test Double(s)
    }
}