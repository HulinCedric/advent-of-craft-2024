namespace ToyProduction.Domain;

internal class UnassignedState : IState
{
    public void AssignToElf(Toy toy) => toy.ChangeState(new InProductionState());

    public void CompleteProduction(Toy toy)
    {
        // Cannot complete production if unassigned
    }
}