using System;

namespace Warehouse1.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ClosedAt { get; set; }
    }
}
