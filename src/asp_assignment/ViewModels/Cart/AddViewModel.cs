using System;
using System.Collections.Generic;
using asp_assignment.Models.BagStore;

namespace asp_assignment.ViewModels.Cart
{
    public class AddViewModel
    {
        public CartItem CartItem { get; set; }
        public IEnumerable<Category> TopLevelCategories { get; set; }
    }
}