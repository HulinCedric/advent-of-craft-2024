namespace ToyProduction.Domain
{
    public class Toy(string name, State state)
    {
        public string Name { get; } = name;
        public State State { get; set; } = state;

        public void AssignToElf()
        {
            if (this is {State: State.Unassigned})
            {
                State = State.InProduction;
            }
        }
    }

    public enum State
    {
        Unassigned,
        InProduction,
        Completed
    }
}