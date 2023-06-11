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
    public class PostulacionesEmpleosController : Controller
    {
        private readonly DreamDbaseContext _context;

        public PostulacionesEmpleosController(DreamDbaseContext context)
        {
            _context = context;
        }

        // GET: PostulacionesEmpleos
        public async Task<IActionResult> Index()
        {
            var dreamDbaseContext = _context.PostulacionesEmpleos.Include(p => p.IdEmpleoNavigation).Include(p => p.IdUsuarioNavigation);
            return View(await dreamDbaseContext.ToListAsync());
        }

        // GET: PostulacionesEmpleos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostulacionesEmpleos == null)
            {
                return NotFound();
            }

            var postulacionesEmpleo = await _context.PostulacionesEmpleos
                .Include(p => p.IdEmpleoNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPostulacion == id);
            if (postulacionesEmpleo == null)
            {
                return NotFound();
            }

            return View(postulacionesEmpleo);
        }

        // GET: PostulacionesEmpleos/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleo"] = new SelectList(_context.Empleos, "IdEmpleo", "IdEmpleo");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: PostulacionesEmpleos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPostulacion,IdEmpleo,IdUsuario,FechaPostulacion")] PostulacionesEmpleo postulacionesEmpleo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postulacionesEmpleo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleo"] = new SelectList(_context.Empleos, "IdEmpleo", "IdEmpleo", postulacionesEmpleo.IdEmpleo);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", postulacionesEmpleo.IdUsuario);
            return View(postulacionesEmpleo);
        }

        // GET: PostulacionesEmpleos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostulacionesEmpleos == null)
            {
                return NotFound();
            }

            var postulacionesEmpleo = await _context.PostulacionesEmpleos.FindAsync(id);
            if (postulacionesEmpleo == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleo"] = new SelectList(_context.Empleos, "IdEmpleo", "IdEmpleo", postulacionesEmpleo.IdEmpleo);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", postulacionesEmpleo.IdUsuario);
            return View(postulacionesEmpleo);
        }

        // POST: PostulacionesEmpleos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPostulacion,IdEmpleo,IdUsuario,FechaPostulacion")] PostulacionesEmpleo postulacionesEmpleo)
        {
            if (id != postulacionesEmpleo.IdPostulacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postulacionesEmpleo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostulacionesEmpleoExists(postulacionesEmpleo.IdPostulacion))
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
            ViewData["IdEmpleo"] = new SelectList(_context.Empleos, "IdEmpleo", "IdEmpleo", postulacionesEmpleo.IdEmpleo);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", postulacionesEmpleo.IdUsuario);
            return View(postulacionesEmpleo);
        }

        // GET: PostulacionesEmpleos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostulacionesEmpleos == null)
            {
                return NotFound();
            }

            var postulacionesEmpleo = await _context.PostulacionesEmpleos
                .Include(p => p.IdEmpleoNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPostulacion == id);
            if (postulacionesEmpleo == null)
            {
                return NotFound();
            }

            return View(postulacionesEmpleo);
        }

        // POST: PostulacionesEmpleos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostulacionesEmpleos == null)
            {
                return Problem("Entity set 'DreamDbaseContext.PostulacionesEmpleos'  is null.");
            }
            var postulacionesEmpleo = await _context.PostulacionesEmpleos.FindAsync(id);
            if (postulacionesEmpleo != null)
            {
                _context.PostulacionesEmpleos.Remove(postulacionesEmpleo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostulacionesEmpleoExists(int id)
        {
          return (_context.PostulacionesEmpleos?.Any(e => e.IdPostulacion == id)).GetValueOrDefault();
        }
    }
}
