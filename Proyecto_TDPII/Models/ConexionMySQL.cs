using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Proyecto_TDPII.Models
{
    public class ConexionMySQL
    {
        private readonly string _cadenaConexion;

        public ConexionMySQL(IConfiguration configuration)
        {
            _cadenaConexion = configuration.GetConnectionString("MiConexionMySQL");
        }

        public List<string> ObtenerUsuarios()
        {
            List<string> usuario = new List<string>();

            using (MySqlConnection conexion = new MySqlConnection(_cadenaConexion))
            {
                conexion.Open();
                string query = "SELECT Nombre FROM usuario"; 
                MySqlCommand comando = new MySqlCommand(query, conexion);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario.Add(reader["nombre"].ToString());
                    }
                }
            }

            return usuario;
        }
    }
}