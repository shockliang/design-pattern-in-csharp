using System;
using static System.Console;

namespace ContinuationPassingStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new QuadraticEquationSolver();
            var solutions = solver.Start(1, 10, 16);
        }
    }
}
