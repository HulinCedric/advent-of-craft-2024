using LanguageExt;

namespace Gifts;

public class Santa
{
    private Children _children = new();

    public Option<Toy> ChooseToyForChild(string childName)
        => _children.FindChildByName(new ChildName(childName))
            .Match(
                child => child.GetChoice(),
                () => throw new InvalidOperationException("No such child found"));

    public void AddChild(Child child) => _children = _children.AddChild(child);
}