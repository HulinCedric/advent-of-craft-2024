namespace Gifts;

internal class Children
{
    private readonly List<Child> _children = [];

    internal Child? FindChildByName(ChildName childName) => _children.FirstOrDefault(child => child.IsNamed(childName));

    internal void AddChild(Child child) => _children.Add(child);
}