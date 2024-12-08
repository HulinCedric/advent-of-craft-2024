using FluentAssertions;
using ToyProduction.Domain;
using ToyProduction.Services;
using ToyProduction.Tests.Doubles;
using Xunit;

namespace ToyProduction.Tests;

public class ToyProductionServiceTest
{
    private const string ToyName = "Train";

    [Fact]
    public void AssignToyToElfShouldPassTheItemInProduction()
    {
        var repository = new InMemoryToyRepository();
        var service = new ToyProductionService(repository);
        repository.Save(new Toy(ToyName, State.Unassigned));

        service.AssignToyToElf(ToyName);

        repository.FindByName(ToyName)!
            .IsInState(State.InProduction)
            .Should()
            .BeTrue();
    }
}