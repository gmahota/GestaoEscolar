using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoEscolar.Data;
using GestaoEscolar.Models;

namespace GestaoEscolar.Controllers
{
    public class TurmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Turmas.Include(t => t.Classe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas
                .Include(t => t.Classe)
                .FirstOrDefaultAsync(m => m.id == id);
            if (turmas == null)
            {
                return NotFound();
            }

            return View(turmas);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            ViewData["classeId"] = new SelectList(_context.Classe, "id", "id");
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,desc,classeId")] Turmas turmas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turmas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["classeId"] = new SelectList(_context.Classe, "id", "id", turmas.classeId);
            return View(turmas);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas.FindAsync(id);
            if (turmas == null)
            {
                return NotFound();
            }
            ViewData["classeId"] = new SelectList(_context.Classe, "id", "id", turmas.classeId);
            return View(turmas);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,desc,classeId")] Turmas turmas)
        {
            if (id != turmas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmasExists(turmas.id))
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
            ViewData["classeId"] = new SelectList(_context.Classe, "id", "id", turmas.classeId);
            return View(turmas);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas
                .Include(t => t.Classe)
                .FirstOrDefaultAsync(m => m.id == id);
            if (turmas == null)
            {
                return NotFound();
            }

            return View(turmas);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turmas = await _context.Turmas.FindAsync(id);
            _context.Turmas.Remove(turmas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmasExists(int id)
        {
            return _context.Turmas.Any(e => e.id == id);
        }
    }
}
