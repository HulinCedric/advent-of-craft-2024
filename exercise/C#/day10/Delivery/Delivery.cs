namespace Delivery;

public static class Building
{
    public static int WhichFloor(string instructions)
        => instructions.Sum(
            c =>
            {
                if (instructions.Contains("🧝"))
                {
                    int j;
                    if (c == ')') j = 3;
                    else if (c == '(') j = -2;
                    else j = 0;

                    return j;
                }

                if (!instructions.Contains("🧝")) return c == '(' ? 1 : -1;

                return 0;
            });
}