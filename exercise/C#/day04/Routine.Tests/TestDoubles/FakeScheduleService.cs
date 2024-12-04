using FluentAssertions;

namespace Routine.Tests.TestDoubles;

public class FakeScheduleService : IScheduleService
{
    private Schedule? _organizedSchedule;
    private bool _scheduleHaveBeenContinued = true;
    private Schedule _todaySchedule = new();

    public Schedule TodaySchedule() => _todaySchedule;

    public void OrganizeMyDay(Schedule schedule) => _organizedSchedule = schedule;

    public void Continue() => _scheduleHaveBeenContinued = true;

    public void ScheduledWith(Schedule schedule) => _todaySchedule = schedule;

    public void ScheduleHaveBeenOrganized(Schedule schedule) => _organizedSchedule.Should().BeEquivalentTo(schedule);

    public void ScheduleHaveBeenContinued() => _scheduleHaveBeenContinued.Should().BeTrue();
}