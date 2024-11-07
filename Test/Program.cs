using System;
using Sorts;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sort s = new ArraySort(3);
            s.add(8); s.view();
            s.add(4); s.view();
            s.add(5); s.view();
            s.add(1); s.view();
            s.add(2); s.view();
            s.add(2); s.view();
        }
    }
}

