using System;
using System.Linq;
using static System.Console;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            //   1
            //  / \
            // 2   3

            // in-order: 213

            var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
            var it = new InOrderIterator<int>(root);
            while (it.MoveNext())
            {
                Write(it.Current.Value);
                Write(',');
            }
            WriteLine();

            var tree = new BinaryTree<int>(root);
            WriteLine(string.Join(",", tree.InOrder.Select(x => x.Value)));

        }
    }
}
