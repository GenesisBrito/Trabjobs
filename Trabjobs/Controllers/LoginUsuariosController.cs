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
    public class LoginUsuariosController : Controller
    {
        private readonly DreamDbaseContext _context;

        public LoginUsuariosController(DreamDbaseContext context)
        {
            _context = context;
        }

        // GET: LoginUsuarios
        public async Task<IActionResult> Index()
        {
            var dreamDbaseContext = _context.LoginUsuarios.Include(l => l.Usuario);
            return View(await dreamDbaseContext.ToListAsync());
        }

        // GET: LoginUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoginUsuarios == null)
            {
                return NotFound();
            }

            var loginUsuario = await _context.LoginUsuarios
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginUsuario == null)
            {
                return NotFound();
            }

            return View(loginUsuario);
        }

        // GET: LoginUsuarios/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: LoginUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CorreoUsuarios,ContraseñaUsuarios,UsuarioId")] LoginUsuario loginUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", loginUsuario.UsuarioId);
            return View(loginUsuario);
        }

        // GET: LoginUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoginUsuarios == null)
            {
                return NotFound();
            }

            var loginUsuario = await _context.LoginUsuarios.FindAsync(id);
            if (loginUsuario == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", loginUsuario.UsuarioId);
            return View(loginUsuario);
        }

        // POST: LoginUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CorreoUsuarios,ContraseñaUsuarios,UsuarioId")] LoginUsuario loginUsuario)
        {
            if (id != loginUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginUsuarioExists(loginUsuario.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", loginUsuario.UsuarioId);
            return View(loginUsuario);
        }

        // GET: LoginUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoginUsuarios == null)
            {
                return NotFound();
            }

            var loginUsuario = await _context.LoginUsuarios
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginUsuario == null)
            {
                return NotFound();
            }

            return View(loginUsuario);
        }

        // POST: LoginUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoginUsuarios == null)
            {
                return Problem("Entity set 'DreamDbaseContext.LoginUsuarios'  is null.");
            }
            var loginUsuario = await _context.LoginUsuarios.FindAsync(id);
            if (loginUsuario != null)
            {
                _context.LoginUsuarios.Remove(loginUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginUsuarioExists(int id)
        {
          return (_context.LoginUsuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
