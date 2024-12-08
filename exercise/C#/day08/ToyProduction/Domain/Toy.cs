namespace ToyProduction.Domain
{
    public partial class Toy
    {
        private IState _state;

        public Toy(string name)
        {
            Name = name;
            _state = new UnassignedState();
        }

        public string Name { get; }

        public void AssignToElf() => _state.AssignToElf(this);

        private void ChangeState(IState state) => _state = state;

        public bool IsInProduction() => _state is InProductionState;
    }
}