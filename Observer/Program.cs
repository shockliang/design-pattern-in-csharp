using System;
using static System.Console;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var button = new Button();
            var window = new Window(button);
            var windowRef = new WeakReference(window);
            button.Fire();

            WriteLine("Setting window to null");
            window = null;

            FireGC();
            WriteLine($"Is the windows alive after GC? {windowRef.IsAlive}");
        }

        private static void FireGC()
        {
            WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            WriteLine("GC is done!");
        }
    }
}
