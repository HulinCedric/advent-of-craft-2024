using FluentAssertions;
using FluentAssertions.LanguageExt;
using ToyProduction.Domain;
using ToyProduction.Services;
using ToyProduction.Tests.Doubles;
using Xunit;

namespace ToyProduction.Tests;

public class ToyProductionServiceTest
{
    private const string ToyName = "Train";

    private readonly IToyRepository _repository;
    private readonly ToyProductionService _service;

    public ToyProductionServiceTest()
    {
        _repository = new InMemoryToyRepository();
        _service = new ToyProductionService(_repository);
    }

    [Fact]
    public void AssignToyToElfShouldPassTheItemInProduction()
    {
        _repository.Save(new Toy(ToyName));

        _service.AssignToyToElf(ToyName);

        _repository.FindByName(ToyName).Should().BeSome(toy => toy.IsInProduction().Should().BeTrue());
    }
}