# List

**Syntax**

`List<T> obj = new List<T>();`

Where "T" generic parameter you can pass any data-type or custom class object to this parameter.

@[Exercice]({"stubs": ["Exercises/ListStub.cs"],"command": "TechIo.CollectionsTests.VerifyProcessToKill", "project": "collections"})

:::Solution
Replace **TODO** by this code:

`
foreach (var p in process) { if (!p.Equals("Explorer.exe")) { processToKill.Add(p); } }
`
:::

# Dictionary
Dictionary is a generic collections which works on key and value pairs. Both key and value pair can have different data-types or same data-types or any custom types (i.e. class objects). Dictionary generic collections is a generic concept applied over Hashtable and it provides fast lookups with keys to get values.

**Syntax**

`Dictionary<T, T> obj = new Dictionary<T, T>();`

Where "T" generic parameter you can pass any data-type or custom class object to this parameter.

@[Exercice]({"stubs": ["Exercises/DictionaryStub.cs"],"command": "TechIo.CollectionsTests.VerifyCountByAges", "project": "collections"})

::: Solution
Replace **TODO** by this code: 
`
    if(result.ContainsKey(e.Age))
    {
            result[e.Age].Add(e.Name);
    }
    else
    {
        result.Add(e.Age, new List<string>() { e.Name });
    }
`
:::

# LIFO vs FIFO
## Stack
A stack is a collection of type **L**ast **I**n **F**irst **O**ut ("**LIFO**").

**Syntax**

`Stack obj = new Stack();`

```C# runnable
// { autofold
using System;
using System.Collections.Generic;

namespace Collections.Samples
{
    public class StackSample
    {
        public static void Main()
        {
// }
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
// { autofold
        }
    }
}
// }
```
## Queue
A queue is a collection of type **F**irst **I**n **F**irst **O**ut ("**FIFO**").

**Syntax**

`Queue obj = new Queue();`

```C# runnable
// { autofold
using System;
using System.Collections.Generic;

namespace Collections.Samples
{
    public class QueueSample
    {
        public static void Main()
        {
// }
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
// { autofold
        }
    }
}
// }
```
