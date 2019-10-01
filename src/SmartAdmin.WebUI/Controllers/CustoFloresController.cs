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
    public class CustoFloresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustoFloresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustoFlores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CustoFlor.Include(c => c.Flores);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CustoFlores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custoFlor = await _context.CustoFlor
                .Include(c => c.Flores)
                .FirstOrDefaultAsync(m => m.CustoFlorId == id);
            if (custoFlor == null)
            {
                return NotFound();
            }

            return View(custoFlor);
        }

        // GET: CustoFlores/Create
        public IActionResult Create()
        {
            ViewData["FlorId"] = new SelectList(_context.Set<Flor>(), "FlorId", "Descricao");
            return View();
        }

        // POST: CustoFlores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustoFlorId,FlorId,Quantidade,ValorCalculado,DataCadastro")] CustoFlor custoFlor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custoFlor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlorId"] = new SelectList(_context.Set<Flor>(), "FlorId", "Descricao", custoFlor.FlorId);
            return View(custoFlor);
        }

        // GET: CustoFlores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custoFlor = await _context.CustoFlor.FindAsync(id);
            if (custoFlor == null)
            {
                return NotFound();
            }
            ViewData["FlorId"] = new SelectList(_context.Set<Flor>(), "FlorId", "Descricao", custoFlor.FlorId);
            return View(custoFlor);
        }

        // POST: CustoFlores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustoFlorId,FlorId,Quantidade,ValorCalculado,DataCadastro")] CustoFlor custoFlor)
        {
            if (id != custoFlor.CustoFlorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custoFlor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustoFlorExists(custoFlor.CustoFlorId))
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
            ViewData["FlorId"] = new SelectList(_context.Set<Flor>(), "FlorId", "Descricao", custoFlor.FlorId);
            return View(custoFlor);
        }

        // GET: CustoFlores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custoFlor = await _context.CustoFlor
                .Include(c => c.Flores)
                .FirstOrDefaultAsync(m => m.CustoFlorId == id);
            if (custoFlor == null)
            {
                return NotFound();
            }

            return View(custoFlor);
        }

        // POST: CustoFlores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var custoFlor = await _context.CustoFlor.FindAsync(id);
            _context.CustoFlor.Remove(custoFlor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustoFlorExists(int id)
        {
            return _context.CustoFlor.Any(e => e.CustoFlorId == id);
        }
    }
}
