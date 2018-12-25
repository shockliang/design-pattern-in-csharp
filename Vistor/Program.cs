using System;
using System.Text;
using static System.Console;

namespace Vistor
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new AdditionExpression(
                new DoubleExpression(1),
                new AdditionExpression(
                    new DoubleExpression(2),
                    new DoubleExpression(3)
                ));

            var sb = new StringBuilder();
            ExpressionPrinter.Print(e, sb);
            WriteLine(sb.ToString());
        }
    }
}
