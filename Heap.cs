using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace HELP_I_NEED_SOMEBODY
{
    public class Heap
    {
        public List<double> numbers;
        private int listSize;

        public Heap(List<double> values)
        {
            numbers = values;
            listSize = numbers.Count;
            for (int ctr = listSize / 2; ctr >= 0; ctr--) Heapify(ctr);
        }
        public Heap()
        {
            numbers = new List<double>();
            listSize = 0;
        }
        public void Add(double val)
        {
            numbers.Insert(0, val);
            Heapify(0);
        }
        private void Heapify(int ind)
        {
            if (listSize < 2*ind+2) return;
            if (listSize == 2*ind+2)
            {
                if (numbers[2 * ind + 1] > numbers[ind])
                {
                    (numbers[2*ind+1], numbers[ind]) = (numbers[ind], numbers[2 * ind + 1]);
                }
                return;
            }
            // in case of max heap:
            if (numbers[2*ind+1] >= numbers[2*ind+2] && numbers[2*ind+1] > numbers[ind])
            {
                (numbers[2*ind+1], numbers[ind]) = (numbers[ind], numbers[2*ind+1]);
                Heapify(2 * ind + 1);
            }
            else if (numbers[2*ind+2] >= numbers[2*ind+1] && numbers[2*ind+2] > numbers[ind])
            {
                (numbers[2*ind+2], numbers[ind]) = (numbers[ind], numbers[2*ind+2]);
                Heapify(2*ind+2);
            }
            /*//in case of min heap:
             if (numbers[2*ind+1] <= numbers[2*ind+2] && numbers[2*ind+1] < numbers[ind])
            {
                (numbers[2*ind+1], numbers[ind]) = (numbers[ind], numbers[2*ind+1]);
                Heapify(2 * ind + 1);
            }
            else if (numbers[2*ind+2] <= numbers[2*ind+1] && numbers[2*ind+2] < numbers[ind])
            {
                (numbers[2*ind+2], numbers[ind]) = (numbers[ind], numbers[2*ind+2]);
                Heapify(2*ind+2);
            }
            */
        }
    }
}