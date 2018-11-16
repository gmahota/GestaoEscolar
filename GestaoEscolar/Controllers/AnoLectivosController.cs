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
    public class AnoLectivosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnoLectivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnoLectivos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AnoLectivo.Include(a => a.Ano);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AnoLectivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anoLectivo = await _context.AnoLectivo
                .Include(a => a.Ano)
                .FirstOrDefaultAsync(m => m.id == id);
            if (anoLectivo == null)
            {
                return NotFound();
            }

            return View(anoLectivo);
        }

        // GET: AnoLectivos/Create
        public IActionResult Create()
        {
            ViewData["anoId"] = new SelectList(_context.Anos, "id", "desc");
            return View();
        }

        // POST: AnoLectivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,codigo,desc,anoId,dataInicio,dataFim")] AnoLectivo anoLectivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anoLectivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["anoId"] = new SelectList(_context.Anos, "id", "desc", anoLectivo.anoId);
            return View(anoLectivo);
        }

        // GET: AnoLectivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anoLectivo = await _context.AnoLectivo.FindAsync(id);
            if (anoLectivo == null)
            {
                return NotFound();
            }
            ViewData["anoId"] = new SelectList(_context.Anos, "id", "desc", anoLectivo.anoId);
            return View(anoLectivo);
        }

        // POST: AnoLectivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,codigo,desc,anoId,dataInicio,dataFim")] AnoLectivo anoLectivo)
        {
            if (id != anoLectivo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anoLectivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnoLectivoExists(anoLectivo.id))
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
            ViewData["anoId"] = new SelectList(_context.Anos, "id", "desc", anoLectivo.anoId);
            return View(anoLectivo);
        }

        // GET: AnoLectivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anoLectivo = await _context.AnoLectivo
                .Include(a => a.Ano)
                .FirstOrDefaultAsync(m => m.id == id);
            if (anoLectivo == null)
            {
                return NotFound();
            }

            return View(anoLectivo);
        }

        // POST: AnoLectivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anoLectivo = await _context.AnoLectivo.FindAsync(id);
            _context.AnoLectivo.Remove(anoLectivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnoLectivoExists(int id)
        {
            return _context.AnoLectivo.Any(e => e.id == id);
        }
    }
}
