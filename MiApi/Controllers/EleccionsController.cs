using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiApi.Context;
using MiApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EleccionsController : Controller
    {
        private readonly MyDbContext _context;

        public EleccionsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Eleccions
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            return _context.Eleccion != null ?
                          Json(await _context.Eleccion.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Eleccion'  is null.");
        }

        [HttpGet("vista-elecciones")]
        public IActionResult GetVistaElecciones()
        {
            var data = _context.VistaElecciones.ToList(); // VistaElecciones es el DbSet correspondiente a la vista
            return Ok(data); // Devuelve los datos como JSON
        }



        // GET: api/Eleccions/Details/5
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eleccion == null)
            {
                return NotFound();
            }

            var eleccion = await _context.Eleccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eleccion == null)
            {
                return NotFound();
            }

            return Json(eleccion);
        }

        //// GET: api/Eleccions/Create
        //[HttpGet("create")]
        //public IActionResult Create()
        //{
        //    return Json();
        //}

        // POST: api/Eleccions/Create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Departamento,Candidato,Votos")] Eleccion eleccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eleccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Json(eleccion);
        }

        // GET: api/Eleccions/Edit/5
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eleccion == null)
            {
                return NotFound();
            }

            var eleccion = await _context.Eleccion.FindAsync(id);
            if (eleccion == null)
            {
                return NotFound();
            }
            return Json(eleccion);
        }

        // POST: api/Eleccions/Edit/5
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Departamento,Candidato,Votos")] Eleccion eleccion)
        {
            if (id != eleccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eleccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EleccionExists(eleccion.Id))
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
            return Json(eleccion);
        }

        // GET: api/Eleccions/Delete/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eleccion == null)
            {
                return NotFound();
            }

            var eleccion = await _context.Eleccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eleccion == null)
            {
                return NotFound();
            }

            return Json(eleccion);
        }

        // POST: api/Eleccions/Delete/5
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eleccion == null)
            {
                return Problem("Entity set 'MyDbContext.Eleccion'  is null.");
            }
            var eleccion = await _context.Eleccion.FindAsync(id);
            if (eleccion != null)
            {
                _context.Eleccion.Remove(eleccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EleccionExists(int id)
        {
            return (_context.Eleccion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}
