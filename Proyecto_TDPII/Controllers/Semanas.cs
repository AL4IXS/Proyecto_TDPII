using Proyecto_TDPII.Models;

namespace Proyecto_TDPII.Controllers
{
    internal class Semanas
    {

        public int Semana1 { get; set; } // Número de la semana (1-53)
        public List<Evento>
    Eventos
        { get; set; } = new List<Evento>
        (); // Lista de eventos de la semana
    }
}