using System;
using System.Collections.Generic;

namespace Collections.Samples
{
    public class StackSample
    {
        public static void Sample()
        {
            // Creates and initializes a new Stack.
            Stack<string> myStack = new Stack<string>();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");

            // Displays the properties and values of the Stack.
            Console.WriteLine("\tCount:    {0}", myStack.Count);
            Console.Write("\tValues:");
            foreach (var item in myStack)
            {
                Console.Write("    {0}", item);
            }
        }
    }
}
