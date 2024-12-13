using LanguageExt;

namespace Gifts;

public class Santa
{
    private ChildrenRepository _childrenRepository = new();

    public Option<Toy> ChooseToyForChild(ChildName childName)
        => _childrenRepository.FindChildByName(childName)
            .Match(
                child => child.GetChoice(),
                () => throw new InvalidOperationException("No such child found"));

    public void AddChild(Child child) => _childrenRepository.AddChild(child);
}