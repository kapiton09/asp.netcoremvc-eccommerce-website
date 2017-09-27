using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asp_assignment.Models.BagStore;
using asp_assignment.ViewModels.ManageProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using System;

namespace asp_assignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageProductController : Controller
    {
        private readonly StoreContext _context;
        private readonly IHostingEnvironment _hostingEnv;
        CategoryCache categoryCache;

        public ManageProductController(StoreContext context, CategoryCache cache, IHostingEnvironment hEnv)
        {
            _context = context;
            categoryCache = cache;
            _hostingEnv = hEnv;
        }

        // GET: ManageProduct
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.Products.Include(p => p.Category).Include(p => p.Supplier);
            return View(await storeContext.ToListAsync());
        }

        // GET: ManageProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: ManageProduct/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "DisplayName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Name");
            return View();
        }

        // POST: ManageProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CategoryId,CurrentPrice,Description,DisplayName,ImageUrl,MSRP,SKU,SupplierId")] Product product, IList<IFormFile> _files)
        {
            var relativeName = "";
            var fileName = "";

            if (_files.Count < 1)
            {
                relativeName = "/images/products/default.jpg";
            }
            else
            {
                foreach (var file in _files)
                {
                    fileName = ContentDispositionHeaderValue
                        .Parse(file.ContentDisposition)
                        .FileName
                        .Trim('"');
                    //Path for localhost
                    relativeName ="/images/products/" +
                        DateTime.Now.ToString("ddMMyyyy-HHmmssffffff")
                        + fileName;
                    using (FileStream fs =
                        System.IO.File.Create(_hostingEnv.WebRootPath + relativeName))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
            }
            product.ImageUrl = "~"+relativeName;
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
                ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Email", product.SupplierId);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists " + "see your system adminisrator!");
            }
            return View(product);
        }

        // GET: ManageProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "DisplayName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Name", product.SupplierId);
            return View(product);
        }

        // POST: ManageProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,CategoryId,CurrentPrice,Description,DisplayName,ImageUrl,MSRP,SKU,SupplierId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Email", product.SupplierId);
            return View(product);
        }

        // GET: ManageProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ManageProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    
        public IActionResult BulkPriceReduction()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "DisplayName");
            ViewBag.SupplierId = new SelectList(_context.Suppliers, "SupplierId", "Name");

            return View(new BulkPriceReductionViewModel { PercentageOffMSRP = 10 });
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BulkPriceReduction(BulkPriceReductionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ids = categoryCache.GetThisAndChildIds(model.CategoryId);
                var products = _context.Products.Where(p => ids.Contains(p.CategoryId));

                foreach (var product in products)
                {
                    var discount = product.MSRP * model.PercentageOffMSRP / 100;
                    product.CurrentPrice = product.MSRP - discount;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", new { categoryId = model.CategoryId });
            }

            return View(model);
        }
    }
}
