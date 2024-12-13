using Gifts.Domain;
using Gifts.Ports;
using LanguageExt;

namespace Gifts.Services;

public class Santa(IChildrenRepository childrenRepository)
{
    public Either<string, Option<Toy>> ChooseToyForChild(ChildName childName)
        => childrenRepository.FindChildByName(childName)
            .Match(
                ToToyChoice,
                ToFailure);

    private static Either<string, Option<Toy>> ToToyChoice(Child child) => child.GetChoice();

    private static Either<string, Option<Toy>> ToFailure() => "No such child found";

    public void AddChild(Child child) => childrenRepository.AddChild(child);
}