using System;

namespace Buffers
{
    public class ArrayBuffer : Buffer
    {
        int SIZE;
        int cap;
        object[] data;
        public ArrayBuffer(int cap)
        {
            this.cap = cap;
            data = new object[cap];
        }
        public void add(object e)
        {
            data[SIZE < 2 ? SIZE : 2] = e;
            SIZE++;
        }

        public void clear()
        {
            data = null;
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

        public void view()
        {
            if (SIZE == 0)
            {
                Console.WriteLine("Empty");
                return;
            }
            for (int i = 0; i < cap; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
