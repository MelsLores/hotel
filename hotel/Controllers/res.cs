using hotel.Models.dbModels;
using hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hotel.Controllers
{
    public class res : Controller
    {
    
        private readonly hotelContext _dbcontext;

        public res(hotelContext dbcontext)
        {
            _dbcontext = dbcontext;
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

            System.Diagnostics.Debug.WriteLine("as´ldfjasldjfasdf´ja´sdljfk");
            List<Reseña> reseñas = _dbcontext.Reseñas.ToList();
            ResenasVM rvm = new ResenasVM
            {
                
                Resenas = reseñas
            };
            
            return View(rvm);
        }
    }
}
