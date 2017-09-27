using System;using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using asp_application1.Data;

namespace asp_application1.Models
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any bags.
            if (context.Bags.Any())
            {
                return;   // DB has been seeded
            }

            var bags = new Bag[]
            {
            new Bag{Name="Gucci", Price=1000, Description="A designer fashion bag for women. Gucci Branded", CategoryID=1, SupplierID=4 },
            new Bag{Name="Prado", Price=499, Description="A designer fashion bag for women. Prado Branded", CategoryID=1, SupplierID=5 },
            new Bag{Name="MK", Price=499, Description="A designer fashion bag for women. Michael Kors Branded", CategoryID=1, SupplierID=3 },
            new Bag{Name="Adidas", Price=100, Description="A designer Adidas Branded bag", CategoryID=2, SupplierID=1 },
            new Bag{Name="Nike", Price=120, Description="Sports bag from Nike", CategoryID=2, SupplierID=1 },
            new Bag{Name="Puma", Price=85, Description="Puma Brand", CategoryID=1, SupplierID=2 },
            new Bag{Name="Superman Kids Bag", Price=50, Description="Kids Bag", CategoryID=3, SupplierID=2 },
            };
            foreach (Bag s in bags)
            {
                context.Bags.Add(s);
            }
            context.SaveChanges();

            //var category = new Category[]
            //{
            //new Category{ Name="Women"},
            //new Category{ Name="Men"},
            //new Category{ Name="Kids"},
            //};
            //foreach (Category c in category)
            //{
            //    context.Categories.Add(c);
            //}
            //context.SaveChanges();

            //var supplier = new Supplier[]
            //{
            //new Supplier{ Name="Super Bag Wholeseller", WorkPhone=095550255, Email="superbag@gmail.com"},
            //new Supplier{ Name="Wholesale Bags", WorkPhone=09123225, Email="Wbag@gmail.com"},
            //new Supplier{ Name="MK Wholesellers", WorkPhone=09521255, Email="mk@gmail.com"},
            //new Supplier{ Name="Gucci Wholeseller", WorkPhone=095345555, Email="gucci@gmail.com"},
            //new Supplier{ Name="Prado Wholeseller", WorkPhone=097634355, Email="prado@gmail.com"},
            //};
            //foreach (Supplier e in supplier)
            //{
            //    context.Suppliers.Add(e);
            //}
            //context.SaveChanges();
        }
    }
}