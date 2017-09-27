using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asp_application1.Data;
using asp_application1.Models;

namespace asp_application1.Controllers
{
    public class BagsController : Controller
    {
        private readonly DataContext _context;

        public BagsController(DataContext context)
        {
            _context = context;    
        }

        // GET: Bags
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bags
                .Include(b => b.Category)
                .Include(e => e.Supplier)
                .ToListAsync());
        }

        // GET: Bags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bags
                .Include(b=>b.Category)
                .Include(e=>e.Supplier)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // GET: Bags/Create
        public IActionResult Create()
        {
            PopulateCategoriesDropDownList();
            PopulateSuppliersDropDownList();
            return View();
        }

        // POST: Bags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,Description,CategoryID,SupplierID")] Bag bag)
        {
           
                if (ModelState.IsValid)
                {
                    _context.Add(bag);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                PopulateCategoriesDropDownList(bag.CategoryID);
                PopulateSuppliersDropDownList(bag.SupplierID);
           
             return View(bag);
        }

        //Drop down for Category
        private void PopulateCategoriesDropDownList(object selectedCategory = null)
        {
            var categoriesQuery = from c in _context.Categories
                                  orderby c.Name
                                  select c;
            ViewBag.CategoryID = new SelectList(categoriesQuery.AsNoTracking(), "ID", "Name",
            selectedCategory);
        }

        //Drop down for Supplier
        private void PopulateSuppliersDropDownList(object selectedSupplier = null)
        {
            var suppliersQuery = from s in _context.Suppliers
                                  orderby s.Name
                                  select s;
            ViewBag.SupplierID = new SelectList(suppliersQuery.AsNoTracking(), "ID", "Name",
            selectedSupplier);
        }

        // GET: Bags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bags
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bag == null)
            {
                return NotFound();
            }
            PopulateCategoriesDropDownList(bag.CategoryID);
            PopulateSuppliersDropDownList(bag.SupplierID);
            return View(bag);
        }

        // POST: Bags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bagToUpdate = await _context.Bags
            .SingleOrDefaultAsync(b => b.ID == id);
            if (await TryUpdateModelAsync<Bag>(bagToUpdate, "", b => b.Name, b => b.Price, b => b.Description,  b=>b.CategoryID, b=>b.SupplierID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists, " + "see your system administrator.");
                }
                return RedirectToAction("Index");
            }
            PopulateCategoriesDropDownList(bagToUpdate.CategoryID);
            PopulateSuppliersDropDownList(bagToUpdate.SupplierID);
            return View(bagToUpdate);
        }

        // GET: Bags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bags
                .Include(b => b.Category)
                .Include(e => e.Supplier)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // POST: Bags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bag = await _context.Bags.SingleOrDefaultAsync(m => m.ID == id);
            _context.Bags.Remove(bag);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BagExists(int id)
        {
            return _context.Bags.Any(e => e.ID == id);
        }
    }
}
