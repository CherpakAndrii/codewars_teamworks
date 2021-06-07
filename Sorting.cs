using System;
using System.Collections.Generic;

namespace HELP_I_NEED_SOMEBODY
{
    public class HowToSortAndCompare
    {
        public static int Comparer(string s1, string s2)
        {
            return s1.Length > s2.Length ? 1 : s1.Length == s2.Length ? 0 : -1;
            //return s1.Length.CompareTo(s2.Length);
        }

        public void Example()
        {
            List<string> lst1 = new List<string> {"5", "6", "2", "7", "9", "1"};
            string[] arr1 = {"5", "6", "2", "7", "9", "1"};
            lst1.Sort(Comparer);
            Array.Sort(arr1, Comparer);
            Array.Reverse(arr1);
            Array.Sort(arr1, delegate(string s, string s1) {  return s.Length.CompareTo(s1.Length);});
            lst1.Sort(delegate(string s, string s1) {  return s.Length.CompareTo(s1.Length);});
            
        }
    }
}