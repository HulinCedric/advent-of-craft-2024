namespace Gifts;

public class Santa
{
    private readonly Children _children = new();

    public Toy? ChooseToyForChild(string childName)
    {
        var found = _children.FindChildByName(new ChildName(childName)) ?? throw new InvalidOperationException("No such child found");

        return found.GetChoice();
    }

    public void AddChild(Child child) => _children.AddChild(child);
}