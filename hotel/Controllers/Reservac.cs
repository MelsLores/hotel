using hotel.Models.dbModels;
using hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hotel.Controllers
{
    public class Reservac : Controller
    {
        private readonly hotelContext _dbcontext;
        private readonly hotelContext _context;
        public int idG;

        public Reservac(hotelContext dbcontext, hotelContext context)
        {
            _dbcontext = dbcontext;
            _context = context;
        }

        public IActionResult Index()
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

            List<TipoHabitacion> tipoHabitacion = _dbcontext.TipoHabitacions.ToList();
            List<Reservacione> reservaciones = _dbcontext.Reservaciones.ToList();
            List<ReservacionHabitacion> reservacionHabitacion= _dbcontext.ReservacionHabitacions.ToList();
            List<MetodoPago> aux = _dbcontext.MetodoPagos.ToList();

            List<Habitacione> habitaciones = _dbcontext.Habitaciones.ToList();
            ViewBag.MetodoPago = aux;
            ReservarVM hvm = new ReservarVM
            {
                TipoHabitaciones = tipoHabitacion,
                Reservacions = reservaciones,
                reservacionHabitacions = reservacionHabitacion,
                habitacions = habitaciones

            };
            ViewBag.General = hvm;
            ViewBag.ReservacionHabitacion = reservacionHabitacion;

            return View(Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            Index();
            if (id == null)
            {
                return NotFound();
            }
            int success = 0;
            Object data = null;
            var a =_context.ReservacionHabitacions.FromSqlRaw("SELECT TOP 1 * FROM reservacion_habitacion WHERE idReservacion='" + id + "'").ToList();
            // Request.Form["FechaLlegada"] = res[0].FechaLlegada;
        
            var tuple = new Tuple< hotel.Models.dbModels.ReservacionHabitacion , int>(a[0], success);
            return View(tuple);





        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int?id,string FechaLlegada, string FechaSalida, string Detalles, string MetodoPago, string TipoHabitacion, string CantidadPersonas)
        {
            

            TipoHabitacion = TipoHabitacion.Split("-")[0];
            var tp = Int32.Parse(TipoHabitacion);
            double costoT = 0;
            List<TipoHabitacion> tipoHabitacion = _dbcontext.TipoHabitacions.ToList();
            foreach (TipoHabitacion habitac in tipoHabitacion)
            {
                if (habitac.IdTipoHabitacion == tp)
                {
                    costoT = habitac.Costo;
                }


            }





                var habD = _context.Habitaciones.FromSqlRaw("SELECT TOP 1 * FROM habitaciones WHERE tipoHabitacion='" + tp + "' AND disponibilidad='True'").ToList();
                System.Diagnostics.Debug.WriteLine(habD[0].IdHabitacion);

                var ab = _context.ReservacionHabitacions.FromSqlRaw("SELECT TOP 1 * FROM reservacion_habitacion WHERE idReservacion='" + id + "'").ToList();


                _context.Database.ExecuteSqlRaw("UPDATE habitaciones SET disponibilidad='False' WHERE idHabitacion='" + habD[0].IdHabitacion + "'");

                _context.Database.ExecuteSqlRaw("UPDATE habitaciones SET disponibilidad='True' WHERE idHabitacion='" + ab[0].IdHabitacion + "'");

                _context.Database.ExecuteSqlRaw("UPDATE reservaciones SET fechaLlegada='"+ FechaLlegada + "',fechaSalida='"+ FechaSalida + "',detalles='"+Detalles+"',metodoPago='"+MetodoPago+"',cantidadPersonas='"+CantidadPersonas+",costoTotal='"+costoT + "' WHERE idReservacion='"+id+"'");
               

                _context.Database.ExecuteSqlRaw("UPDATE reservacion_habitacion SET idHabitacion='"+ habD[0].IdHabitacion + "' WHERE idReservacion='"+id+"'");




            Index();
            if (id == null)
            {
                return NotFound();
            }
            int success = 0;
            Object data = null;
            var a = _context.ReservacionHabitacions.FromSqlRaw("SELECT TOP 1 * FROM reservacion_habitacion WHERE idReservacion='" + id + "'").ToList();
            // Request.Form["FechaLlegada"] = res[0].FechaLlegada;

            var tuple = new Tuple<hotel.Models.dbModels.ReservacionHabitacion, int>(a[0], success);
            return View(tuple);


        }


        private bool ReservacioneExists(int id)
        {
            return _context.Reservaciones.Any(e => e.IdReservacion == id);
        }
    }
}
