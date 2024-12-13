using LanguageExt;

namespace Gifts;

public class Santa
{
    private readonly IChildrenRepository _childrenRepository = new ChildrenRepository();

    public Option<Toy> ChooseToyForChild(ChildName childName)
        => _childrenRepository.FindChildByName(childName)
            .Match(
                child => child.GetChoice(),
                () => throw new InvalidOperationException("No such child found"));

    public void AddChild(Child child) => _childrenRepository.AddChild(child);
}