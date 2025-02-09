using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto_TDPII.Models;

namespace Proyecto_TDPII.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Enero()
        {
            return View();
        }

        public IActionResult Febrero()
        {
            return View();
        }

        public IActionResult Marzo()
        {
            return View();
        }

        public IActionResult Abril()
        {
            return View();
        }

        public IActionResult Mayo()
        {
            return View();
        }

        public IActionResult Junio()
        {
            return View();
        }

        public IActionResult Julio()
        {
            return View();
        }

        public IActionResult Agosto()
        {
            return View();
        }

        public IActionResult Septiembre()
        {
            return View();
        }

        public IActionResult Octubre()
        {
            return View();
        }
        public IActionResult Noviembre()
        {
            return View();
        }
        public IActionResult Diciembre()
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
