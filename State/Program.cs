using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace State
{
    class Program
    {
        public enum MyState
        {
            Locked,
            Failed,
            Unlocked
        }

        static void Main(string[] args)
        {
            var code = "1234";
            var state = MyState.Locked;
            var entry = new StringBuilder();

            while (true)
            {
                switch (state)
                {
                    case MyState.Locked:
                        entry.Append(ReadKey().KeyChar);

                        if(entry.ToString() == code)
                        {
                            state = MyState.Unlocked;
                            break;
                        }
                        
                        if(!code.StartsWith(entry.ToString()))
                        {
                            state = MyState.Failed;
                        }
                        break;
                    case MyState.Failed:
                        CursorLeft = 0;
                        WriteLine("FAILED");
                        entry.Clear();
                        state = MyState.Locked;
                        break;
                    case MyState.Unlocked:
                        CursorLeft = 0;
                        WriteLine("UNLOCKED");
                        return;
                }

            }
        }
    }
}
