using System;

namespace HELP_I_NEED_SOMEBODY
{
    public class RealNum
    {
        public int Z;
        public double D;

        public RealNum(string str)
        {
            string[] splited = str.Split(",");
            Z = int.Parse(splited[0]);
            D = double.Parse("0,"+splited[1]);
        }
        public static RealNum operator +(RealNum n1, RealNum n2)
        {
            return new (""+(n1.D+n1.Z+n2.D+n2.Z));
        }
        public static RealNum operator -(RealNum n1, RealNum n2)
        {
            return new (""+(n1.D+n1.Z-n2.D-n2.Z));
        }
        public static RealNum operator *(RealNum n1, RealNum n2)
        {
            return new ((n1.D+n1.Z)*(n2.D+n2.Z)+"");
        }
        public static RealNum operator /(RealNum n1, RealNum n2)
        {
            return new ((n1.D+n1.Z)/(n2.D+n2.Z)+"");
        }
        public static RealNum operator ++(RealNum n)
        {
            return new (n.Z+n.D+1+"");
        }
        public static RealNum operator --(RealNum n)
        {
            return new (n.Z+n.D-1+"");
        }
        public void Print(){ Console.WriteLine($"{Z}.{Convert.ToString(D).Split(",")[1]}");}
    }
}