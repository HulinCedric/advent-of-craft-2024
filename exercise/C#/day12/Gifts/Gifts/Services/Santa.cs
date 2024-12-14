using Gifts.Domain;
using Gifts.Ports;
using LanguageExt;

namespace Gifts.Services;

using Result = Either<string, Option<Toy>>;

public class Santa(IChildrenRepository childrenRepository)
{
    public Result ChooseToyForChild(ChildName childName)
        => childrenRepository.FindChildByName(childName)
            .Match(
                ToToyChoice,
                ToFailure);

    private static Result ToToyChoice(Child child) => child.GetChoice();

    private static Result ToFailure() => "No such child found";

    public void AddChild(Child child) => childrenRepository.AddChild(child);
}