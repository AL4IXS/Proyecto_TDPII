using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Proyecto_TDPII.Models;

namespace Proyecto_TDPII.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConexionMySQL _conexion;
        private readonly AuthService _authService;


        public HomeController(ILogger<HomeController> logger, ConexionMySQL conexion, AuthService authService)
        {
            _logger = logger;
            _conexion = conexion;
            _authService = authService; 

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
        public IActionResult GuardarUsusario(Usuario usuario)
        {
            _conexion.InsertarUsuario(usuario);
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

        public IActionResult InicioSesion()
        {
            return View();
        }


        public IActionResult todos_eventos()
        {
            List<Evento> eventos = _conexion.ObtenerEventos();
            return View(eventos);
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (_authService.ValidarUsuario(email, password))
            {
                return RedirectToAction("Dashboard");
            }

            TempData["Error"] = "Credenciales incorrectas";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Registro(string nombre, string apellido, int edad, string email, string password)
        {
            var usuario = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                Correo = email,
                Contraseña = password
            };

            try
            {
                var resultado = _authService.RegistrarUsuario(usuario);
                TempData["Success"] = resultado;
                return RedirectToAction("Index");
            }
            catch (MySqlException ex)
            {
                TempData["Error"] = ex.Number == 1062 ?
                    "El correo ya está registrado" :
                    "Error al registrar";
                return RedirectToAction("Index");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
