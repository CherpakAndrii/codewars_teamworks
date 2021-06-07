using System;

namespace HELP_I_NEED_SOMEBODY
{
    public class Event
    {
        public string name;
        public int h, m;

        public Event(string nm, string date)
        {
            name = nm;
            string[] splited = date.Split(":");
            h = Convert.ToInt32(splited[0]);
            m = Convert.ToInt32(splited[1]);
        }
        
        public static bool operator >(Event e1, Event e2)
        {
            return e1.m + e1.h * 60 > e2.m + e2.h * 60;
        }
        
        public static bool operator <(Event e1, Event e2)
        {
            return e1.m + e1.h * 60 < e2.m + e2.h * 60;
        }

        public static int operator -(Event e1, Event e2)
        {
            return e1.m + e1.h * 60 - e2.m - e2.h * 60;
        }

        public string ToHours(int num) 
        {
            return $"{num/60} hours, {num%60} minutes";
        }
    }
}