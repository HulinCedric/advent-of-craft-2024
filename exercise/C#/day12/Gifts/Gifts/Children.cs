namespace Gifts;

public class Children
{
    private readonly List<Child> _children = [];

    internal Child? FindChildByName(string childName) => _children.FirstOrDefault(child => child.Name == childName);

    public void AddChild(Child child) => _children.Add(child);
}