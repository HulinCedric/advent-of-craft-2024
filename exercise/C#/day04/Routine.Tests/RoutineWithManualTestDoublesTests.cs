using Routine.Tests.TestDoubles;
using Xunit;

namespace Routine.Tests;

public class RoutineWithManualTestDoublesTests
{
    [Fact]
    public void StartRoutine_With_Manual_Test_Doubles()
    {
        // Given
        var emailService = new SpyEmailService();
        var scheduleService = new FakeScheduleService();
        var reindeerFeeder = new SpyReindeerFeeder();

        var schedule = new Schedule
        {
            Tasks = ["Task 1", "Task 2"]
        };

        scheduleService.ScheduledWith(schedule);

        var routine = new Routine(emailService, scheduleService, reindeerFeeder);

        // When
        routine.Start();

        // Then
        scheduleService.ScheduleHaveBeenOrganized(schedule);
        reindeerFeeder.ReindeerHaveBeenFed();
        emailService.NewEmailsHaveBeenRead();
        scheduleService.ScheduleHaveBeenContinued();
    }
}