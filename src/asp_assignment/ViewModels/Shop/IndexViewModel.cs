using System;
using System.Collections.Generic;
using asp_assignment.Models.BagStore;

namespace asp_assignment.ViewModels.Shop
{
    public class IndexViewModel
    {
        public IEnumerable<Product> FeaturedProducts { get; set; }
        public IEnumerable<Category> TopLevelCategories { get; set; }
    }
}