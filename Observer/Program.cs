using System;
using static System.Console;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.FallsIll += CallDoctor;
            person.CatchACold();
            person.FallsIll - CallDoctor;
            person.CatchACold();
        }

        private static void CallDoctor(object sender, FallsIllEventArgs e)
        {
            WriteLine($"A Doctor has benn called to {e.Address}");
        }
    }
}
