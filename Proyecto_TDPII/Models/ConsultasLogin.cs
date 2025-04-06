using MySql.Data.MySqlClient;

namespace Proyecto_TDPII.Models
{
    public class ConsultasLogin
    {


        private string conexion = "Server=localhost;Port=3306;database=proyecto_tdpp;user=root;password=root;";

        public bool VerificarCredenciales(Usuario u)
        {
            using var conn = new MySqlConnection(conexion);
            conn.Open();

            using var cmd = new MySqlCommand(ConsultasSQL.VerificarCredenciales, conn);
            cmd.Parameters.AddWithValue("@correo", u.correo);
            cmd.Parameters.AddWithValue("@contrasena", u.contrasena);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public void InsertarUsuario(Usuario u)
        {
            using var conn = new MySqlConnection(conexion);
            conn.Open();

            using var cmd = new MySqlCommand(ConsultasSQL.InsertarUsuario, conn);
            cmd.Parameters.AddWithValue("@correo", u.correo);
            cmd.Parameters.AddWithValue("@contrasena", u.contrasena);

            cmd.ExecuteNonQuery();

        }
        }
    }
