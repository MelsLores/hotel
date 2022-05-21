using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.Controllers
{
    public class Mision : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
