using System;
using Pipes;

namespace Pipes
{
    public class ArrayPipe : Pipe
    {
        int SIZE;
        object[] data;
        public ArrayPipe(int cap)
        {
            data = new object[cap];
        }

        public void clear()
        {
            for (int i = 0; i < SIZE; i++)
                data[i] = null;
            SIZE = 0;
        }


        public object add(object e)
        {
            return data[SIZE++] = e;
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
            for (int i = 0; i < SIZE; i++)
                Console.Write(data[i] + " ");
            Console.WriteLine();
        }
    }
}
