using System;
using Lists;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List x = new ArrayList(1);
            x.add("3");
            x.add("2");
            x.add(2,"1");


            Console.WriteLine(x.size());
        }
    }
}
