using MySql.Data.MySqlClient;
using Proyecto_TDPII.Models.Proyecto_TDPII.Models;

namespace Proyecto_TDPII.Models
    {
        public class Consultas_Login
        {


            private string c = "Server=localhost;Port=3308;database=proyecto_tdpp;user=root;password=root;";

            public bool ValidarUsuario(Usuario u)
            {
                using (MySqlConnection conn = new MySqlConnection(c))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Usuario WHERE correo = @correo AND contrasena = @contrasena";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@correo", u.correo);
                        cmd.Parameters.AddWithValue("@contrasena", u.contrasena);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }

            public void Registar(Usuario u)
            {
                using (MySqlConnection conexion = new MySqlConnection(c))
                {
                    conexion.Open();


                    string query = "INSERT INTO Usuario (correo, contrasena) VALUES (@correo, @contrasena)";


                    MySqlCommand com = new MySqlCommand(query, conexion);


                    com.Parameters.AddWithValue("@correo", u.correo);
                    com.Parameters.AddWithValue("@contrasena", u.contrasena);


                    com.ExecuteNonQuery();
                }
            }

        }
    }
