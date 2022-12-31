using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Operator_Rounds_Management_System.Data;
using Operator_Rounds_Management_System.Models;

namespace Operator_Rounds_Management_System.Controllers
{
    [Authorize]
    public class RoundsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoundsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator, Leader, Operator")]
        public async Task<IActionResult> Index()
        {

            if (_context.Rounds != null)
            {
                List<Round> allRounds = await _context.Rounds.ToListAsync();
                return View(allRounds);
            }

            return View();
        }

        // GET: Rounds/Details/5
        [Authorize(Roles = "Administrator, Leader, Operator")]
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
        [Authorize(Roles = "Administrator, Leader")]
        public IActionResult Create()
        {
            //var allSkills = _context.Skills.ToList();
            ViewData["AllSkills"] = new SelectList(Enum.GetValues(typeof(Enums.Skills)).Cast<Enums.Skills>().ToList());
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Skill")] Round round)
        {
            ModelState.Remove("DateTime");
            ModelState.Remove("Notes");
            ModelState.Remove("Operator");



            if (ModelState.IsValid)
            {
                _context.Add(round);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["AllSkills"] = new SelectList(Enum.GetValues(typeof(Enums.Skills)).Cast<Enums.Skills>().ToList());
            return View(round);
        }

        // GET: Rounds/Edit/5
        [Authorize(Roles = "Administrator, Leader")]
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
            ViewData["AllSkills"] = new SelectList(Enum.GetValues(typeof(Enums.Skills)).Cast<Enums.Skills>().ToList());
            return View(round);
        }

        // POST: Rounds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Skill")] Round round)
        {
            ModelState.Remove("DateTime");
            ModelState.Remove("Notes");
            ModelState.Remove("Operator");

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
        [Authorize(Roles = "Administrator, Leader")]
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
