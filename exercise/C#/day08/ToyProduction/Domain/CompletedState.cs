namespace ToyProduction.Domain;

public partial class Toy
{
    private class CompletedState : IState
    {
        // Cannot assign if completed
        public Toy AssignToElf(Toy toy) => toy;

        // Already completed
        public Toy CompleteProduction(Toy toy) => toy;
    }
}