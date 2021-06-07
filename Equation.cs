using System;
using System.Collections.Generic;

namespace HELP_I_NEED_SOMEBODY
{
    public class Equation
    {
        public double a, b, c;
        public Equation(string str)
        {
            string[] splitted = str.Split("x^2");
            if (!double.TryParse(splitted[0], out a))
            {
                a = b = c = 0;
                return;
            }
            str = splitted[1];
            splitted = str.Split("x");
            if (!double.TryParse(splitted[0], out b))
            {
                a = b = c = 0;
                return;
            }
            str = splitted[1];
            splitted = str.Split("=");
            double d = 0;
            if (!(double.TryParse(splitted[0], out c) && double.TryParse(splitted[1], out d)))
            {
                a = b = c = 0;
                return;
            }
            c -= d;
        }

        public List<double> GetRoots()
        {
            double D = Math.Pow(b, 2) - 4 * a * c;
            if (D < 0 || a == 0 && b == 0 && c == 0) return null;
            List<double> roots = new List<double>();
            if (D == 0)
            {
                roots.Add(-b / 2 / a);
            }
            else
            {
                roots.Add((-b + Math.Sqrt(D))/ (2*a));
                roots.Add((-b - Math.Sqrt(D))/ (2*a));
            }
            return roots;
        }
    }
}