using System;
using System.Collections.Generic;
using asp_assignment.Models.BagStore;

namespace asp_assignment.ViewModels.Shop
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> TopLevelCategories { get; set; }
        public IEnumerable<Category> CategoryHierarchy { get; set; }
    }
}