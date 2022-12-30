using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Operator_Rounds_Management_System.Data;
using Operator_Rounds_Management_System.Models;

namespace Operator_Rounds_Management_System.Controllers
{
    public class CheckCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckCategories
        public async Task<IActionResult> Index()
        {
              return _context.CheckCategory != null ? 
                          View(await _context.CheckCategory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CheckCategory'  is null.");
        }

        // GET: CheckCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CheckCategory == null)
            {
                return NotFound();
            }

            var checkCategory = await _context.CheckCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkCategory == null)
            {
                return NotFound();
            }

            return View(checkCategory);
        }

        // GET: CheckCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CheckCategory checkCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkCategory);
        }

        // GET: CheckCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CheckCategory == null)
            {
                return NotFound();
            }

            var checkCategory = await _context.CheckCategory.FindAsync(id);
            if (checkCategory == null)
            {
                return NotFound();
            }
            return View(checkCategory);
        }

        // POST: CheckCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CheckCategory checkCategory)
        {
            if (id != checkCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckCategoryExists(checkCategory.Id))
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
            return View(checkCategory);
        }

        // GET: CheckCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CheckCategory == null)
            {
                return NotFound();
            }

            var checkCategory = await _context.CheckCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkCategory == null)
            {
                return NotFound();
            }

            return View(checkCategory);
        }

        // POST: CheckCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CheckCategory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CheckCategory'  is null.");
            }
            var checkCategory = await _context.CheckCategory.FindAsync(id);
            if (checkCategory != null)
            {
                _context.CheckCategory.Remove(checkCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckCategoryExists(int id)
        {
          return (_context.CheckCategory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
