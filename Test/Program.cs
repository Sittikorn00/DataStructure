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
            string exp = "80+40-30";

            InfixPostfix.Converter(exp);

            string postfixExpression = "8040+30-";
            InfixPostfix.Calculator(postfixExpression);

            char[,] maze = {
                { 'S', '0', '0', '1', 'E' },
                { '1', '1', '0', '0', '1' },
                { '0', '0', '1', '0', '0' },
                { '1', '1', '1', '0', '1' },
                { '0', '0', '0', '0', '0' } };

            MazeSolver.MazeRunner(maze);

            int[] numbers = { 170, 45, 75, 90, -802, 24, 2, 66 };
            // เรียกใช้ RadixSort
            ArrayQueue.RadixSort(numbers);
        }
    }
}
