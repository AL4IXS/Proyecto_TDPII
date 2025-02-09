using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto_TDPII.Models;

namespace Proyecto_TDPII.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConexionMySQL _conexion;



        public HomeController(ILogger<HomeController> logger, ConexionMySQL conexion)
        {
            _logger = logger;
            _conexion = conexion;
        }

        public IActionResult lista()
        {
            var usuario = _conexion.ObtenerUsuarios();  
            return View(usuario);  
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AgregarEvento()
        {
            return View();

        }

        public IActionResult EditarEvento()
        {

            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
