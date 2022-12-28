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
    public class ChecksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChecksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Checks
        public async Task<IActionResult> Index()
        {
              return _context.Checks != null ? 
                          View(await _context.Checks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Checks'  is null.");
        }

        // GET: Checks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Checks == null)
            {
                return NotFound();
            }

            var check = await _context.Checks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (check == null)
            {
                return NotFound();
            }

            return View(check);
        }

        // GET: Checks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Checks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Completed,InService,Notes,WorkOrderNumber")] Check check)
        {
            if (ModelState.IsValid)
            {
                _context.Add(check);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(check);
        }

        // GET: Checks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Checks == null)
            {
                return NotFound();
            }

            var check = await _context.Checks.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }
            return View(check);
        }

        // POST: Checks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Completed,InService,Notes,WorkOrderNumber")] Check check)
        {
            if (id != check.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(check);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckExists(check.Id))
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
            return View(check);
        }

        // GET: Checks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Checks == null)
            {
                return NotFound();
            }

            var check = await _context.Checks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (check == null)
            {
                return NotFound();
            }

            return View(check);
        }

        // POST: Checks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Checks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Checks'  is null.");
            }
            var check = await _context.Checks.FindAsync(id);
            if (check != null)
            {
                _context.Checks.Remove(check);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckExists(int id)
        {
          return (_context.Checks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
