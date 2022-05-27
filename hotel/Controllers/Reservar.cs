using hotel.Models.dbModels;
using hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hotel.Controllers
{
    [Authorize]
    public class Reservar : Controller
    {

        private readonly hotelContext _dbcontext;
        private readonly hotelContext _context;

        public Reservar(hotelContext dbcontext, hotelContext context)
        {
            _dbcontext = dbcontext;
            _context = context;
        }

        public DbSet<Reservacione> reservar { get; set; }
        /*       public IQueryable<Reservacione> crearReserv(){


                   return;
               }*/
        public IActionResult Index()
        {
            /* var cad= _context.Users.Where(x => x.Id == 1).Select(x => x.PasswordHash);
             var cad2 = from Users in _context.Users select new { User };
             System.Diagnostics.Debug.WriteLine("**********************************************************"+cad2);
             Json(cad2);*/


            /*
            SqlCommand sql = new SqlCommand("SELECT * FROM Reservaciones");
            using (SqlDataReader reader = sql.ExecuteReader()) {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}",
                        reader[0], reader[1]));
                }
            }*/

            /*
            using (var co = new hotelContext())
            {
                var cd = (from Reservacione in _context.Reservaciones
                          
                          )


            }
            */

            var ab = _context.Reservaciones.FromSqlRaw("SELECT * FROM reservaciones").ToList();
            //var ab2 =_context.Reservaciones.FromSqlRaw("SELECT * FROM AspNetUsers").ToList();

            System.Diagnostics.Debug.WriteLine(ab);

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
            System.Diagnostics.Debug.WriteLine("álskdjfálsdjfkajdlk´f");
            List<TipoHabitacion> tipoHabitacion = _dbcontext.TipoHabitacions.ToList();
            List<Reservacione> reservaciones = _dbcontext.Reservaciones.ToList();
            List<ReservacionHabitacion> reservacionHabitacion = _dbcontext.ReservacionHabitacions.ToList();
            List<Habitacione> habitaciones = _dbcontext.Habitaciones.ToList();
            List<MetodoPago> aux = _dbcontext.MetodoPagos.ToList();
            ViewBag.MetodoPago = aux;
            ReservarVM hvm = new ReservarVM
            {
                TipoHabitaciones = tipoHabitacion,
                Reservacions = reservaciones,
                reservacionHabitacions = reservacionHabitacion,
                habitacions = habitaciones

            };
            ViewBag.General = hvm;
            return View(0);
        }
        /*
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Index([Bind("IdReservacion,IdUsuario,Item1.FechaLlegada,FechaSalida,Detalles,MetodoPago,CantidadPersonas,CostoTotal")] Reservacione reservacione)
                {
                    if (ModelState.IsValid)
                    {
                        //_context.Reservaciones.FromSqlRaw("INSERT INTO reservaciones (idUsuario,fechaLlegada,fechaSalida,detalles,metodoPago,cantidadPersonas,costoTotal) VALUES ('" + Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) + ",'2022-01-11 00:00:00.000','2022-01-13 00:00:00.000','a','1','1','20')");


                        reservacione.IdUsuario = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                        string dateaux = reservacione.FechaLlegada.ToString();
                        System.Diagnostics.Debug.WriteLine(dateaux);
                        System.Diagnostics.Debug.WriteLine(reservacione.FechaLlegada);
                        _context.Add(reservacione);



                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reservacione.IdUsuario);
                    ViewData["MetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "Nombre", reservacione.MetodoPago);
                    return View(reservacione);
                }*/


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string FechaLlegada, string FechaSalida, string Detalles, string MetodoPago, string TipoHabitacion, string CantidadPersonas)
        {
            TipoHabitacion = TipoHabitacion.Split("-")[0];
            var tp = Int32.Parse(TipoHabitacion);
            double costoT=0;
            List<TipoHabitacion> tipoHabitacion = _dbcontext.TipoHabitacions.ToList();
            foreach (TipoHabitacion habitac in tipoHabitacion)
            {
                if (habitac.IdTipoHabitacion == tp) {
                    costoT = habitac.Costo;
                }

                
            }

           
            


            try {
                var habD = _context.Habitaciones.FromSqlRaw("SELECT TOP 1 * FROM habitaciones WHERE tipoHabitacion='" + tp + "' AND disponibilidad='True'").ToList();
                System.Diagnostics.Debug.WriteLine(habD[0].IdHabitacion);

                

                _context.Database.ExecuteSqlRaw("UPDATE habitaciones SET disponibilidad='False' WHERE idHabitacion='" + habD[0].IdHabitacion + "'");

                _context.Database.ExecuteSqlRaw("INSERT INTO reservaciones (idUsuario,fechaLlegada,fechaSalida,detalles,metodoPago,cantidadPersonas,costoTotal) VALUES ('" + Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) + "','" + FechaLlegada + "','" + FechaSalida + "','" + Detalles + "','" + MetodoPago + "','" + CantidadPersonas + "','" + costoT + "')");
                var lastID = _context.Reservaciones.FromSqlRaw("SELECT TOP 1 * FROM reservaciones ORDER BY idReservacion DESC ").ToList();


                _context.Database.ExecuteSqlRaw("INSERT INTO reservacion_habitacion (idReservacion,idHabitacion) VALUES ('" + lastID[0].IdReservacion + "','" + habD[0].IdHabitacion + "')");


            }
            catch (Exception) {
                Index();
                return View(2);
            }
            /*********************************************
             * 
             * DECIR QUE NO HAY HABITACIONES Q NO SE HOSPEDE AQUI
             * 
             * *********************************************/

            Object a= Index();
            return View(1);
        }
    }
}
