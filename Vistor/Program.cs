using System;
using System.Text;
using static System.Console;

namespace Vistor
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression e = new AdditionExpression(
                new DoubleExpression(1),
                new AdditionExpression(
                    new DoubleExpression(2),
                    new DoubleExpression(3)
                ));
            var ep = new ExpressionPrinter();
            var sb = new StringBuilder();
            ep.Print((dynamic)e, sb);
            WriteLine(sb);
        }
    }
}
