using System;

class Program
    {
    // Run
        static void Main(string[] arg)
        {
        //Solve(3, "A", "B", "C");
        //Console.Write("Fibonacci is " + Result + " ");
        PrintFibo(10);
        Console.ReadLine();
        }

    // Function
        static void Solve(int d, string S, string A, string D)
    {
        if (d == 0) return;

        // S -> A
        Solve(d - 1, S, D, A);
        // (d)
        Console.WriteLine("Move Disk " + (d) + " from rod " + S + " to rod " + D);
        // A -> D
        Solve(d - 1, D, A, S);

    }

    static int Fibo(int n)
    {
        if (n == 0) { return 1; }
        if (n <= 1) { return n; }
        return Fibo(n - 1) + Fibo(n - 2);
    }
    static void PrintFibo(int n)
    {
        if (n <= 0) { return; }
        PrintFibo(n - 1);
        Console.WriteLine(Fibo(n-1) + " ");
    }
    }

