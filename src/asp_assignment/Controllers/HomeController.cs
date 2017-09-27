using System;
using System.Linq;
using asp_assignment.Models.BagStore;
using asp_assignment.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace asp_assignment.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db;
        CategoryCache categoryCache;

        public HomeController(StoreContext context, CategoryCache cache)
        {
            db = context;
            categoryCache = cache;
        }

        public IActionResult Index()
        {
            var ads = db.WebsiteAds
                .Where(a => a.Start == null || a.Start <= DateTime.Now.ToUniversalTime())
                .Where(a => a.End == null || a.End >= DateTime.Now.ToUniversalTime());

            var products = db.Products
                .ToList()
                .OrderByDescending(p => p.MSRP - p.CurrentPrice)
                .Take(8);

            return View(new IndexViewModel
            {
                TopLevelCategories = categoryCache.TopLevel(),
                CurrentAds = ads.ToList(),
                FeaturedProducts = products
            });
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}