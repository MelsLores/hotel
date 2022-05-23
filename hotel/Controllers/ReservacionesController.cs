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
    public class ReservacionesController : Controller
    {
        private readonly hotelContext _context;

        public ReservacionesController(hotelContext context)
        {
            _context = context;
        }

        // GET: Reservaciones
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

            var hotelContext = _context.Reservaciones.Include(r => r.IdUsuarioNavigation).Include(r => r.MetodoPagoNavigation);
            return View(await hotelContext.ToListAsync());
        }

        // GET: Reservaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacione = await _context.Reservaciones
                .Include(r => r.IdUsuarioNavigation)
                .Include(r => r.MetodoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacione == null)
            {
                return NotFound();
            }

            return View(reservacione);
        }

        // GET: Reservaciones/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "Nombre");
            return View();
        }

        // POST: Reservaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReservacion,IdUsuario,FechaLlegada,FechaSalida,Detalles,MetodoPago,CantidadPersonas,CostoTotal")] Reservacione reservacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reservacione.IdUsuario);
            ViewData["MetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "Nombre", reservacione.MetodoPago);
            return View(reservacione);
        }

        // GET: Reservaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacione = await _context.Reservaciones.FindAsync(id);
            if (reservacione == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reservacione.IdUsuario);
            ViewData["MetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "Nombre", reservacione.MetodoPago);
            return View(reservacione);
        }

        // POST: Reservaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReservacion,IdUsuario,FechaLlegada,FechaSalida,Detalles,MetodoPago,CantidadPersonas,CostoTotal")] Reservacione reservacione)
        {
            if (id != reservacione.IdReservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacioneExists(reservacione.IdReservacion))
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
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reservacione.IdUsuario);
            ViewData["MetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "Nombre", reservacione.MetodoPago);
            return View(reservacione);
        }

        // GET: Reservaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacione = await _context.Reservaciones
                .Include(r => r.IdUsuarioNavigation)
                .Include(r => r.MetodoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacione == null)
            {
                return NotFound();
            }

            return View(reservacione);
        }

        // POST: Reservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservacione = await _context.Reservaciones.FindAsync(id);
            _context.Reservaciones.Remove(reservacione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservacioneExists(int id)
        {
            return _context.Reservaciones.Any(e => e.IdReservacion == id);
        }
    }
}
