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
    public class EmpleosController : Controller
    {
        private readonly DreamDbaseContext _context;

        public EmpleosController(DreamDbaseContext context)
        {
            _context = context;
        }

        // GET: Empleos
        public async Task<IActionResult> Index()
        {
              return _context.Empleos != null ? 
                          View(await _context.Empleos.ToListAsync()) :
                          Problem("Entity set 'DreamDbaseContext.Empleos'  is null.");
        }
        //GET: Empleos/Buscar
        public IActionResult Buscar(string query)
        {
            // Aquí puedes realizar la lógica de búsqueda y obtener los resultados
            List<Empleo> resultados = ObtenerResultadosDeBusqueda(query);

            return View(resultados);
        }

        private List<Empleo> ObtenerResultadosDeBusqueda(string query)
        {
            // Aquí puedes implementar la lógica para obtener los resultados de búsqueda de acuerdo a la consulta
            // Puedes realizar consultas en una base de datos, llamar a una API, etc.

            // Ejemplo de resultados de búsqueda ficticios
            List<Empleo> resultados = new List<Empleo>
            {
                new Empleo
                {
                    TituloEmpleo = "Desarrollador Web",
                    DescripcionEmpleo = "Buscamos un desarrollador web con experiencia en HTML, CSS y JavaScript.",
                    UbicacionEmpleo = "Ciudad X"
                },
            };

            return resultados;
        }

        // GET: Empleos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleos == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleos
                .FirstOrDefaultAsync(m => m.IdEmpleo == id);
            if (empleo == null)
            {
                return NotFound();
            }

            return View(empleo);
        }

        // GET: Empleos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleo,TituloEmpleo,DescripcionEmpleo,UbicacionEmpleo,SalarioEmpleo,FechaPublicacion")] Empleo empleo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleo);
        }



        // GET: Empleos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleos == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleos.FindAsync(id);
            if (empleo == null)
            {
                return NotFound();
            }
            return View(empleo);
        }

        // POST: Empleos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleo,TituloEmpleo,DescripcionEmpleo,UbicacionEmpleo,SalarioEmpleo,FechaPublicacion")] Empleo empleo)
        {
            if (id != empleo.IdEmpleo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleoExists(empleo.IdEmpleo))
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
            return View(empleo);
        }

        // GET: Empleos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleos == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleos
                .FirstOrDefaultAsync(m => m.IdEmpleo == id);
            if (empleo == null)
            {
                return NotFound();
            }

            return View(empleo);
        }

        // POST: Empleos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleos == null)
            {
                return Problem("Entity set 'DreamDbaseContext.Empleos'  is null.");
            }
            var empleo = await _context.Empleos.FindAsync(id);
            if (empleo != null)
            {
                _context.Empleos.Remove(empleo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleoExists(int id)
        {
          return (_context.Empleos?.Any(e => e.IdEmpleo == id)).GetValueOrDefault();
        }
    }
}
