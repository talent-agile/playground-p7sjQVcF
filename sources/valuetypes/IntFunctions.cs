using System;

// { autofold
namespace ValueTypes
{
    public static class IntFunctions
    {
// }
        private static void Increment(int value)
        {
            value = value + 1;
        }

        public static int ExecuteIncrement(int value)
        {
            Increment(value);
            return value;
        }
// { autofold
    }
}
// }
