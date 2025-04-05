using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Proyecto_TDPII.Models
{
    public class ConsultaMySQL
    {
        private readonly MYSQLConexion _connectionProvider;

        public ConsultaMySQL(MYSQLConexion connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public List<Evento> ObtenerEventos()
        {
            var eventos = new List<Evento>();

            using (var conexion = _connectionProvider.GetConnection())
            {
                conexion.Open();
                var comando = new MySqlCommand(ConsultasSQL.ObtenerTodosLosEventos, conexion);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventos.Add(new Evento
                        {
                            Id = reader.GetInt32("id"),
                            Titulo = reader.GetString("titulo"),
                            Fecha = reader.GetString("fecha"),
                            hora_inicio = reader.GetString("hora_inicio"),
                            Hora_fin = reader.GetString("hora_fin"),
                            Ubicacion = reader.GetString("ubicacion"),
                            Descripcion = reader.GetString("descripcion")
                        });
                    }
                }
            }

            return eventos;
        }

        public void InsertarEvento(Evento evento)
        {
            using (var conexion = _connectionProvider.GetConnection())
            {
                conexion.Open();

                var insertar = new MySqlCommand(ConsultasSQL.InsertarEvento, conexion);
                insertar.Parameters.AddWithValue("@titulo", evento.Titulo);
                insertar.Parameters.AddWithValue("@fecha", evento.Fecha);
                insertar.Parameters.AddWithValue("@horaI", evento.hora_inicio);
                insertar.Parameters.AddWithValue("@horaF", evento.Hora_fin);
                insertar.Parameters.AddWithValue("@ubicacion", evento.Ubicacion);
                insertar.Parameters.AddWithValue("@descripcion", evento.Descripcion);

                insertar.ExecuteNonQuery();
            }
        }

        public List<Evento> ObtenerEventosPorMes(int mes)
        {
            var eventos = new List<Evento>();

            using (var conexion = _connectionProvider.GetConnection())
            {
                conexion.Open();
                var comando = new MySqlCommand(ConsultasSQL.ObtenerEventosPorMes, conexion);
                comando.Parameters.AddWithValue("@mes", mes);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventos.Add(new Evento
                        {
                            Titulo = reader["titulo"].ToString(),
                            Fecha = reader["fecha"].ToString(),
                            Ubicacion = reader["ubicacion"].ToString(),
                            Descripcion = reader["descripcion"].ToString()
                        });
                    }
                }
            }

            return eventos;
        }

        public List<Evento> ObtenerEventosPorSemana(int semana, int anio)
        {
            var eventos = new List<Evento>();

            using (var conexion = _connectionProvider.GetConnection())
            {
                conexion.Open();
                var comando = new MySqlCommand(ConsultasSQL.ObtenerEventosPorSemana, conexion);
                comando.Parameters.AddWithValue("@semana", semana);
                comando.Parameters.AddWithValue("@anio", anio);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventos.Add(new Evento
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Titulo = reader["titulo"].ToString(),
                            Fecha = reader["fecha"].ToString(),
                            hora_inicio = reader["hora_inicio"].ToString(),
                            Hora_fin = reader["hora_fin"].ToString(),
                            Ubicacion = reader["ubicacion"].ToString(),
                            Descripcion = reader["descripcion"].ToString()
                        });
                    }
                }
            }

            return eventos;
        }

        public List<Evento> ObtenerEventosPorDia(string fecha)
        {
            var eventos = new List<Evento>();

            using (var conexion = _connectionProvider.GetConnection())
            {
                conexion.Open();
                var comando = new MySqlCommand(ConsultasSQL.ObtenerEventosPorDia, conexion);
                comando.Parameters.AddWithValue("@fecha", fecha);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventos.Add(new Evento
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Titulo = reader["titulo"].ToString(),
                            Fecha = reader["fecha"].ToString(),
                            hora_inicio = reader["hora_inicio"].ToString(),
                            Hora_fin = reader["hora_fin"].ToString(),
                            Ubicacion = reader["ubicacion"].ToString(),
                            Descripcion = reader["descripcion"].ToString()
                        });
                    }
                }
            }

            return eventos;
        }
    }
}

