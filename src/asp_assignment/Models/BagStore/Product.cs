using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace asp_assignment.Models.BagStore
{
    public class Product
    {
        public int ProductId { get; set; }
        public string SKU { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0.10, 100000, ErrorMessage = "Price range should be between 0.10 and 100,000")]
        public decimal MSRP { get; set; }
        [Required]
        [Range(0.10,100000,ErrorMessage ="Price range should be between 0.10 and 100,000")]
        public decimal CurrentPrice { get; set; }
        public string ImageUrl { get; set; }

        public decimal Savings
        {
            get { return MSRP - CurrentPrice; }
        }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
