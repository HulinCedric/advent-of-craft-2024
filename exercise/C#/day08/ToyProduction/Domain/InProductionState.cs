namespace ToyProduction.Domain;

public partial class Toy
{
    private class InProductionState : IState
    {
        // Already in production
        public Toy AssignToElf(Toy toy) => toy;

        public Toy CompleteProduction(Toy toy) => toy.ChangeState(new CompletedState());
    }
}