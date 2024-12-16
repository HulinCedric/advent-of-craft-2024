using System.Runtime.InteropServices;
using FluentAssertions;
using Xunit;
using static FluentAssertions.FluentActions;

namespace TaskAssignmentSystem.Tests;

public class TaskAssignmentTests
{
    private const int UnknownElfId = 4;
    private readonly TaskAssignment _system;

    public TaskAssignmentTests()
    {
        var elves = new List<Elf>
        {
            new(1, 5),
            new(2, 10),
            new(3, 20)
        };
        _system = new TaskAssignment(elves);
    }

    [Fact]
    public void ReportTaskCompletion_IncreasesTotalTasksCompleted()
    {
        _system.ReportTaskCompletion(1).Should().BeTrue();
        _system.TotalTasksCompleted.Should().Be(1);
    }

    [Fact]
    public void ReportTaskCompletion_DoNotIncreasesTotal_WhenElfIsUnknown()
    {
        _system.ReportTaskCompletion(UnknownElfId).Should().BeFalse();
        _system.TotalTasksCompleted.Should().Be(0);
    }

    [Fact]
    public void GetElfWithHighestSkill_ReturnsCorrectElf()
    {
        var highestSkillElf = _system.ElfWithHighestSkill();
        highestSkillElf.Should().BeEquivalentTo(new Elf(3, 20));
    }

    [Fact]
    public void GetElfWithHighestSkill_ReturnsNull_WhenNoElves()
    {
        var emptySystem = new TaskAssignment(new List<Elf>());
        var highestSkillElf = emptySystem.ElfWithHighestSkill();
        highestSkillElf.Should().BeNull();
    }

    [Theory]
    [InlineData(9, 2)]
    [InlineData(10, 2)]
    [InlineData(11, 3)]
    public void AssignTask_AssignsElfBasedOnSkillLevel(int taskSkillRequired, int elfId)
        => _system.AssignTask(taskSkillRequired)!.Id.Should().Be(elfId);

    [Fact]
    public void IncreaseSkillLevel_UpdatesElfSkillCorrectly()
    {
        _system.IncreaseSkillLevel(1, 3);
        var elf = _system.AssignTask(7);
        elf.Should().BeEquivalentTo(new Elf(1, 8));
    }

    [Fact]
    public void IncreaseSkillLevel_DoNoFail_WhenElfIsUnknown()
        => Invoking(() => _system.IncreaseSkillLevel(UnknownElfId, 3)).Should().NotThrow();

    [Fact]
    public void DecreaseSkillLevel_UpdatesElfSkillCorrectly()
    {
        _system.DecreaseSkillLevel(1, 3);
        _system.DecreaseSkillLevel(2, 5);

        var elf = _system.AssignTask(4);
        elf.Should().BeEquivalentTo(new Elf(2, 5));
    }

    [Fact]
    public void DecreaseSkillLevel_DoNotFail_WhenElfIsUnknown()
        => Invoking(() => _system.DecreaseSkillLevel(UnknownElfId, 3)).Should().NotThrow();

    [Theory]
    [InlineData(4)]
    [InlineData(5)]
    public void DecreaseSkillLevel_UpdatesElfSkillAndDoesNotAllowNegativeValues(int decrement)
    {
        _system.DecreaseSkillLevel(1, decrement);
        var elf = _system.AssignTask(1);
        elf.Should().BeEquivalentTo(new Elf(1, 1));
    }

    [Fact]
    public void ReassignTask_ChangesAssignmentCorrectly()
    {
        _system.ReassignTask(3, 1);
        var elf = _system.AssignTask(19);
        elf.Should().BeEquivalentTo(new Elf(1, 20));
    }

    [Fact]
    public void AssignTask_FailsWhenSkillsRequiredIsTooHigh() => _system.AssignTask(50).Should().BeNull();

    [Fact]
    public void ListElvesBySkillDescending_ReturnsElvesInCorrectOrder()
    {
        var sortedElves = _system.ElvesBySkillDescending();
        sortedElves.ConvertAll(elf => elf.Id).Should().Equal(new List<int> { 3, 2, 1 });
    }

    [Fact]
    public void ResetAllSkillsToBaseline_ResetsAllElvesSkillsToSpecifiedBaseline()
    {
        _system.ResetAllSkillsToBaseline(10);
        var elves = _system.ElvesBySkillDescending();
        foreach (var elf in elves)
        {
            elf.SkillLevel.Should().Be(10);
        }
    }

    [Fact]
    public void AssignTask_AssignsElfWithLowestMatchingSkillLevel()
    {
        // Imagine we have three elves: Alice, Bob, and Charlie. 
        // Alice has a skill level of 7, Bob has a skill level of 5, and Charlie has a skill level of 3. 
        var alice = new Elf(1, 7);
        var bob = new Elf(2, 5);
        var charlie = new Elf(3, 3);
        var elves = new List<Elf>
        {
            alice,
            bob,
            charlie
        };

        var system = new TaskAssignment(elves);

        // Now, let's say we have a task that requires a skill level of 4.
        // You'd think that Alice and Bob would both be capable of doing this task, right?
        var elf = system.AssignTask(4);

        // But sometimes, our Task Assignment System only assigns the task to Alice and completely overlooks Bob! 
        // It's like the system is completely ignoring our skill levels and just assigning tasks randomly.
        elf.Should().Be(bob);
    }
}