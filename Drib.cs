using System;

namespace HELP_I_NEED_SOMEBODY
{
    public class Drib
    {
        public int ch;
        public int zn;

        public Drib(string str)
        {
            string[] splited = str.Split(":");
            ch = int.Parse(splited[0]);
            zn = int.Parse(splited[1]);
            for (int i = 2; i <= ch / 2; i++)
            {
                if (ch % i == 0 && zn % i == 0)
                {
                    ch /= i;
                    zn /= i;
                    i--;
                }
            }
        }
        public void Print() => Console.WriteLine($"{ch}:{zn}");

        public static Drib operator +(Drib d1, Drib d2)
        {
            return new($"{d1.ch * d2.zn + d2.ch * d1.zn}:{d1.zn * d2.zn}");
        }
        
        public static Drib operator -(Drib d1, Drib d2)
        {
            return new($"{d1.ch * d2.zn - d2.ch * d1.zn}:{d1.zn * d2.zn}");
        }
        
        public static Drib operator *(Drib d1, Drib d2)
        {
            return new($"{d1.ch * d2.ch}:{d1.zn * d2.zn}");
        }
        
        public static Drib operator /(Drib d1, Drib d2)
        {
            return new($"{d1.ch * d2.zn}:{d1.zn * d2.ch}");
        }

        public static Drib operator ++(Drib d)
        {
            return new($"{d.ch + d.zn}:{d.zn}");
        }
        
        public static Drib operator --(Drib d)
        {
            return new($"{d.ch - d.zn}:{d.zn}");
        }
    }
}