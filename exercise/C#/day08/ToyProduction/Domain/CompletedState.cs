namespace ToyProduction.Domain;

internal class CompletedState : IState
{
    public void AssignToElf(Toy toy)
    {
        // Cannot assign if completed
    }

    public void CompleteProduction(Toy toy)
    {
        // Already completed
    }
}