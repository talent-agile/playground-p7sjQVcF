// { autofold
using System;
using System.Collections.Generic;
using System.Text;
// }

namespace Answer
{
    internal class Employee : IEquatable<Employee>
    {
        public int Id;
        public string Name;

        // FIX IT, tips: use "this" and "other" object to code it
        public bool Equals(Employee other)
        {
            return false; 
        }
    }
    
    public class EqualStub
    {
        public static bool IsEqual()
        {
            // }
            Employee employee1 = new Employee() { Id = 1, Name = "John" };
            Employee employee2 = new Employee() { Id = 2, Name = "Mike" };

            var r = employee1.Equals(employee2);
            // { autofold
            Console.WriteLine(string.Format("{0} is equal {1} ? {2}", employee1.Name, employee2.Name, r));
            return r;
        }
        // }
    }
}
