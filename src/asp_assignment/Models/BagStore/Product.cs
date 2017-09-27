using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace asp_assignment.Models.BagStore
{
    public class Product
    {
        public int ProductId { get; set; }
        [Display(Name = "Product Code")]
        public string SKU { get; set; }
        [Required]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0.10, 100000, ErrorMessage = "Price range should be between 0.10 and 100,000")]
        [Display(Name ="Actual Price")]
        public decimal MSRP { get; set; }
        [Required]
        [Range(0.10,100000,ErrorMessage ="Price range should be between 0.10 and 100,000")]
        [Display(Name = "Discounted Price")]
        public decimal CurrentPrice { get; set; }
        public string ImageUrl { get; set; }
        public bool InStock { get; set; }

        public decimal Savings
        {
            get { return MSRP - CurrentPrice; }
        }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
