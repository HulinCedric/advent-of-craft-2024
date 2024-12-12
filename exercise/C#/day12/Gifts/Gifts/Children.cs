namespace Gifts;

internal class Children
{
    private readonly List<Child> _children = [];

    internal Child? FindChildByName(string childName) => _children.FirstOrDefault(child => child.Name == childName);

    internal void AddChild(Child child) => _children.Add(child);
}