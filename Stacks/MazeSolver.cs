using System;
using System.Collections.Generic;

namespace Stacks
{
    public class MazeSolver
    {
        public static void MazeRunner(char[,] maze)
        {
            int i = StartAt(maze).Item1; int j = StartAt(maze).Item2;
            Console.Write("Start Position: "); Display(maze, i, j);
            Stack<(int, int)> path = new Stack<(int, int)>(); //เก็บเส้นทางที่กำลังจะเดินไป (FIFO)
            List<(int, int)> track = new List<(int, int)>(); //เก็บเส้นทางสำหรับเดินย้อนกลับ (LIFO)
            while (maze[i, j] != 'E') //วนลูปไปเรื่อยๆจนกว่าจะเจอทางออก
            {
                maze[i, j] = '.'; //เดินไปแล้วให้เปลี่ยนเป็นจุด
                track.Add((i, j));
                foreach (var (m, n) in new List<(int, int)>
                    { (i - 1, j),(i + 1, j), (i, j - 1),(i, j + 1)}) //เช็ค 4 ทิศทาง บน,ล่าง,ซ้าย,ขวา
                    if (IsInMaze(maze, m, n) && (maze[m, n] == '0' || maze[m, n] == 'E')/*ทางที่เดินได้*/) path.Push((m, n));
                if (path.Count > 0) { var dir = path.Pop(); i = dir.Item1; j = dir.Item2; }
                else { Console.WriteLine("Can't escape!"); break; }
            }
            if (maze[i, j] == 'E') Console.WriteLine("Can escape!");
            Console.Write("End Position: "); Display(maze, i, j);
        }
        private static (int, int) StartAt(char[,] maze) //หาจุดเริ่มต้น
        {
            for (int i = 0; i < maze.GetLength(0); i++) //0 = Row ,1 = column
                for (int j = 0; j < maze.GetLength(1); j++)
                    if (maze[i, j] == 'S') return (i, j);
            throw new Exception("Can't locate the start point!");
        }
        private static bool IsInMaze(char[,] maze, int i, int j)
        {
            return (uint)i < maze.GetLength(0) && (uint)j < maze.GetLength(1); //uint = จน.เต็มบวก
        }
        private static void Display(char[,] maze, int i, int j)
        {
            Console.WriteLine((i, j));
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                    Console.Write(maze[row, col] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

