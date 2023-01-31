using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            
            ViewBag.Nombre = "Bienvenido al sistema de administración de Aulas.";

            ViewBag.Fecha = DateTime.Now.ToString();

            return View();

        }
        
    }
}
