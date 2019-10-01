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
    public class TipoFloresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoFloresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoFlores
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoFlor.ToListAsync());
        }

        // GET: TipoFlores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoFlor = await _context.TipoFlor
                .FirstOrDefaultAsync(m => m.TipoFlorId == id);
            if (tipoFlor == null)
            {
                return NotFound();
            }

            return View(tipoFlor);
        }

        // GET: TipoFlores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoFlores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoFlorId,Nome,IrrigacaoSemana,IrrigacaoTempo,IrrigacaoQtdPessoas,Estufa,DataCadastro")] TipoFlor tipoFlor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoFlor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFlor);
        }

        // GET: TipoFlores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoFlor = await _context.TipoFlor.FindAsync(id);
            if (tipoFlor == null)
            {
                return NotFound();
            }
            return View(tipoFlor);
        }

        // POST: TipoFlores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoFlorId,Nome,IrrigacaoSemana,IrrigacaoTempo,IrrigacaoQtdPessoas,Estufa,DataCadastro")] TipoFlor tipoFlor)
        {
            if (id != tipoFlor.TipoFlorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoFlor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoFlorExists(tipoFlor.TipoFlorId))
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
            return View(tipoFlor);
        }

        // GET: TipoFlores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoFlor = await _context.TipoFlor
                .FirstOrDefaultAsync(m => m.TipoFlorId == id);
            if (tipoFlor == null)
            {
                return NotFound();
            }

            return View(tipoFlor);
        }

        // POST: TipoFlores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoFlor = await _context.TipoFlor.FindAsync(id);
            _context.TipoFlor.Remove(tipoFlor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoFlorExists(int id)
        {
            return _context.TipoFlor.Any(e => e.TipoFlorId == id);
        }
    }
}
