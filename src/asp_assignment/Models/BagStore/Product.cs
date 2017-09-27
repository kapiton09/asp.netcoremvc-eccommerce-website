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
        public decimal MSRP { get; set; }
        public decimal CurrentPrice { get; set; }
        public string ImageUrl { get; set; }

        public decimal Savings
        {
            get { return MSRP - CurrentPrice; }
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
