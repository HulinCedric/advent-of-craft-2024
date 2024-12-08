namespace ToyProduction.Domain
{
    public class Toy(string name, State state)
    {
        public string Name { get; } = name;
        public State State { get; private set; } = state;

        public void AssignToElf()
        {
            if (this is {State: State.Unassigned})
            {
                State = State.InProduction;
            }
        }

        public bool IsInState(State state)
        {
            return State == state;
        }
    }

    public enum State
    {
        Unassigned,
        InProduction,
        Completed
    }
}