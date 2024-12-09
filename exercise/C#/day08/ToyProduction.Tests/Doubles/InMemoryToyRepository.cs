using LanguageExt;
using ToyProduction.Domain;

namespace ToyProduction.Tests.Doubles;

public class InMemoryToyRepository : IToyRepository
{
    private readonly List<Toy> _toys = [];

    public Option<Toy> FindByName(string name) => _toys.FirstOrDefault(t => t.Name == name);

    public void Save(Toy toy)
    {
        FindByName(toy.Name)
            .Match(
                previousToy => _toys.Remove(previousToy),
                () => { });
        
        _toys.Add(toy);
    }
}