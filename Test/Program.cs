using System;
using Stacks;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            Console.WriteLine(ArrayStack.IsCorrectParentheses("{( x+y )}"));
            Console.WriteLine(ArrayStack.IsCorrectParentheses("({ x+y })"));
        }
    }
}
