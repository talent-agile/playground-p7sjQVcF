namespace Linq.Domain
{
    class Order
    {
        public OrderItem[] Items;
        public decimal Price { get; set; }

        public Account Account { get; set; }

        public Date Date { get; set; }
    }
}