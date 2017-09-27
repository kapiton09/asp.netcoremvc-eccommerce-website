using System;
using System.Collections.Generic;

namespace asp_application1.Models
{
    public class Bag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}
