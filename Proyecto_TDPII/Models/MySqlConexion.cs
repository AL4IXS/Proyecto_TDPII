using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Proyecto_TDPII.Models
{
    public class MYSQLConexion
    {
        private readonly string _connectionString;

        public MYSQLConexion(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MiConexionMySQL");
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}

