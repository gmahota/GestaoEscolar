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
    public class AnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Anos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anos.ToListAsync());
        }

        // GET: Anos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anos = await _context.Anos
                .FirstOrDefaultAsync(m => m.id == id);
            if (anos == null)
            {
                return NotFound();
            }

            return View(anos);
        }

        // GET: Anos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ano,desc,estado,inicio,fim")] Anos anos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anos);
        }

        // GET: Anos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anos = await _context.Anos.FindAsync(id);
            if (anos == null)
            {
                return NotFound();
            }
            return View(anos);
        }

        // POST: Anos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ano,desc,estado,inicio,fim")] Anos anos)
        {
            if (id != anos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnosExists(anos.id))
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
            return View(anos);
        }

        // GET: Anos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anos = await _context.Anos
                .FirstOrDefaultAsync(m => m.id == id);
            if (anos == null)
            {
                return NotFound();
            }

            return View(anos);
        }

        // POST: Anos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anos = await _context.Anos.FindAsync(id);
            _context.Anos.Remove(anos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnosExists(int id)
        {
            return _context.Anos.Any(e => e.id == id);
        }
    }
}
