using System;
using System.Numerics;

namespace ContinuationPassingStyle
{
    public enum WorkflowResult
    {
        Success,
        Failure
    }

    public class QuadraticEquationSolver
    {
        // ax^2+bx+c == 0
        public WorkflowResult Start(double a, double b, double c, out Tuple<Complex, Complex> result)
        {
            var disc = b * b - 4 * a * c;
            if (disc < 0)
            {
                result = null;
                return WorkflowResult.Failure;
            }
            else
            {
                return SolveSimple(a, b, c, disc, out result);
            }
        }

        private WorkflowResult SolveSimple(double a, double b, double c, double disc, out Tuple<Complex, Complex> result)
        {
            var rootDisc = Math.Sqrt(disc);

            result = Tuple.Create(
                new Complex((-b + rootDisc) / (2 * a), 0),
                new Complex((-b - rootDisc) / (2 * a), 0)
            );

            return WorkflowResult.Success;
        }

        private Tuple<Complex, Complex> SolveComplex(double a, double b, double c, double disc)
        {
            var rootDisc = Complex.Sqrt(new Complex(disc, 0));
            return Tuple.Create(
                (-b + rootDisc) / (2 * a),
                (-b - rootDisc) / (2 * a)
            );
        }
    }
}