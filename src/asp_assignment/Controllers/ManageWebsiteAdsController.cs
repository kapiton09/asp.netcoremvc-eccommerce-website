using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asp_assignment.Models.BagStore;
using Microsoft.AspNetCore.Authorization;

namespace asp_assignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageWebsiteAdsController : Controller
    {
        private readonly StoreContext _context;

        public ManageWebsiteAdsController(StoreContext context)
        {
            _context = context;    
        }

        // GET: ManageWebsiteAds
        public async Task<IActionResult> Index()
        {
            return View(await _context.WebsiteAds.ToListAsync());
        }

        // GET: ManageWebsiteAds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var websiteAd = await _context.WebsiteAds.SingleOrDefaultAsync(m => m.WebsiteAdId == id);
            if (websiteAd == null)
            {
                return NotFound();
            }

            return View(websiteAd);
        }

        // GET: ManageWebsiteAds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageWebsiteAds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WebsiteAdId,Details,End,ImageUrl,Start,TagLine,Url")] WebsiteAd websiteAd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(websiteAd);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(websiteAd);
        }

        // GET: ManageWebsiteAds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var websiteAd = await _context.WebsiteAds.SingleOrDefaultAsync(m => m.WebsiteAdId == id);
            if (websiteAd == null)
            {
                return NotFound();
            }
            return View(websiteAd);
        }

        // POST: ManageWebsiteAds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WebsiteAdId,Details,End,ImageUrl,Start,TagLine,Url")] WebsiteAd websiteAd)
        {
            if (id != websiteAd.WebsiteAdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(websiteAd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebsiteAdExists(websiteAd.WebsiteAdId))
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
            return View(websiteAd);
        }

        // GET: ManageWebsiteAds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var websiteAd = await _context.WebsiteAds.SingleOrDefaultAsync(m => m.WebsiteAdId == id);
            if (websiteAd == null)
            {
                return NotFound();
            }

            return View(websiteAd);
        }

        // POST: ManageWebsiteAds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var websiteAd = await _context.WebsiteAds.SingleOrDefaultAsync(m => m.WebsiteAdId == id);
            _context.WebsiteAds.Remove(websiteAd);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WebsiteAdExists(int id)
        {
            return _context.WebsiteAds.Any(e => e.WebsiteAdId == id);
        }
    }
}
