using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hotel.Models.dbModels;
using System.Security.Claims;

namespace hotel.Controllers
{
    public class TipoHabitacionsController : Controller
    {
        private readonly hotelContext _context;

        public TipoHabitacionsController(hotelContext context)
        {
            _context = context;
        }

        // GET: TipoHabitacions
        public async Task<IActionResult> Index()
        {
            int a = 0;
            try
            {
                a = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            catch (Exception)
            {
            }

            if (a == 1)
            {
                ViewBag.amIadmin = 1;
            }
            else
            {
                ViewBag.amIadmin = 0;
            }
            return View(await _context.TipoHabitacions.ToListAsync());
        }

        // GET: TipoHabitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoHabitacion = await _context.TipoHabitacions
                .FirstOrDefaultAsync(m => m.IdTipoHabitacion == id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return View(tipoHabitacion);
        }

        // GET: TipoHabitacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoHabitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoHabitacion,Nombre,Descripcion,Costo,CostoExPersona,RutaImg")] TipoHabitacion tipoHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoHabitacion);
        }

        // GET: TipoHabitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoHabitacion = await _context.TipoHabitacions.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }
            return View(tipoHabitacion);
        }

        // POST: TipoHabitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoHabitacion,Nombre,Descripcion,Costo,CostoExPersona,RutaImg")] TipoHabitacion tipoHabitacion)
        {
            if (id != tipoHabitacion.IdTipoHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoHabitacionExists(tipoHabitacion.IdTipoHabitacion))
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
            return View(tipoHabitacion);
        }

        // GET: TipoHabitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoHabitacion = await _context.TipoHabitacions
                .FirstOrDefaultAsync(m => m.IdTipoHabitacion == id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return View(tipoHabitacion);
        }

        // POST: TipoHabitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoHabitacion = await _context.TipoHabitacions.FindAsync(id);
            _context.TipoHabitacions.Remove(tipoHabitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoHabitacionExists(int id)
        {
            return _context.TipoHabitacions.Any(e => e.IdTipoHabitacion == id);
        }
    }
}
