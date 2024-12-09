namespace ToyProduction.Domain
{
    public partial class Toy
    {
        private readonly IState _state;

        public Toy(string name) : this(name, new UnassignedState())
        {
        }

        private Toy(string name, IState state)
        {
            Name = name;
            _state = state;
        }

        public string Name { get; }

        public Toy AssignToElf() => _state.AssignToElf(this);

        private Toy ChangeState(IState state) => new(Name, state);

        public bool IsInProduction() => _state is InProductionState;
    }
}