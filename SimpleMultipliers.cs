using System;
using System.Collections.Generic;

namespace HELP_I_NEED_SOMEBODY
{
    public class SimpleMultipliers
    {
        public int value;
        public List<int> multipliers;
        public SimpleMultipliers(string num)
        {
            int number;
            value = Convert.ToInt32(num);
            multipliers = new List<int>();
            if (value == 0)
            {
                multipliers.Add(0);
                return;
            }
            if (value == 1)
            {
                multipliers.Add(1);
                return;
            }
            if (value > 1) number = value;
            else
            {
                multipliers.Add(-1);
                number = -value;
            }
            for (int i = 2; number > 1; i++)
            {
                while (number % i == 0)
                {
                    multipliers.Add(i);
                    number /= i;
                }
            }
        }

        public void printMultipliers()
        {
            Console.Write($"{value} = {multipliers[0]}");
            for (int i = 1; i < multipliers.Count; i++) Console.Write("*"+multipliers[i]);
            Console.WriteLine();
        }
    }
}