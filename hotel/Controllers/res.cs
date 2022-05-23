using hotel.Models.dbModels;
using hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
