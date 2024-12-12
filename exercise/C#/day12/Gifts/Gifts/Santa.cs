namespace Gifts;

public class Santa
{
    private readonly Children _children = new Children();
    
    public Toy? ChooseToyForChild(string childName)
    {
        var found = _children.FindChildByName(childName);

        return found.GetChoice();
    }
    
    public void AddChild(Child child) => _children.AddChild(child);

}