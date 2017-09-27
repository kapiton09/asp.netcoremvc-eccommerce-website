using System;
using System.Collections.Generic;
using asp_assignment.Models.BagStore;

namespace asp_assignment.ViewModels.Shop
{
    public class SearchViewModel
    {
        public string SearchTerm { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> TopLevelCategories { get; set; }
    }
}