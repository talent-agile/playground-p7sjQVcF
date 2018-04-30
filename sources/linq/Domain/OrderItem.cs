using System.Diagnostics;

namespace Linq.Domain
{
    [DebuggerDisplay("{Product,nq} #{Count,nq}")]
    internal class OrderItem
    {
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}