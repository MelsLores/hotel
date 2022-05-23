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
    public class ReseñaController : Controller
    {
        private readonly hotelContext _context;

        public ReseñaController(hotelContext context)
        {
            _context = context;
        }

        // GET: Reseña
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

            var hotelContext = _context.Reseñas.Include(r => r.IdUsuarioNavigation).Include(r => r.TipoHabitacionNavigation);
            return View(await hotelContext.ToListAsync());
        }

        // GET: Reseña/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseñas
                .Include(r => r.IdUsuarioNavigation)
                .Include(r => r.TipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdReseña == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // GET: Reseña/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["TipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Nombre");
            return View();
        }

        // POST: Reseña/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReseña,IdUsuario,Reseña1,Fecha,TipoHabitacion,Puntuacion")] Reseña reseña)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reseña);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reseña.IdUsuario);
            ViewData["TipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Nombre", reseña.TipoHabitacion);
            return View(reseña);
        }

        // GET: Reseña/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseñas.FindAsync(id);
            if (reseña == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reseña.IdUsuario);
            ViewData["TipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Nombre", reseña.TipoHabitacion);
            return View(reseña);
        }

        // POST: Reseña/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReseña,IdUsuario,Reseña1,Fecha,TipoHabitacion,Puntuacion")] Reseña reseña)
        {
            if (id != reseña.IdReseña)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseña);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReseñaExists(reseña.IdReseña))
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
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reseña.IdUsuario);
            ViewData["TipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Nombre", reseña.TipoHabitacion);
            return View(reseña);
        }

        // GET: Reseña/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseñas
                .Include(r => r.IdUsuarioNavigation)
                .Include(r => r.TipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdReseña == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // POST: Reseña/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reseña = await _context.Reseñas.FindAsync(id);
            _context.Reseñas.Remove(reseña);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReseñaExists(int id)
        {
            return _context.Reseñas.Any(e => e.IdReseña == id);
        }
    }
}
