namespace ToyProduction.Domain;

public partial class Toy
{
    private class UnassignedState : IState
    {
        public Toy AssignToElf(Toy toy) => toy.ChangeState(new InProductionState());

        // Cannot complete production if unassigned
        public Toy CompleteProduction(Toy toy) => toy;
    }
}