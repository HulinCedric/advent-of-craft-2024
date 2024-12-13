using LanguageExt;

namespace Gifts;

public class Santa(IChildrenRepository childrenRepository)
{
    public Option<Toy> ChooseToyForChild(ChildName childName)
        => childrenRepository.FindChildByName(childName)
            .Match(
                child => child.GetChoice(),
                () => throw new InvalidOperationException("No such child found"));

    public void AddChild(Child child) => childrenRepository.AddChild(child);
}