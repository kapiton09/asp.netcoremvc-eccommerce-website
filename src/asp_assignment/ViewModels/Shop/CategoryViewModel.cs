using System;
using System.Collections.Generic;
using asp_assignment.Models.BagStore;

namespace asp_assignment.ViewModels.Shop
{
    public class CategoryViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Category> ParentHierarchy { get; set; }
        public IEnumerable<Category> Children { get; set; }
    }
}