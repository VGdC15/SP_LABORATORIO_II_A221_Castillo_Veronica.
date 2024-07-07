using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entidades
{

    public static class AccesoDatos
    {
        private static MySqlCommand command; // Objeto para ejecutar comandos SQL
        private static MySqlConnection connection; // Conexión a la base de datos
        private static string connectionString; // Cadena de conexión a la base de datos

        /// <summary>
        /// Constructor estático que inicializa la cadena de conexión a la base de datos MySQL.
        /// </summary>
        static AccesoDatos()
        {
            connectionString = "Server=localhost;Port=3307;Database=examen;User ID=root;Password=;SslMode=none;";
        }

        /// <summary>
        /// Método estático para guardar un mensaje de reparación en la base de datos.
        /// </summary>
        /// <param name="mensajeReparacion">Mensaje de reparación a guardar.</param>
        /// <returns>True si se guardó exitosamente, False si ocurrió un error.</returns>
        public static bool Guardar(string mensajeReparacion)
        {
            bool resultado = false;

            connection = new MySqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string query = "INSERT INTO taller(mensaje, alumno)" +
                    $"VALUES(@mensaje,@alumno)";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@mensaje", mensajeReparacion);
                command.Parameters.AddWithValue("@alumno", "Verónica");
                command.ExecuteNonQuery();
                resultado = true;
            }

            return resultado;
        }

        /// <summary>
        /// Método estático para guardar un objeto Barco en la base de datos.
        /// </summary>
        /// <param name="barco">Objeto Barco a guardar.</param>
        /// <returns>True si se guardó exitosamente, False si ocurrió un error.</returns>
        public static bool GuardarBarcos(Barco barco)
        {
            bool resultado = false;
            connection = new MySqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string query = "INSERT INTO tabla_crud (nombre, costo, operacion, tripulacion)" +
                    " VALUES (@nombre, @costo, @operacion, @tripulacion)";

                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", barco.Nombre);
                command.Parameters.AddWithValue("@costo", barco.Costo);
                command.Parameters.AddWithValue("@operacion", barco.Operacion.ToString());
                command.Parameters.AddWithValue("@tripulacion", barco.Tripulacion);
                command.ExecuteNonQuery();
                resultado = true;
            }

            return resultado;
        }

        /// <summary>
        /// Método estático para seleccionar todos los barcos almacenados en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Barco almacenados en la base de datos.</returns>
        public static List<Barco> SeleccionarBarcos()
        {
            List<Barco> listaBarcos = new List<Barco>();

            connection = new MySqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string query = "SELECT * FROM tabla_crud";
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string nombre = reader.GetString("nombre");
                    float costo = reader.GetFloat("costo");
                    string operacionStr = reader.GetString("operacion");
                    int tripulacion = reader.GetInt32("tripulacion");

                    EOperacion operacion = (EOperacion)Enum.Parse(typeof(EOperacion), operacionStr);

                }
            }

            return listaBarcos;
        }

        /// <summary>
        /// Método estático para modificar los datos de un barco almacenado en la base de datos.
        /// </summary>
        /// <param name="barco">Objeto Barco con los datos modificados.</param>
        /// <returns>True si se modificó exitosamente, False si ocurrió un error.</returns>
        public static bool ModificarBarcos(Barco barco)
        {
            bool resultado = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE tabla_crud SET nombre = @nombre, costo = @costo, operacion = @operacion, tripulacion = @tripulacion " +
                               "WHERE nombre = @nombre";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", barco.Nombre);
                    command.Parameters.AddWithValue("@costo", barco.Costo);
                    command.Parameters.AddWithValue("@operacion", barco.Operacion.ToString());
                    command.Parameters.AddWithValue("@tripulacion", barco.Tripulacion);
                    command.ExecuteNonQuery();
                }
            }

            return resultado;
        }

        /// <summary>
        /// Método estático para eliminar un barco de la base de datos según su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del barco a eliminar.</param>
        /// <returns>True si se eliminó exitosamente, False si ocurrió un error.</returns>
        public static bool EliminarBarco(string nombre)
        {
            bool resultado = false;
            connection = new MySqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string query = "DELETE FROM tabla_crud WHERE nombre = @nombre";
                MySqlCommand comando = new MySqlCommand(query, connection);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.ExecuteNonQuery();
            }

            return resultado;
        }
    }

}
