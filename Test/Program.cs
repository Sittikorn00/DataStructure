using System;
using Lists;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List x = new ArrayList(2);
            x.add("a");
            x.add("b");
            x.add(1, "c");
            x.remove("c");
            x.remove(0);


            Console.WriteLine(x.size());
        }
    }
}
