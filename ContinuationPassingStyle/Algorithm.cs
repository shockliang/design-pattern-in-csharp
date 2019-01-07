using System;
using System.Numerics;

namespace ContinuationPassingStyle
{
    public class Algorithm
    {

    }

    public class QuadraticEquationSolver
    {
        // ax^2+bx+c == 0
        public Tuple<Complex, Complex> Start(double a, double b, double c)
        {
            var disc = b * b - 4 * a * c;
            if (disc < 0)
                return SolveComplex(a, b, c, disc);
            else
                return SolveSimple(a, b, c, disc);
        }

        private Tuple<Complex, Complex> SolveSimple(double a, double b, double c, double disc)
        {
            var rootDisc = Math.Sqrt(disc);
            return Tuple.Create(
                new Complex((-b + rootDisc) / (2 * a), 0),
                new Complex((-b - rootDisc) / (2 * a), 0)
            );
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