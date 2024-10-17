using System;
using Collections;
using Queues;
using Stacks;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue x = new BinaryHeap(5);
            x.enqueue(10); x.enqueue(21); x.enqueue(11); x.enqueue(43); x.enqueue(12);
            x.dequeue();

            for (int i = 0; i < x.size(); i++)
                Console.WriteLine(x.peek());

        }
    }
}

