using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Catalog.Web.Models;

namespace ProductCatalog.Controllers
{
    public class DressesController : Controller
    {
        private readonly CatalogContext _context;

        public DressesController(CatalogContext context)
        {
            _context = context;
        }

        // GET: Dresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dresses.ToListAsync());
        }

        // GET: Dresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dress = await _context.Dresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dress == null)
            {
                return NotFound();
            }

            return View(dress);
        }

        // GET: Dresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Size,Price,Color")] Dress dress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dress);
        }

        // GET: Dresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dress = await _context.Dresses.FindAsync(id);
            if (dress == null)
            {
                return NotFound();
            }
            return View(dress);
        }

        // POST: Dresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Size,Price,Color")] Dress dress)
        {
            if (id != dress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DressExists(dress.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dress);
        }

        // GET: Dresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dress = await _context.Dresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dress == null)
            {
                return NotFound();
            }

            return View(dress);
        }

        // POST: Dresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dress = await _context.Dresses.FindAsync(id);
            if (dress != null)
            {
                _context.Dresses.Remove(dress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DressExists(int id)
        {
            return _context.Dresses.Any(e => e.Id == id);
        }
    }
}
