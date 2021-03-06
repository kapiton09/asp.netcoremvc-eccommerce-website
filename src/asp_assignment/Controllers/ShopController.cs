﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using asp_assignment.Models.BagStore;
using asp_assignment.ViewModels.Shop;
using Microsoft.AspNetCore.Mvc;

namespace asp_assignment.Controllers
{
    public class ShopController : Controller
    {
        private StoreContext db;
        CategoryCache categoryCache;

        public ShopController(StoreContext context, CategoryCache cache)
        {
            db = context;
            categoryCache = cache;
        }

        public IActionResult Index()
        {
            var products = db.Products
                .ToList()
                .OrderByDescending(p => p.MSRP - p.CurrentPrice)
                .Take(12);

            return View(new IndexViewModel
            {
                FeaturedProducts = products,
                TopLevelCategories = categoryCache.TopLevel()
            });
        }

        public IActionResult Category(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }

            var category = categoryCache.FromKey(id.Value);

            if (category == null)
            {
                return new StatusCodeResult(404);
            }

            var ids = categoryCache.GetThisAndChildIds(id.Value);
            return View(new CategoryViewModel
            {
                Category = category,
                Products = db.Products.Where(p => ids.Contains(p.CategoryId)),
                ParentHierarchy = categoryCache.GetHierarchy(category.CategoryId),
                Children = category.Children
            });
        }

        public IActionResult Product(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }

            var product = db.Products
                .Include(p => p.Category)
                .SingleOrDefault(m => m.ProductId == id);

            if (product == null)
            {
                return new StatusCodeResult(404);
            }

            return View(new ProductViewModel
            {
                Product = product,
                CategoryHierarchy = categoryCache.GetHierarchy(product.CategoryId),
                TopLevelCategories = categoryCache.TopLevel()
            });
        }

        public IActionResult Search(string term)
        {
            var products = db.Products
                .FromSql("SELECT * FROM [dbo].[SearchProducts] (@p0)", term)
                .OrderByDescending(p => p.Savings)
                .ToList();

            return View(new SearchViewModel
            {
                SearchTerm = term,
                Products = products,
                TopLevelCategories = categoryCache.TopLevel()
            });
        }
    }
}
