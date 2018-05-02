using System;

namespace ValueTypes
{
    internal static class TechIo
    {
        public static void PrintMessage(string channel, string message)
        {
            Console.WriteLine($"TECHIO> message --channel \"{channel}\" \"{message}\"");
        }
    }
}
