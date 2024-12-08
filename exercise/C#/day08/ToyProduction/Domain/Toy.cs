namespace ToyProduction.Domain
{
    public class Toy(string name)
    {
        private State _state = State.Unassigned;
        public string Name { get; } = name;

        public void AssignToElf()
        {
            if (_state is not State.Unassigned) return;

            _state = State.InProduction;
        }

        public bool IsInProduction() => _state == State.InProduction;
    }

    public enum State
    {
        Unassigned,
        InProduction,
        Completed
    }
}