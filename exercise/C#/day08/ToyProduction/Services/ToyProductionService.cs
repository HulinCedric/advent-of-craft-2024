using ToyProduction.Domain;

namespace ToyProduction.Services
{
    public class ToyProductionService(IToyRepository repository)
    {
        public void AssignToyToElf(string toyName)
        {
            var toy = repository.FindByName(toyName);
            if (toy is null) return;
            
            toy.AssignToElf();
            
            repository.Save(toy);
        }
    }
}