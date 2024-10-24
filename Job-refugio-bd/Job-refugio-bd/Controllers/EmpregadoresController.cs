using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Job_refugio_bd.Models;

namespace Job_refugio_bd.Controllers
{
    public class EmpregadoresController : Controller
    {
        private readonly AppDbContext _context;

        public EmpregadoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Empregadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empregadores.ToListAsync());
        }

        // GET: Empregadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregador = await _context.Empregadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empregador == null)
            {
                return NotFound();
            }

            return View(empregador);
        }

        // GET: Empregadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empregadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEmpresa,Cnpj,NomeFantasia,Descricao,Endereco,Cep,Telefone,Email,Senha")] Empregador empregador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empregador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empregador);
        }

        // GET: Empregadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregador = await _context.Empregadores.FindAsync(id);
            if (empregador == null)
            {
                return NotFound();
            }
            return View(empregador);
        }

        // POST: Empregadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeEmpresa,Cnpj,NomeFantasia,Descricao,Endereco,Cep,Telefone,Email,Senha")] Empregador empregador)
        {
            if (id != empregador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empregador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpregadorExists(empregador.Id))
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
            return View(empregador);
        }

        // GET: Empregadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregador = await _context.Empregadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empregador == null)
            {
                return NotFound();
            }

            return View(empregador);
        }

        // POST: Empregadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empregador = await _context.Empregadores.FindAsync(id);
            if (empregador != null)
            {
                _context.Empregadores.Remove(empregador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpregadorExists(int id)
        {
            return _context.Empregadores.Any(e => e.Id == id);
        }
    }
}
