using System;
using System.Collections.Generic;
using asp_assignment.Models.BagStore;

namespace asp_assignment.ViewModels.Cart
{
    public class IndexViewModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public IEnumerable<Category> TopLevelCategories { get; set; }
        public IndexMessage Message { get; set; }
    }

    public enum IndexMessage
    {
        None,
        ItemNotInStock,
        ItemAdded,
        ItemRemoved,
        CartCleared
    }

    public static class IndexMessageExtensions
    {
        public static string GetMessage(this IndexMessage message)
        {
            switch (message)
            {
                case IndexMessage.ItemNotInStock:
                    return "Item is not in stock";
                case IndexMessage.ItemAdded:
                    return "Item added to your cart";
                case IndexMessage.ItemRemoved:
                    return "Item removed from your cart";
                case IndexMessage.CartCleared:
                    return "Cart has been cleared!";
                default:
                    return string.Empty;
            }
        }
    }
}