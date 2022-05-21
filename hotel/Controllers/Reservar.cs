using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.Controllers
{
    [Authorize]
    public class Reservar : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
