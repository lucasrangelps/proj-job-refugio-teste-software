﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Job_refugio_bd.Models;

namespace Job_refugio_bd.Controllers
{
    public class VagasController : Controller
    {
        private readonly AppDbContext _context;

        public VagasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Vagas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Vagas.Include(v => v.Empregador);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Vagas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas
                .Include(v => v.Empregador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // GET: Vagas/Create
        public IActionResult Create()
        {
            ViewData["EmpregadorId"] = new SelectList(_context.Empregadores, "Id", "Cnpj");
            return View();
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpregadorId,NomeCargo,Local,MetodoContratacao,VagaPCD,RegimeTrabalho,SobreEmpresa,DescVaga,RequisitosQualificacao,InfoAdicional")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpregadorId"] = new SelectList(_context.Empregadores, "Id", "Cnpj", vaga.EmpregadorId);
            return View(vaga);
        }

        // GET: Vagas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas.FindAsync(id);
            if (vaga == null)
            {
                return NotFound();
            }
            ViewData["EmpregadorId"] = new SelectList(_context.Empregadores, "Id", "Cnpj", vaga.EmpregadorId);
            return View(vaga);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpregadorId,NomeCargo,Local,MetodoContratacao,VagaPCD,RegimeTrabalho,SobreEmpresa,DescVaga,RequisitosQualificacao,InfoAdicional")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaExists(vaga.Id))
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
            ViewData["EmpregadorId"] = new SelectList(_context.Empregadores, "Id", "Cnpj", vaga.EmpregadorId);
            return View(vaga);
        }

        // GET: Vagas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas
                .Include(v => v.Empregador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);
            if (vaga != null)
            {
                _context.Vagas.Remove(vaga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaExists(int id)
        {
            return _context.Vagas.Any(e => e.Id == id);
        }
    }
}
