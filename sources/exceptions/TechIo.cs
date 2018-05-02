using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    internal static class TechIo
    {
        public static void PrintMessage(string channel, string message)
        {
            Console.WriteLine($"TECHIO> message --channel \"{channel}\" \"{message}\"");
        }
    }
}
