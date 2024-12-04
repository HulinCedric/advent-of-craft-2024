using Routine.Tests.TestDoubles;
using Xunit;

namespace Routine.Tests;

public class RoutineWithManualTestDoublesTests
{
    private readonly SpyEmailService _emailService;
    private readonly SpyReindeerFeeder _reindeerFeeder;
    private readonly Routine _routine;
    private readonly FakeScheduleService _scheduleService;

    public RoutineWithManualTestDoublesTests()
    {
        _emailService = new SpyEmailService();
        _scheduleService = new FakeScheduleService();
        _reindeerFeeder = new SpyReindeerFeeder();
        _routine = new Routine(_emailService, _scheduleService, _reindeerFeeder);
    }

    [Fact]
    public void StartRoutine_With_Manual_Test_Doubles()
    {
        // Given
        var todaySchedule = new Schedule
        {
            Tasks = ["Task 1", "Task 2"]
        };

        _scheduleService.AlreadyScheduled(todaySchedule);

        // When
        _routine.Start();

        // Then
        _scheduleService.DayHaveBeenOrganizedWith(todaySchedule);
        _reindeerFeeder.ReindeerHaveBeenFed();
        _emailService.NewEmailsHaveBeenRead();
        _scheduleService.ScheduleHaveBeenContinued();
    }
}