using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    /// <summary>
    /// Clase XmlManager que implementa la interfaz IArchivos para operaciones de lectura y escritura XML.
    /// Permite guardar y leer listas de barcos en formato XML.
    /// </summary>
    public class XmlManager : IArchivos
    {
        /// <summary>
        /// Método para guardar la lista de barcos en un archivo XML en la ruta especificada.
        /// </summary>
        /// <param name="path">Ruta del archivo XML donde se guardarán los barcos.</param>
        /// <param name="taller">Instancia de la clase Taller que contiene la lista de barcos a guardar.</param>
        /// <returns>True si el guardado fue exitoso, False si ocurrió un error.</returns>
        public bool Guardar(string path, Taller taller)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Barco>));
                using (StreamWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, taller.Barcos); // Serializa la lista de barcos del taller
                }
                return true; // Retorna true si se guardó correctamente
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar en XML: {ex.Message}");
                return false; // Retorna false si hubo un error al guardar
            }
        }

        /// <summary>
        /// Método para leer la lista de barcos desde un archivo XML en la ruta especificada.
        /// </summary>
        /// <param name="path">Ruta del archivo XML desde donde se leerán los barcos.</param>
        /// <returns>Lista de barcos leída desde el archivo XML, o una lista vacía si ocurrió un error.</returns>
        public List<Barco> Leer(string path)
        {
            List<Barco> barcosLeidos = new List<Barco>();

            try
            {
                using (XmlReader reader = XmlReader.Create(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Barco>));
                    barcosLeidos = (List<Barco>)serializer.Deserialize(reader); // Deserializa el archivo XML a una lista de barcos
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer desde XML: {ex.Message}");
            }

            return barcosLeidos; // Retorna la lista de barcos leída desde el archivo XML, o una lista vacía si hubo un error
        }
    }

}
