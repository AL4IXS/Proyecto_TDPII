using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto_TDPII.Models;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Proyecto_TDPII.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConexionMySQL _conexion;
        private readonly Consultas_Login _cl;

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
            return View("iniciosesion");
        }

        public IActionResult iniciosesion()
        {
            return View("index");
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
        public ActionResult InicioSesion(Usuario u)
        {
            var servicio = new Consultas_Login();
            bool credencialesCorrectas = servicio.ValidarUsuario(u);

            if (credencialesCorrectas)
                return View("Index"); // Acceso permitido
            else
                return Content("Credenciales incorrectas"); // Mensaje simple
        }


       [HttpPost]
        public IActionResult Registro(Usuario u)
        {
            var reg = new Consultas_Login();
            reg.Registar(u);
            return View("registroo");
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
            List<Evento> eventosDiciembre= _conexion.ObtenerEventosPorMes(12);
            return View(eventosDiciembre);
        }
        public IActionResult Semana()
        {
            return View();
        }
        public IActionResult dia()
        {
            return View();
        }

        public IActionResult semanaaa()
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
