using System;

namespace asp_assignment.Models.BagStore
{
    public interface ILineItem
    {
        Product Product { get; }
        int Quantity { get; }
        decimal PricePerUnit { get; }
    }
}
