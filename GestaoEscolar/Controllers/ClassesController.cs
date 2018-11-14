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
    public class ClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Classe.Include(c => c.Nivel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classe = await _context.Classe
                .Include(c => c.Nivel)
                .Include(c=> c.Disciplinas)
                .FirstOrDefaultAsync(m => m.id == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        public async Task<IActionResult> ListaDisciplinas(int? id)
        {
            var applicationDbContext =  _context.Disciplina
                .Include(d => d.classe)
                .Where(p=> p.classe_id == id);

            return PartialView("_ListaDisciplinas.cshtml", await applicationDbContext.ToListAsync());
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            ViewData["nivelCode"] = new SelectList(_context.Nivel, "codigo", "desc");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,desc,nivelCode")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["nivelCode"] = new SelectList(_context.Nivel, "codigo", "desc", classe.nivelCode);
            return View(classe);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classe = await _context.Classe.FindAsync(id);
            if (classe == null)
            {
                return NotFound();
            }
            ViewData["nivelCode"] = new SelectList(_context.Nivel, "codigo", "desc", classe.nivelCode);
            return View(classe);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("id,desc,nivelCode")] Classe classe)
        {
            if (id != classe.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseExists(classe.id))
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
            ViewData["nivelCode"] = new SelectList(_context.Nivel, "codigo", "desc", classe.nivelCode);
            return View(classe);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classe = await _context.Classe
                .Include(c => c.Nivel)
                .FirstOrDefaultAsync(m => m.id == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var classe = await _context.Classe.FindAsync(id);
            _context.Classe.Remove(classe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseExists(decimal id)
        {
            return _context.Classe.Any(e => e.id == id);
        }
    }
}
