using System;
using System.Text;
using static System.Console;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder();
            cb.AppendLine("class Foo")
                .AppendLine("{")
                .AppendLine("}");
                
            WriteLine(cb);
        }
    }
}
