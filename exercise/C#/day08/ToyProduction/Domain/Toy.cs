namespace ToyProduction.Domain
{
    public class Toy(string name)
    {
        private State _state = State.Unassigned;
        public string Name { get; } = name;

        public void AssignToElf()
        {
            if (this is { _state: State.Unassigned })
            {
                _state = State.InProduction;
            }
        }

        public bool IsInProduction()
        {
            return _state == State.InProduction;
        }
    }

    public enum State
    {
        Unassigned,
        InProduction,
        Completed
    }
}