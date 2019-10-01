using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Data;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.Controllers
{
    public class FloresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FloresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Flores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Flor.Include(f => f.TipoFlor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Flores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flor = await _context.Flor
                .Include(f => f.TipoFlor)
                .FirstOrDefaultAsync(m => m.FlorId == id);
            if (flor == null)
            {
                return NotFound();
            }

            return View(flor);
        }

        // GET: Flores/Create
        public IActionResult Create()
        {
            ViewData["TipoFlorId"] = new SelectList(_context.Set<TipoFlor>(), "TipoFlorId", "TipoFlorId");
            return View();
        }

        // POST: Flores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlorId,TipoFlorId,DataPlantacao,Descricao,DataColheitaEstimada,AreaHorizontalPlantada,AreaVerticalPlantada,DataCadastro")] Flor flor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoFlorId"] = new SelectList(_context.Set<TipoFlor>(), "TipoFlorId", "TipoFlorId", flor.TipoFlorId);
            return View(flor);
        }

        // GET: Flores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flor = await _context.Flor.FindAsync(id);
            if (flor == null)
            {
                return NotFound();
            }
            ViewData["TipoFlorId"] = new SelectList(_context.Set<TipoFlor>(), "TipoFlorId", "TipoFlorId", flor.TipoFlorId);
            return View(flor);
        }

        // POST: Flores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlorId,TipoFlorId,DataPlantacao,Descricao,DataColheitaEstimada,AreaHorizontalPlantada,AreaVerticalPlantada,DataCadastro")] Flor flor)
        {
            if (id != flor.FlorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlorExists(flor.FlorId))
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
            ViewData["TipoFlorId"] = new SelectList(_context.Set<TipoFlor>(), "TipoFlorId", "TipoFlorId", flor.TipoFlorId);
            return View(flor);
        }

        // GET: Flores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flor = await _context.Flor
                .Include(f => f.TipoFlor)
                .FirstOrDefaultAsync(m => m.FlorId == id);
            if (flor == null)
            {
                return NotFound();
            }

            return View(flor);
        }

        // POST: Flores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flor = await _context.Flor.FindAsync(id);
            _context.Flor.Remove(flor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlorExists(int id)
        {
            return _context.Flor.Any(e => e.FlorId == id);
        }
    }
}
