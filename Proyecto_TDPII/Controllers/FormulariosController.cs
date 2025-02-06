using Microsoft.AspNetCore.Mvc;
using Proyecto_TDPII.Models;
using System.Diagnostics;

namespace Proyecto_TDPII.Controllers
{
    public class FormulariosController : Controller
    {
        private readonly ILogger<FormulariosController> _logger;

        public FormulariosController(ILogger<FormulariosController> logger)
        {
            _logger = logger;
        }

        public IActionResult Crear_evento()
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
