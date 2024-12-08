namespace ToyProduction.Domain;

public partial class Toy
{
    private class CompletedState : IState
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
}