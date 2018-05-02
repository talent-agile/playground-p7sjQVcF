// { autofold
using System;

namespace Equality
{
// }
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
// { autofold
}
// }