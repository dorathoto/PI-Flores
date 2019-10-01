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
    public class AlmoxarifadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlmoxarifadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Almoxarifados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Almoxarifado.ToListAsync());
        }

        // GET: Almoxarifados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almoxarifado = await _context.Almoxarifado
                .FirstOrDefaultAsync(m => m.AlmoxarifadoId == id);
            if (almoxarifado == null)
            {
                return NotFound();
            }

            return View(almoxarifado);
        }

        // GET: Almoxarifados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Almoxarifados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlmoxarifadoId,ValorUnitario,ValorFinal,Quantidade,TipoMovimentacao,Descricao,DataCadastro")] Almoxarifado almoxarifado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(almoxarifado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(almoxarifado);
        }

        // GET: Almoxarifados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almoxarifado = await _context.Almoxarifado.FindAsync(id);
            if (almoxarifado == null)
            {
                return NotFound();
            }
            return View(almoxarifado);
        }

        // POST: Almoxarifados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlmoxarifadoId,ValorUnitario,ValorFinal,Quantidade,TipoMovimentacao,Descricao,DataCadastro")] Almoxarifado almoxarifado)
        {
            if (id != almoxarifado.AlmoxarifadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(almoxarifado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlmoxarifadoExists(almoxarifado.AlmoxarifadoId))
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
            return View(almoxarifado);
        }

        // GET: Almoxarifados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almoxarifado = await _context.Almoxarifado
                .FirstOrDefaultAsync(m => m.AlmoxarifadoId == id);
            if (almoxarifado == null)
            {
                return NotFound();
            }

            return View(almoxarifado);
        }

        // POST: Almoxarifados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var almoxarifado = await _context.Almoxarifado.FindAsync(id);
            _context.Almoxarifado.Remove(almoxarifado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlmoxarifadoExists(int id)
        {
            return _context.Almoxarifado.Any(e => e.AlmoxarifadoId == id);
        }
    }
}
