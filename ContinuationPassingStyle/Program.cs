using System;
using System.Numerics;
using static System.Console;

namespace ContinuationPassingStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new QuadraticEquationSolver();
            Tuple<Complex, Complex> solution;
            var flag = solver.Start(1, 10, 16, out solution);
            if (flag == WorkflowResult.Success)
            {

            }
        }
    }
}
