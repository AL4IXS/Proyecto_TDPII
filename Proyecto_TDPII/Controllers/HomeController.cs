using System.Diagnostics;
using System.Globalization;
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
            var usuario = _conexion.ObtenerEventos();
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


        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult Enero()
        {
            List<Evento> eventosEnero = _conexion.ObtenerEventosPorMes(1);
            return View(eventosEnero);
        }

        public IActionResult Febrero()
        {
            List<Evento> eventosFebrero = _conexion.ObtenerEventosPorMes(2);
            return View(eventosFebrero);
        }
        [HttpPost]
        public IActionResult GuardarEvento(Evento evento)
        {
            _conexion.InsertarEvento(evento);
            return RedirectToAction("Index");
        }
        public IActionResult agregarevento()
        {
            return View();
        }

        public IActionResult habitos()
        {
            return View();
        }


        public IActionResult Marzo()
        {
            List<Evento> eventosMarzo = _conexion.ObtenerEventosPorMes(3);
            return View(eventosMarzo);
        }

        public IActionResult Abril()
        {
            List<Evento> eventosAbril = _conexion.ObtenerEventosPorMes(4);
            return View(eventosAbril);
        }

        public IActionResult Mayo()
        {
            List<Evento> eventosMayo = _conexion.ObtenerEventosPorMes(5);
            return View(eventosMayo);
        }

        public IActionResult Junio()
        {
            List<Evento> eventosJunio = _conexion.ObtenerEventosPorMes(6);
            return View(eventosJunio);
        }

        public IActionResult Julio()
        {
            List<Evento> eventosJulio = _conexion.ObtenerEventosPorMes(7);
            return View(eventosJulio);
        }

        public IActionResult Agosto()
        {
            List<Evento> eventosAgosto = _conexion.ObtenerEventosPorMes(8);
            return View(eventosAgosto);
        }

        public IActionResult Septiembre()
        {
            List<Evento> eventosSeptiembre = _conexion.ObtenerEventosPorMes(9);
            return View(eventosSeptiembre);
        }

        public IActionResult Octubre()
        {
            List<Evento> eventosOctubre = _conexion.ObtenerEventosPorMes(10);
            return View(eventosOctubre);
        }
        public IActionResult Noviembre()
        {
            List<Evento> eventosNoviembre = _conexion.ObtenerEventosPorMes(11);
            return View(eventosNoviembre);
        }
        public IActionResult Diciembre()
        {
            List<Evento> eventosDiciembre = _conexion.ObtenerEventosPorMes(12);
            return View(eventosDiciembre);
        }
        public IActionResult Semana()
        {
            return View();
        }
       public IActionResult Dia(string fecha)
        {
            string fechaActual = fecha;
            var eventos = _conexion.ObtenerEventosPorDia(fechaActual);
            ViewBag.Fecha = fechaActual;
            return View(eventos);
        }



        public IActionResult Semanaaa(int? semana, int? anio)
        {
            int anioActual = anio ?? DateTime.Now.Year;
            int semanaActual = semana ?? ISOWeek.GetWeekOfYear(DateTime.Now);

            // Validación*
            if (semanaActual < 1 || semanaActual > 53 || anioActual < 2000 || anioActual > 2100)
            {
                semanaActual = ISOWeek.GetWeekOfYear(DateTime.Now);
                anioActual = DateTime.Now.Year;
            }

            var eventos = _conexion.ObtenerEventosPorSemana(semanaActual, anioActual);

            // Calcular el primer día de la semana
            var primerDiaSemana = ISOWeek.ToDateTime(anioActual, semanaActual, DayOfWeek.Monday);

            ViewBag.Anio = anioActual;
            ViewBag.Semana = semanaActual;
            ViewBag.PrimerDiaSemana = primerDiaSemana;

            return View(eventos);
        }




        public IActionResult iniciosesion()
        {
            return View();
        }
        public IActionResult todos_eventos()
        {
            List<Evento> eventos = _conexion.ObtenerEventos();
            return View(eventos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
