using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto_TDPII.Models
{
    internal class Conexion
    {
        private MySqlConnection conexion;
        private string server = "localhost";
        private string database = "agenda";
        private string user = "root";
        private string password = "root";
        private string cadenaConexion;

        public Conexion() {
            cadenaConexion = "Database=" + database +
                "; Datasource=" + server +
                "; User Id=" + user +
                "; Password" + password;
        }
        public MySqlConnection getConexion()
        {
            if (conexion == null)
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
            }
            return conexion;
        }
    }
}
