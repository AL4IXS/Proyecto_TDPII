namespace Proyecto_TDPII.Models
{
    public static class ConsultasSQL
    {
        public const string ObtenerTodosLosEventos = @"
            SELECT id, titulo, fecha, hora_inicio, hora_fin, ubicacion, descripcion 
            FROM evento";

        public const string InsertarEvento = @"
            INSERT INTO evento (titulo, fecha, hora_inicio, hora_fin, ubicacion, descripcion) 
            VALUES (@titulo, @fecha, @horaI, @horaF, @ubicacion, @descripcion)";

        public const string ObtenerEventosPorMes = @"
            SELECT * FROM evento 
            WHERE MONTH(fecha) = @mes";

        public const string ObtenerEventosPorSemana = @"
            SELECT * FROM evento 
            WHERE WEEK(STR_TO_DATE(fecha, '%Y-%m-%d'), 1) = @semana 
            AND YEAR(STR_TO_DATE(fecha, '%Y-%m-%d')) = @anio
            ORDER BY fecha, hora_inicio";

        public const string ObtenerEventosPorDia = @"
            SELECT * FROM evento 
            WHERE fecha = @fecha
            ORDER BY hora_inicio";
    }
}
