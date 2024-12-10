namespace Delivery
{
    public static class Building
    {
        public static int WhichFloor(string instructions)
        {
            List<int> val = [];

            for (int i = 0; i < instructions.Length; i++)
            {
                var c = instructions[i];

                if (instructions.Contains("🧝"))
                {
                    int j;
                    if (c == ')') j = 3;
                    else if (c == '(') j = -2;
                    else j = 0;

                    val.Add(j);
                }
                else if (!instructions.Contains("🧝"))
                {
                    val.Add(c == '(' ? 1 : -1);
                }
            }


            return val.Sum();
        }
    }
}