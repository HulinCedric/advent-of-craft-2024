namespace ToyProduction.Domain
{
    public class Toy(string name)
    {
        private IState _state = new UnassignedState();

        public string Name { get; } = name;

        public void AssignToElf() => _state.AssignToElf(this);

        internal void ChangeState(IState state) => _state = state;

        public bool IsInProduction() => _state is InProductionState;
    }
}