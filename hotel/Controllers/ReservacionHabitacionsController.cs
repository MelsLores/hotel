using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hotel.Models.dbModels
{
    public class ReservacionHabitacionsController : Controller
    {
        private readonly hotelContext _context;

        public ReservacionHabitacionsController(hotelContext context)
        {
            _context = context;
        }

        // GET: ReservacionHabitacions
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

            var hotelContext = _context.ReservacionHabitacions.Include(r => r.IdHabitacionNavigation).Include(r => r.IdReservacionNavigation);
            return View(await hotelContext.ToListAsync());
        }

        // GET: ReservacionHabitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacionHabitacion = await _context.ReservacionHabitacions
                .Include(r => r.IdHabitacionNavigation)
                .Include(r => r.IdReservacionNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacionHabitacion == null)
            {
                return NotFound();
            }

            return View(reservacionHabitacion);
        }

        // GET: ReservacionHabitacions/Create
        public IActionResult Create()
        {
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion");
            ViewData["IdReservacion"] = new SelectList(_context.Reservaciones, "IdReservacion", "IdReservacion");
            return View();
        }

        // POST: ReservacionHabitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReservacion,IdHabitacion")] ReservacionHabitacion reservacionHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservacionHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", reservacionHabitacion.IdHabitacion);
            ViewData["IdReservacion"] = new SelectList(_context.Reservaciones, "IdReservacion", "IdReservacion", reservacionHabitacion.IdReservacion);
            return View(reservacionHabitacion);
        }

        // GET: ReservacionHabitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacionHabitacion = await _context.ReservacionHabitacions.FindAsync(id);
            if (reservacionHabitacion == null)
            {
                return NotFound();
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", reservacionHabitacion.IdHabitacion);
            ViewData["IdReservacion"] = new SelectList(_context.Reservaciones, "IdReservacion", "IdReservacion", reservacionHabitacion.IdReservacion);
            return View(reservacionHabitacion);
        }

        // POST: ReservacionHabitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReservacion,IdHabitacion")] ReservacionHabitacion reservacionHabitacion)
        {
            if (id != reservacionHabitacion.IdReservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservacionHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacionHabitacionExists(reservacionHabitacion.IdReservacion))
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
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", reservacionHabitacion.IdHabitacion);
            ViewData["IdReservacion"] = new SelectList(_context.Reservaciones, "IdReservacion", "IdReservacion", reservacionHabitacion.IdReservacion);
            return View(reservacionHabitacion);
        }

        // GET: ReservacionHabitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacionHabitacion = await _context.ReservacionHabitacions
                .Include(r => r.IdHabitacionNavigation)
                .Include(r => r.IdReservacionNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacionHabitacion == null)
            {
                return NotFound();
            }

            return View(reservacionHabitacion);
        }

        // POST: ReservacionHabitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservacionHabitacion = await _context.ReservacionHabitacions.FindAsync(id);
            _context.ReservacionHabitacions.Remove(reservacionHabitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservacionHabitacionExists(int id)
        {
            return _context.ReservacionHabitacions.Any(e => e.IdReservacion == id);
        }
    }
}
