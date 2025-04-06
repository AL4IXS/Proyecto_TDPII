namespace Proyecto_TDPII.Models
{
    public class SqlQueries
    {

        public const string VerificarCredenciales =
           "SELECT COUNT(*) FROM Usuario WHERE correo = @correo AND contrasena = @contrasena";

        public const string InsertarUsuario =
            "INSERT INTO Usuario (correo, contrasena) VALUES (@correo, @contrasena)";


    }
}
