using hotel.Models.dbModels;
using hotel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.Controllers
{
    public class HabitacionesClienteController : Controller
    {
        private readonly hotelContext _dbcontext;

        public HabitacionesClienteController(hotelContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: HabitacionesClienteController
        

        // GET: HabitacionesClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Index()
        {
            List<TipoHabitacion> tipoHabitacion = _dbcontext.TipoHabitacions.ToList();
            HabitacionesVM hvm = new HabitacionesVM
            {
                TipoHabitaciones = tipoHabitacion
            };
            return View(hvm);
        }

        // GET: HabitacionesClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionesClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HabitacionesClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HabitacionesClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HabitacionesClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HabitacionesClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
