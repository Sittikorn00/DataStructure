using System;
using Sorts;

namespace Sorts
{
    public class ArraySort : Sort
    {
        int SIZE;
        object[] data;
        public ArraySort(int cap)
        {
            data = new object[cap];
        }

        public void add(object e)
        {
            
        }

        public void clear()
        {
            for (int i = 0; i < SIZE; i++)
                data[i] = null;
            SIZE = 0;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public int size()
        {
            return SIZE;
        }
        private void ensureCapacity()
        {
            if (SIZE + 1 > data.Length)
            {
                object[] tempdata = new object[2 * SIZE];
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[i];
                data = tempdata;
            }
        }
        public void view()
        {
            for (int i = 0; i < SIZE; i++)
                Console.Write(data[i] + " ");
            Console.WriteLine();
        }
    }
}
