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
                    var mensBag = context.Categories.Add(new Category { DisplayName = "Men Bags", ParentCategory = bag }).Entity;
                    var womensBag = context.Categories.Add(new Category { DisplayName = "Women Bags", ParentCategory = bag }).Entity;
                    var kidsBag = context.Categories.Add(new Category { DisplayName = "Kids Bags", ParentCategory = bag }).Entity;

                    var wholesaleSupplier = context.Suppliers.Add(new Supplier { Name = "Wholesale Suppliers", WorkPhone = 095550255, Email = "shresk03@myunitec.ac.nz" }).Entity;
                    var qualitySupplier = context.Suppliers.Add(new Supplier { Name = "Quality Suppliers", WorkPhone = 095120255, Email = "shresk03@myunitec.ac.nz" }).Entity;
                    var shresthaSupplier = context.Suppliers.Add(new Supplier { Name = "Shrestha Suppliers", WorkPhone = 02108317604, Email = "kapiton_212@hotmail.com" }).Entity;

                    context.Products.AddRange(
                        new Product {InStock=true, SKU = "MEN001", DisplayName = "Quality Leather Sidebag (Dark Brown)", MSRP = 102.95M, CurrentPrice = 72.95M, Category = mensBag, Supplier = shresthaSupplier , ImageUrl = "~/images/products/men-bag-1.jpg", Description = "Quality Mens bag" },
                        new Product {InStock=true, SKU = "MEN002", DisplayName = "Polo Sidebag (Brown)", MSRP = 82.95M, CurrentPrice = 80.95M, Category = mensBag, Supplier = wholesaleSupplier, ImageUrl = "~/images/products/men-bag-2.jpg", Description = "Quality Mens bag" },
                        new Product {InStock=true, SKU = "MEN003", DisplayName = "Sidebag (Brown)", MSRP = 52.95M, CurrentPrice = 42.95M, Category = mensBag, Supplier = shresthaSupplier, ImageUrl = "~/images/products/men-bag-3.jpg", Description = "Quality Mens bag" },
                        new Product {InStock=true, SKU = "MEN004", DisplayName = "Long Sidebag (Brown)", MSRP = 52.95M, CurrentPrice = 40.95M, Category = mensBag, Supplier = wholesaleSupplier, ImageUrl = "~/images/products/men-bag-4.jpg", Description = "Quality Mens bag" },
                        new Product { InStock = true, SKU = "MEN005", DisplayName = "Quality Sports bag (Brown)", MSRP = 52.95M, CurrentPrice = 52.95M, Category = mensBag, Supplier = shresthaSupplier, ImageUrl = "~/images/products/men-bag-5.jpg", Description = "Quality Mens bag" },
                        new Product { InStock = true, SKU = "MEN006", DisplayName = "Quality Dark Leather SideBag (Dark Brown)", MSRP = 182.95M, CurrentPrice = 80.95M, Category = mensBag, Supplier = wholesaleSupplier, ImageUrl = "~/images/products/men-bag-6.jpg", Description = "Quality Mens bag" },
                        new Product { InStock = true, SKU = "MEN007", DisplayName = "Long Leather Sidebag (Brown)", MSRP = 82.95M, CurrentPrice = 80.95M, Category = mensBag, Supplier = shresthaSupplier, ImageUrl = "~/images/products/men-bag-7.jpg", Description = "Quality Mens bag" },
                        new Product { InStock = true, SKU = "MEN008", DisplayName = "Laptop Backpack (Brown)", MSRP = 82.95M, CurrentPrice = 80.95M, Category = mensBag, Supplier = wholesaleSupplier, ImageUrl = "~/images/products/men-bag-8.jpg", Description = "Quality Mens bag" },
                        new Product { InStock = true, SKU = "MEN009", DisplayName = "Quality Sidebag (Black)", MSRP = 52.95M, CurrentPrice = 52.95M, Category = mensBag, Supplier = shresthaSupplier, ImageUrl = "~/images/products/men-bag-9.jpg", Description = "Quality Mens bag" },
                        new Product { InStock = true, SKU = "WOM201", DisplayName = "Quality Leather Bag (Brown)", MSRP = 92.95M, CurrentPrice = 72.95M, Category = womensBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/women-bag-1.jpg", Description = "Quality Womens bag" },
                        new Product { InStock = true, SKU = "WOM202", DisplayName = "Leather Bag (Brown)", MSRP = 89.95M, CurrentPrice = 89.95M, Category = womensBag, Supplier = shresthaSupplier, ImageUrl = "~/images/products/women-bag-2.jpg", Description = "Quality Womens bag" },
                        new Product { InStock = true, SKU = "WOM203", DisplayName = "Shining Quality Bag (Black)", MSRP = 72.95M, CurrentPrice = 72.95M, Category = womensBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/women-bag-3.jpg", Description = "Quality Womens bag" },
                        new Product { InStock = true, SKU = "WOM204", DisplayName = "Designer Bag (Cyan)", MSRP = 89.95M, CurrentPrice = 89.95M, Category = womensBag, Supplier = shresthaSupplier, ImageUrl = "~/images/products/women-bag-4.jpg", Description = "Quality Womens bag" },
                        new Product { InStock = true, SKU = "WOM205", DisplayName = "Shining Quality Bag (Blue)", MSRP = 72.95M, CurrentPrice = 72.95M, Category = womensBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/women-bag-5.jpg", Description = "Quality Womens bag" },
                        new Product { InStock = true, SKU = "WOM206", DisplayName = "Designer Bag (Grey)", MSRP = 89.95M, CurrentPrice = 89.95M, Category = womensBag, Supplier = shresthaSupplier, ImageUrl = "~/images/products/women-bag-6.jpg", Description = "Quality Womens bag" },
                        new Product { SKU = "WOM207", DisplayName = "Quality Bag (Cream)", MSRP = 72.95M, CurrentPrice = 72.95M, Category = womensBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/women-bag-7.jpg", Description = "Quality Womens bag" },
                        new Product { InStock = true, SKU = "WOM208", DisplayName = "Alligator Designer Bag (Brown)", MSRP = 289.95M, CurrentPrice = 189.95M, Category = womensBag, Supplier = shresthaSupplier, ImageUrl = "~/images/products/women-bag-8.jpg", Description = "Quality Womens bag" },
                        new Product { InStock = true, SKU = "WOM209", DisplayName = "Shining Quality Bag (Pink)", MSRP = 72.95M, CurrentPrice = 72.95M, Category = womensBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/women-bag-9.jpg", Description = "Quality Womens bag" },
                        new Product { InStock = true, SKU = "KID201", DisplayName = "Unicorn Shape Bag", MSRP = 19.95M, CurrentPrice = 17.95M, Category = kidsBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/kids-bag-1.jpg", Description = "Share your love of minions with the world. Quality bag with a long lasting print." },
                        new Product { InStock = true, SKU = "KID202", DisplayName = "Horse Bag", MSRP = 19.95M, CurrentPrice = 19.95M, Category = kidsBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/kids-bag-2.jpg", Description = "Share your love of minions with the world. Quality bag with a long lasting print." },
                        new Product { InStock = true, SKU = "KID203", DisplayName = "Unicorn Picture Bag", MSRP = 19.95M, CurrentPrice = 19.95M, Category = kidsBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/kids-bag-3.jpg", Description = "Share your love of minions with the world. Quality bag with a long lasting print." },
                        new Product { InStock = true, SKU = "KID204", DisplayName = "Minion Bag", MSRP = 19.95M, CurrentPrice = 19.95M, Category = kidsBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/kids-bag-4.jpg", Description = "Share your love of minions with the world. Quality bag with a long lasting print." },
                        new Product { SKU = "KID205", DisplayName = "Cute Pink Bag", MSRP = 19.95M, CurrentPrice = 17.95M, Category = kidsBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/kids-bag-5.jpg", Description = "Share your love of minions with the world. Quality bag with a long lasting print." },
                        new Product { InStock = true, SKU = "KID206", DisplayName = "Cute Teddy Bag", MSRP = 19.95M, CurrentPrice = 17.95M, Category = kidsBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/kids-bag-6.jpg", Description = "Share your love of minions with the world. Quality bag with a long lasting print." },
                        new Product { InStock = true, SKU = "KID207", DisplayName = "Batman print Bag", MSRP = 19.95M, CurrentPrice = 17.95M, Category = kidsBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/kids-bag-7.jpg", Description = "Share your love of minions with the world. Quality bag with a long lasting print." },
                        new Product { InStock = true, SKU = "KID208", DisplayName = "Superman print Bag", MSRP = 19.95M, CurrentPrice = 17.95M, Category = kidsBag, Supplier = qualitySupplier, ImageUrl = "~/images/products/kids-bag-8.jpg", Description = "Share your love of minions with the world. Quality bag with a long lasting print." },
                        new Product { SKU = "KID209", DisplayName = "Hello Kitty bag", MSRP = 24.95M, CurrentPrice = 19.95M, Category = kidsBag, Supplier = shresthaSupplier, ImageUrl = "~/images/products/kids-bag-9.jpg", Description = "Share your love of Batman with the world. Quality bag with a long lasting print." }
                        );

                    context.SaveChanges();
                }

                if (!context.WebsiteAds.Any())
                {
                    //var womensBag = context.Categories.Single(c => c.DisplayName == "Women Bag");
                    //var mensBag = context.Categories.Single(c => c.DisplayName == "Men Bag");

                    context.WebsiteAds.Add(new WebsiteAd { ImageUrl = "~/images/banners/banner1.jpg", TagLine = "Welcome to Quality Bag Store", Details = "Best online store", Url = "http://dochyper.unitec.ac.nz/shresk03/asp_assignment" });
                    context.WebsiteAds.Add(new WebsiteAd { ImageUrl = "~/images/banners/banner2.jpg", TagLine = "Women Bags", Details = "shresk03", Url = "~/shop/" });
                    context.WebsiteAds.Add(new WebsiteAd { ImageUrl = "~/images/banners/banner3.jpg", TagLine = "Get the best bargain", Details = "Available in the Quality bag store", Url = "~/shop/" });
                    context.SaveChanges();
                }
            }
        }
    }
}
