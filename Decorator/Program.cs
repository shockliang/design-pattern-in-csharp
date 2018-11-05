using System;
using System.Text;
using static System.Console;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var redSquare = new ColoredShape<Square>("red");
            WriteLine(redSquare.AsString());

            var circle = new TransparentShape<ColoredShape<Circle>>(0.4f);
            WriteLine(circle.AsString());
        }
    }
}
