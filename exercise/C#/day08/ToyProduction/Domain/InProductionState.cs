namespace ToyProduction.Domain;

public partial class Toy
{
    private class InProductionState : IState
    {
        public void AssignToElf(Toy toy)
        {
            // Already in production
        }

        public void CompleteProduction(Toy toy) => toy.ChangeState(new CompletedState());
    }
}