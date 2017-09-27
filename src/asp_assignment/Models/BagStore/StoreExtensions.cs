using System.Linq;

namespace asp_assignment.Models.BagStore
{
    public static class StoreExtensions
    {
        public static void EnsureSeedData(this StoreContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.Products.Any())
                {
                    var bag = context.Categories.Add(new Category { DisplayName = "Bag" }).Entity;
                    var mensBag = context.Categories.Add(new Category { DisplayName = "Mens Bag", ParentCategory = bag }).Entity;
                    var womensBag = context.Categories.Add(new Category { DisplayName = "Womens Bag", ParentCategory = bag }).Entity;
                    var kidsBag = context.Categories.Add(new Category { DisplayName = "Kids Bag", ParentCategory = bag }).Entity;

                    var wholesaleSupplier = context.Suppliers.Add(new Supplier { Name = "Wholesale Suppliers", WorkPhone = 095550255, Email = "shresk03@myunitec.ac.nz" }).Entity;
                    var qualitySupplier = context.Suppliers.Add(new Supplier { Name = "Quality Suppliers", WorkPhone = 095120255, Email = "shresk03@myunitec.ac.nz" }).Entity;
                    var shresthaSupplier = context.Suppliers.Add(new Supplier { Name = "Shrestha Suppliers", WorkPhone = 02108317604, Email = "kapiton_212@hotmail.com" }).Entity;

                    context.Products.AddRange(
                        new Product { SKU = "MEN001", DisplayName = "Quality Sidebag (Brown)", MSRP = 72.95M, CurrentPrice = 72.95M, Category = mensBag, Supplier = shresthaSupplier , ImageUrl = "/images/products/men_bag_4.jpg", Description = "Quality Mens bag" },
                        new Product { SKU = "MEN002", DisplayName = "Leather Sidebag (Brown)", MSRP = 82.95M, CurrentPrice = 80.95M, Category = mensBag, Supplier = wholesaleSupplier, ImageUrl = "/images/products/men_bag_6.jpg", Description = "Quality Mens bag" },
                        new Product { SKU = "MEN003", DisplayName = "Quality Backpack (Brown)", MSRP = 52.95M, CurrentPrice = 52.95M, Category = mensBag, Supplier = shresthaSupplier, ImageUrl = "/images/products/men_bag_8.jpg", Description = "Quality Mens bag" },
                        new Product { SKU = "WOM201", DisplayName = "Shining Quality Bag (Cyan)", MSRP = 72.95M, CurrentPrice = 72.95M, Category = womensBag, Supplier = qualitySupplier, ImageUrl = "/images/products/women_bag_4.jpg", Description = "Quality Womens bag" },
                        new Product { SKU = "WOM202", DisplayName = "Designer Bag (Blue)", MSRP = 89.95M, CurrentPrice = 89.95M, Category = womensBag, Supplier = shresthaSupplier, ImageUrl = "/images/products/women_bag_5.jpg", Description = "Quality Womens bag" },
                        new Product { SKU = "KID203", DisplayName = "Minion Bag", MSRP = 19.95M, CurrentPrice = 17.95M, Category = kidsBag, Supplier = qualitySupplier, ImageUrl = "/images/products/kids_bag_4.jpg", Description = "Share your love of minions with the world. Quality bag with a long lasting print." },
                        new Product { SKU = "KID204", DisplayName = "Superman print bag", MSRP = 24.95M, CurrentPrice = 19.95M, Category = kidsBag, Supplier = shresthaSupplier, ImageUrl = "/images/products/kids_bag_7.jpg", Description = "Share your love of Batman with the world. Quality bag with a long lasting print." });

                    context.SaveChanges();
                }

                if (!context.WebsiteAds.Any())
                {
                    //var womensBag = context.Categories.Single(c => c.DisplayName == "Women Bag");
                    //var mensBag = context.Categories.Single(c => c.DisplayName == "Men Bag");

                    context.WebsiteAds.Add(new WebsiteAd { ImageUrl = "/images/banners/banner1.jpg", TagLine = "Welcome to Quality Bag Store", Details = "Best online store", Url = "http://dochyper.unitec.ac.nz/shresk03/asp_assignment" });
                    context.WebsiteAds.Add(new WebsiteAd { ImageUrl = "/images/banners/banner2.jpg", TagLine = "Women Bags", Details = "shresk03", Url = "/shop/" });
                    context.WebsiteAds.Add(new WebsiteAd { ImageUrl = "/images/banners/banner3.jpg", TagLine = "Get the best bargain", Details = "Available in the Quality bag store", Url = "/shop/" });
                    context.SaveChanges();
                }
            }
        }
    }
}
