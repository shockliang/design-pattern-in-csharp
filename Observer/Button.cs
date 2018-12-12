using System;
using System.Windows;
using static System.Console;

namespace Observer
{
    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            // Only on .net framework.
            // WeakEventManager<Button, EventArgs>
            //  .AddHandler(button, "Clicked", ButtonOnClicked);

            button.Clicked += ButtonOnClicked;
        }

        ~Window()
        {
            WriteLine("Window finalized");
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            WriteLine("Button clicked (Window handler)");
        }
    }
}