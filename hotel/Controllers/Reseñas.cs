using hotel.Models.dbModels;
using hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hotel.Controllers
{
    public class Reseñas : Controller
    {
        string _val;
        private readonly hotelContext _context;
        private readonly hotelContext _dbcontext;
        public List<Reseña> Resenas { get; set; }
        public Reseñas(hotelContext context, hotelContext dbcontext)
        {
            _context = context;
            _dbcontext = dbcontext;
        }
        

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            ViewData["TipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Nombre");
            System.Diagnostics.Debug.WriteLine("hola bb");
            List<Reseña> reseñas = _dbcontext.Reseñas.ToList();
            ResenasVM rvm = new ResenasVM
            {

                Resenas = reseñas
            };

            return View();


        }

        /*public IActionResult Index(string Iselect, string Itext, string rating,string val) {

            System.Diagnostics.Debug.WriteLine(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            System.Diagnostics.Debug.WriteLine(rating+"/"+Itext +"/" +Iselect);
            string aux = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int d = Int32.Parse(aux);
            ViewData["TipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Nombre");
            return View();
        }*/

        [HttpPost]
         public async Task<IActionResult> Index([Bind("IdReseña,IdUsuario,Reseña1,Fecha,TipoHabitacion,Puntuacion")] Reseña reseña)
         {

             if (ModelState.IsValid)
             {
                System.Diagnostics.Debug.WriteLine(reseña.TipoHabitacion);
                reseña.Fecha = DateTime.Now;
                reseña.IdUsuario = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.Add(reseña);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
             ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reseña.IdUsuario);
             ViewData["TipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Nombre", reseña.TipoHabitacion);
             return View(reseña);

         }
    }
}
