using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Proyecto_TDPII.Models
{
    public class ConexionMySQL
    {

        private readonly string _conexion;

        public ConexionMySQL(IConfiguration configuration)
        {
            _conexion = configuration.GetConnectionString("MiConexionMySQL");
        }

        public List<Evento> ObtenerEventos()
        {
            List<Evento> eventos = new List<Evento>();

            using (MySqlConnection conexion = new MySqlConnection(_conexion))
            {
                conexion.Open();
                string query = "SELECT id, titulo, fecha, hora_inicio, hora_fin, ubicacion, descripcion FROM evento";
                MySqlCommand comando = new MySqlCommand(query, conexion);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventos.Add(new Evento
                        {
                            Id = reader.GetInt32("id"),
                            Titulo = reader.GetString("titulo"),
                            Fecha = reader.GetString("fecha"),
                            HoraInicio = reader.GetString("hora_inicio"),
                            HoraFin = reader.GetString("hora_fin"),
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
            using (MySqlConnection conexion = new MySqlConnection(_conexion))
            {
                conexion.Open();


                string query = "INSERT INTO evento (titulo, fecha, hora_inicio, hora_fin, ubicacion, descripcion) " +
                               "VALUES (@titulo, @fecha, @horaI, @horaF, @ubicacion, @descripcion)";


                MySqlCommand insertar = new MySqlCommand(query, conexion);


                insertar.Parameters.AddWithValue("@titulo", evento.Titulo);
                insertar.Parameters.AddWithValue("@fecha", evento.Fecha);
                insertar.Parameters.AddWithValue("@horaI", evento.HoraInicio);
                insertar.Parameters.AddWithValue("@horaF", evento.HoraFin);
                insertar.Parameters.AddWithValue("@ubicacion", evento.Ubicacion);
                insertar.Parameters.AddWithValue("@descripcion", evento.Descripcion);

                insertar.ExecuteNonQuery();
            }
        }

        public List<Evento> ObtenerEventosPorMes(int mes)
        {
            List<Evento> eventos = new List<Evento>();

            using (MySqlConnection conexion = new MySqlConnection(_conexion))
            {
                conexion.Open();
                string query = "SELECT * FROM evento WHERE MONTH(fecha) = @mes";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@mes", mes);

                using (MySqlDataReader reader = comando.ExecuteReader())
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
            List<Evento> eventos = new List<Evento>();
            using (MySqlConnection conexion = new MySqlConnection(_conexion))
            {
                conexion.Open();
                string query = "SELECT * FROM evento WHERE WEEK(fecha, 1) = @semana AND YEAR(fecha) = @anio";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@semana", semana);
                comando.Parameters.AddWithValue("@anio", anio);

                using (MySqlDataReader reader = comando.ExecuteReader())
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



    }
}