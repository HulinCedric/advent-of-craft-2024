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

                val.Add(Calculate(instructions, c));
            }


            return val.Sum();
        }

        private static int Calculate(string instructions, char c)
        {
            if (instructions.Contains("🧝"))
            {
                int j;
                if (c == ')') j = 3;
                else if (c == '(') j = -2;
                else j = 0;

                return j;
            }
            else if (!instructions.Contains("🧝"))
            {
                return c == '(' ? 1 : -1;
            }
            else
            {
                return 0;
            }
        }
    }
}