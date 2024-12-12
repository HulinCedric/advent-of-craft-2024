﻿namespace Gifts;

public class Santa
{
    private readonly List<Child> _childrenRepository = [];

    public Toy? ChooseToyForChild(string childName)
    {
        var found = FindChildByName(childName);

        return found.GetChoice();
    }

    private Child FindChildByName(string childName)
    {
        Child? found = null;
        for (int i = 0; i < _childrenRepository.Count; i++)
        {
            var currentChild = _childrenRepository[i];
            if (currentChild.Name == childName)
            {
                found = currentChild;
            }
        }

        if (found == null)
            throw new InvalidOperationException("No such child found");
        return found;
    }

    public void AddChild(Child child) => _childrenRepository.Add(child);
}