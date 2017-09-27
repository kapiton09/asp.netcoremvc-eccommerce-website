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

            return View(new IndexViewModel
            {
                TopLevelCategories = categoryCache.TopLevel(),
                CurrentAds = ads.ToList()
            });
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}