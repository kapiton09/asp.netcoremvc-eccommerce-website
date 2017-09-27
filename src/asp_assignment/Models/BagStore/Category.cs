using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp_assignment.Models.BagStore
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string DisplayName { get; set; }

        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> Children { get; set; }

        public List<Product> Products { get; set; }
    }
}
