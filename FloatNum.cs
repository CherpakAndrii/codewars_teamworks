using System;

namespace HELP_I_NEED_SOMEBODY
{
    public class FloatNum
    {
        public double Mantice;
        public int Power;

        private FloatNum(double mantice, int pow)
        {
            Mantice = mantice;
            Power = pow;
            while (Math.Abs(Mantice) < 1)
            {
                Mantice *= 10;
                Power--;
            }
            while (Math.Abs(Mantice) > 10)
            {
                Mantice /= 10;
                Power++;
            }
        }
        
        public FloatNum(double num)
        {
            Power = 0;
            while (Math.Abs(num) < 1)
            {
                num *= 10;
                Power--;
            }
            while (Math.Abs(num) > 10)
            {
                num /= 10;
                Power++;
            }
            Mantice = num;
        }

        public static FloatNum operator +(FloatNum n1, FloatNum n2)
        {
            return new (n1.Mantice + n2.Mantice * Math.Pow(10, n2.Power - n1.Power), n1.Power);
        }
        public static FloatNum operator -(FloatNum n1, FloatNum n2)
        {
            return new (n1.Mantice - n2.Mantice * Math.Pow(10, n2.Power - n1.Power), n1.Power);
        }
        public static bool operator >(FloatNum n1, FloatNum n2)
        {
            return n1.Mantice > n2.Mantice * Math.Pow(10, n2.Power - n1.Power);
        }
        public static bool operator <(FloatNum n1, FloatNum n2)
        {
            return n1.Mantice < n2.Mantice * Math.Pow(10, n2.Power - n1.Power);
        }

        public static FloatNum operator ++(FloatNum n)
        {
            return new (n.Mantice + Math.Pow(10, -n.Power), n.Power);
        }
        public static FloatNum operator --(FloatNum n)
        {
            return new (n.Mantice - Math.Pow(10, -n.Power), n.Power);
        }
        public void Print(){ Console.WriteLine($"{Math.Round(Mantice, 3)}E{Power}");}
    }
}