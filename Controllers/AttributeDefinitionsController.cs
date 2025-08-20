﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Catalog.Web.Models;

namespace ProductCatalog.Controllers
{
    public class AttributeDefinitionsController : Controller
    {
        private readonly CatalogContext _context;

        public AttributeDefinitionsController(CatalogContext context)
        {
            _context = context;
        }

        // GET: AttributeDefinitions
        public async Task<IActionResult> Index()
        {
            return View(await _context.AttributeDefinitions.ToListAsync());
        }

        // GET: AttributeDefinitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeDefinition = await _context.AttributeDefinitions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attributeDefinition == null)
            {
                return NotFound();
            }

            return View(attributeDefinition);
        }

        // GET: AttributeDefinitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttributeDefinitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DataType,SortOrder")] AttributeDefinition attributeDefinition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attributeDefinition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attributeDefinition);
        }

        // GET: AttributeDefinitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeDefinition = await _context.AttributeDefinitions.FindAsync(id);
            if (attributeDefinition == null)
            {
                return NotFound();
            }
            return View(attributeDefinition);
        }

        // POST: AttributeDefinitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DataType,SortOrder")] AttributeDefinition attributeDefinition)
        {
            if (id != attributeDefinition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attributeDefinition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeDefinitionExists(attributeDefinition.Id))
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
            return View(attributeDefinition);
        }

        // GET: AttributeDefinitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeDefinition = await _context.AttributeDefinitions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attributeDefinition == null)
            {
                return NotFound();
            }

            return View(attributeDefinition);
        }

        // POST: AttributeDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attributeDefinition = await _context.AttributeDefinitions.FindAsync(id);
            if (attributeDefinition != null)
            {
                _context.AttributeDefinitions.Remove(attributeDefinition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeDefinitionExists(int id)
        {
            return _context.AttributeDefinitions.Any(e => e.Id == id);
        }
    }
}
