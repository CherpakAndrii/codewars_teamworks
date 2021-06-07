using System;

namespace HELP_I_NEED_SOMEBODY
{
    public class Polinom
    {
        public uint pow;
        public double[] coefs;

        public Polinom(uint power)
        {
            pow = power;
            coefs = new double[pow+1];
            inputPolinom();
            while (coefs[pow] == 0 && pow != 0) pow--;
        }

        public Polinom(double[] coefsArray)
        {
            pow = (uint)coefsArray.Length - 1;
            coefs = coefsArray;
            while (coefs[pow] == 0 && pow != 0) pow--;
        }

        public void inputPolinom()
        {
            for (int i = (int) pow; i >= 0; i--)
            {
                Console.WriteLine("Введiть коефiцiєнти полiнома: ");
                Console.Write(outputPolinom());
                if (i!=pow) Console.Write(" + ");
                if (i!=0) Console.Write($"x^{i}*");
                double coef;
                if (!double.TryParse(Console.ReadLine(), out coef))
                {
                    Console.WriteLine("Некоректний ввiд!");
                    i++;
                    continue;
                }
                coefs[i] = coef;
            }
        }
        
        public string outputPolinom()
        {
            string str = "";
            for (int i = (int)pow; i >= 0; i--)
            {
                if (coefs[i] == 0) continue;
                if (coefs[i] > 0 && str.Length != 0) str += " + ";
                str += Math.Round(coefs[i], 3);
                if (i != 0) str += $"*x^{i}";
            }
            return str;
        }

        public static Polinom operator +(Polinom p1, Polinom p2)
        {
            uint pow = Math.Max(p1.pow, p2.pow);
            double[] coefs = new double[pow + 1];
            for (int i = 0; i <= Math.Min(p1.pow, p2.pow); i++) coefs[i] = p1.coefs[i] + p2.coefs[i];
            Polinom morePowerfull = p1.pow > p2.pow ? p1 : p2;
            for (uint i = Math.Min(p1.pow, p2.pow) + 1; i < pow + 1; i++) coefs[i] = morePowerfull.coefs[i];
            return new Polinom(coefs);
        }
        
        public static Polinom operator -(Polinom p1, Polinom p2)
        {
            uint pow = Math.Max(p1.pow, p2.pow);
            double[] coefs = new double[pow + 1];
            for (int i = 0; i <= Math.Min(p1.pow, p2.pow); i++) coefs[i] = p1.coefs[i] - p2.coefs[i];
            if (p1.pow > p2.pow)
            {
                for (uint i = Math.Min(p1.pow, p2.pow) + 1; i < pow + 1; i++)
                {
                    coefs[i] = p1.coefs[i];
                }
            }
            else for (uint i = Math.Min(p1.pow, p2.pow) + 1; i < pow + 1; i++)
            {
                coefs[i] = -p2.coefs[i];
            }
            return new Polinom(coefs);
        }

        public double ValueAtPoint(double x)
        {
            double value = 0;
            for (int i = 0; i<=pow; i++)
            {
                value += coefs[i] * Math.Pow(x, i);
            }
            return value;
        }
    }
}