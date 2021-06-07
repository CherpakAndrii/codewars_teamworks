using System;
using System.Collections.Generic;

namespace HELP_I_NEED_SOMEBODY
{
    public class RaredArray
    {
        public LinkedList<Tuple<int, int>> data;
        private int arrSize;
        public RaredArray(int[] rared)
        {
            arrSize = rared.Length;
            data = new LinkedList<Tuple<int, int>>();
            for (int i = 0; i < rared.Length; i++)
            {
                if (rared[i] != 0) data.AddLast(new Tuple<int, int>(i, rared[i]));
            }
        }

        public void PrintAsArray()
        {
            int[] arr = new int[arrSize];
            foreach (Tuple<int, int> pair in data)
            {
                arr[pair.Item1] = pair.Item2;
            }
            if (arrSize == 0)
            {
                Console.WriteLine("Empty array");
                return;
            }
            Console.Write($"[{arr[0]}");
            for (int i = 1; i<arrSize; i++)
            {
                Console.Write(", "+arr[i]);
            }
            Console.WriteLine("]");
        }
        
        public void PrintAsLinkedList()
        {
            foreach (Tuple<int, int> pair in data)
            {
                Console.Write($"-> ({pair.Item1}, {pair.Item2}) ");
            }
            Console.WriteLine();
        }
    }
}