using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabjobs.Models;

namespace Trabjobs.Controllers
{
    public class LoginEmpresasController : Controller
    {
        private readonly DreamDbaseContext _context;

        public LoginEmpresasController(DreamDbaseContext context)
        {
            _context = context;
        }

        // GET: LoginEmpresas
        public async Task<IActionResult> Index()
        {
            var dreamDbaseContext = _context.LoginEmpresas.Include(l => l.Empresa);
            return View(await dreamDbaseContext.ToListAsync());
        }

        // GET: LoginEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoginEmpresas == null)
            {
                return NotFound();
            }

            var loginEmpresa = await _context.LoginEmpresas
                .Include(l => l.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginEmpresa == null)
            {
                return NotFound();
            }

            return View(loginEmpresa);
        }

        // GET: LoginEmpresas/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa");
            return View();
        }

        // POST: LoginEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CorreoEmpresa,ContraseñaEmpresa,EmpresaId")] LoginEmpresa loginEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa", loginEmpresa.EmpresaId);
            return View(loginEmpresa);
        }

        // GET: LoginEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoginEmpresas == null)
            {
                return NotFound();
            }

            var loginEmpresa = await _context.LoginEmpresas.FindAsync(id);
            if (loginEmpresa == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa", loginEmpresa.EmpresaId);
            return View(loginEmpresa);
        }

        // POST: LoginEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CorreoEmpresa,ContraseñaEmpresa,EmpresaId")] LoginEmpresa loginEmpresa)
        {
            if (id != loginEmpresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginEmpresaExists(loginEmpresa.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa", loginEmpresa.EmpresaId);
            return View(loginEmpresa);
        }

        // GET: LoginEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoginEmpresas == null)
            {
                return NotFound();
            }

            var loginEmpresa = await _context.LoginEmpresas
                .Include(l => l.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginEmpresa == null)
            {
                return NotFound();
            }

            return View(loginEmpresa);
        }

        // POST: LoginEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoginEmpresas == null)
            {
                return Problem("Entity set 'DreamDbaseContext.LoginEmpresas'  is null.");
            }
            var loginEmpresa = await _context.LoginEmpresas.FindAsync(id);
            if (loginEmpresa != null)
            {
                _context.LoginEmpresas.Remove(loginEmpresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginEmpresaExists(int id)
        {
          return (_context.LoginEmpresas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
