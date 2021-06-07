using System;

namespace HELP_I_NEED_SOMEBODY
{
    public class IntInBin
    {
        public string NumInBin;
        public string Sign;
        public IntInBin(string num)
        {
            int val = Convert.ToInt32(num);
            Sign = val >= 0 ? "0" : "1";
            val = Math.Abs(val);
            NumInBin = "";
            while (val>0)
            {
                NumInBin = val % 2 + NumInBin;
                val /= 2;
            }
        }

        public string BinToString()
        {
            string result = NumInBin;
            if (result.Length < 8) while (result.Length < 7) result = "0" + result;
            else if (result.Length < 16) while (result.Length < 15) result = "0" + result;
            else if (result.Length < 32) while (result.Length < 31) result = "0" + result;
            result = Sign + result;
            return result;
        }

        private int BinToInt()
        {
            int val = 0;
            for (int i=0; i<NumInBin.Length; i++) if (NumInBin[NumInBin.Length-1-i]=='1') val+=(int)Math.Pow(2, i);
            if (Sign == "1") val *= -1;
            return val;
        }

        public static IntInBin operator +(IntInBin n1, IntInBin n2)
        {
            return new (Convert.ToString(n1.BinToInt() + n2.BinToInt()));
        }
        public static IntInBin operator -(IntInBin n1, IntInBin n2)
        {
            return new (Convert.ToString(n1.BinToInt() - n2.BinToInt()));
        }
        public static IntInBin operator --(IntInBin n1)
        {
            return new (Convert.ToString(n1.BinToInt()-1));
        }
        public static IntInBin operator ++(IntInBin n1)
        {
            return new (Convert.ToString(n1.BinToInt()+1));
        }
    }
}