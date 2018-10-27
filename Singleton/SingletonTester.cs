using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace Singleton
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var instance1 = func.Invoke();
            var instance2 = func.Invoke();
            return instance1 == instance2;
        }
    }
}