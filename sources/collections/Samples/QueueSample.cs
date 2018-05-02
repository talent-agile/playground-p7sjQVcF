using System;
using System.Collections.Generic;

namespace Collections.Samples
{
    public class QueueSample
    {
        public static void Sample()
        {
            // Creates and initializes a new Queue.
            Queue<string> myQ = new Queue<string>();
            myQ.Enqueue("Hello");
            myQ.Enqueue("World");
            myQ.Enqueue("!");

            // Displays the properties and values of the Queue.
            Console.WriteLine("\tCount:    {0}", myQ.Count);
            Console.Write("\tValues:");
            foreach(var item in myQ)
            {
                Console.Write("    {0}", item);
            }
        }
    }
}
