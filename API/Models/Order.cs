using System;

namespace API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual List<OrderedItem> OrderedItems { get; set; }
    }
}