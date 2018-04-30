using System;
using System.Diagnostics;

namespace Linq.Domain
{
    [DebuggerDisplay("{Name,nq}")]
    class Product : IEquatable<Product>
    {
        public Category Category { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }



        public override string ToString()
        {
            return Name;
        }
    }
}