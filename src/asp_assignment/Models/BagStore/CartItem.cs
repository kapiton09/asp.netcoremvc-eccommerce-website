using System;

namespace asp_assignment.Models.BagStore
{
    public class CartItem : ILineItem
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public DateTime PriceCalculated { get; set; }
        public string UserId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
