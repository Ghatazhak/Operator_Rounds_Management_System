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
    public class RoundsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoundsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rounds
        public async Task<IActionResult> Index()
        {
              return _context.Rounds != null ? 
                          View(await _context.Rounds.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Rounds'  is null.");
        }

        // GET: Rounds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rounds == null)
            {
                return NotFound();
            }

            var round = await _context.Rounds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (round == null)
            {
                return NotFound();
            }

            return View(round);
        }

        // GET: Rounds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rounds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateTime,Notes")] Round round)
        {
            if (ModelState.IsValid)
            {
                _context.Add(round);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(round);
        }

        // GET: Rounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rounds == null)
            {
                return NotFound();
            }

            var round = await _context.Rounds.FindAsync(id);
            if (round == null)
            {
                return NotFound();
            }
            return View(round);
        }

        // POST: Rounds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateTime,Notes")] Round round)
        {
            if (id != round.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(round);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoundExists(round.Id))
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
            return View(round);
        }

        // GET: Rounds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rounds == null)
            {
                return NotFound();
            }

            var round = await _context.Rounds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (round == null)
            {
                return NotFound();
            }

            return View(round);
        }

        // POST: Rounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rounds == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rounds'  is null.");
            }
            var round = await _context.Rounds.FindAsync(id);
            if (round != null)
            {
                _context.Rounds.Remove(round);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoundExists(int id)
        {
          return (_context.Rounds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
