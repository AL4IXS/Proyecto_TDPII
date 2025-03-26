using System;
using MySql.Data.MySqlClient;
using System.IO;

namespace Proyecto_TDPII.Models
{
    public class AuthService
    {
        private readonly string _connectionString;

        public AuthService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MiConexionMySQL");
        }

        public bool ValidarUsuario(string email, string password)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM usuario WHERE correo = @email AND contraseña = @password";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public string RegistrarUsuario(Usuario usuario)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO usuario 
                              (nombre, apellido, edad, correo, contraseña) 
                              VALUES (@nombre, @apellidos, @edad, @correo, @contraseña)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@edad", usuario.Edad);
                    command.Parameters.AddWithValue("@correo", usuario.Correo);
                    command.Parameters.AddWithValue("@contraseña", usuario.Contraseña);

                    command.ExecuteNonQuery();
                    return "Registro exitoso";
                }
            }
        }
    }
}
