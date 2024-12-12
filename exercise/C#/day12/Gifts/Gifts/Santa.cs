using LanguageExt;

namespace Gifts;

public class Santa
{
    private Children _children = new();

    public Option<Toy> ChooseToyForChild(ChildName childName)
        => _children.FindChildByName(childName)
            .Match(
                child => child.GetChoice(),
                () => throw new InvalidOperationException("No such child found"));

    public void AddChild(Child child) => _children = _children.AddChild(child);
}