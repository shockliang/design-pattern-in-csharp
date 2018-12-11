using System;

namespace Observer
{
    public class FallsIllEventArgs : EventArgs
    {
        public string Address;
    }

    public class Person
    {
        public event EventHandler<FallsIllEventArgs> FallsIll;

        public void CatchACold()
        {
            FallsIll?.Invoke(this, new FallsIllEventArgs()
            {
                Address = "Somewhere"
            });
        }
    }
}