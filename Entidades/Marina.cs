using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    [Serializable]
    public class Marina : Barco
    {
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Marina con los valores proporcionados.
        /// </summary>
        /// <param name="costo">Costo del barco.</param>
        /// <param name="EstadoReparado">Estado de reparación del barco.</param>
        /// <param name="Nombre">Nombre del barco.</param>
        /// <param name="operacion">Operación del barco.</param>
        /// <param name="Tripulacion">Número de tripulantes del barco.</param>
        public Marina(float costo, bool EstadoReparado, string Nombre, EOperacion operacion, int Tripulacion) : base(costo, EstadoReparado, Nombre, operacion, Tripulacion)
        {

        }

        /// <summary>
        /// Propiedad que obtiene o establece el número de tripulantes del barco de tipo Marina.
        /// Si no se ha establecido, genera un valor aleatorio entre 30 y 60.
        /// </summary>
        public override int Tripulacion
        {
            get
            {
                if (tripulacion == 0)
                {
                    tripulacion = GenerarRandom.EnteroAleatorio(30, 61); // Genera un número aleatorio entre 30 y 60
                }
                return tripulacion;
            }
            set
            {
                tripulacion = value;
            }
        }

        /// <summary>
        /// Calcula el costo de reparación del barco de tipo Marina, generando un valor aleatorio entre 5000 y 25000.
        /// </summary>
        public override void CalcularCosto()
        {
            Costo = (float)GenerarRandom.DoubleAleatorio(5000, 25000); // Calcula el costo como un número decimal aleatorio entre 5000 y 25000
        }

        /// <summary>
        /// Constructor sin parámetros para la clase Marina.
        /// </summary>
        public Marina()
        {
        }

        /// <summary>
        /// Retorna una cadena que representa los datos del barco de tipo Marina.
        /// </summary>
        /// <returns>Cadena que contiene la información del barco de tipo Marina.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Datos del Barco de la Marina:");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }

}
