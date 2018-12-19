using System;
using static System.Console;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var tp = new TextProcessor<MarkdownListStrategy>();
            tp.AppendList(new[] { "foo", "bar", "baz" });
            WriteLine(tp);

            var tp2 = new TextProcessor<HtmlListStrategy>();
            tp2.AppendList(new[] { "foo", "bar", "baz" });
            WriteLine(tp2);
        }
    }
}
