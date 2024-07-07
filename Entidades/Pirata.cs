using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    [Serializable]
    public class Pirata : Barco
    {
        /// <summary>
        /// Constructor que inicializa una instancia de Pirata con los atributos especificados.
        /// </summary>
        /// <param name="costo">Costo del barco Pirata.</param>
        /// <param name="EstadoReparado">Estado de reparación del barco Pirata.</param>
        /// <param name="Nombre">Nombre del barco Pirata.</param>
        /// <param name="operacion">Operación asociada al barco Pirata.</param>
        /// <param name="Tripulacion">Tripulación actual del barco Pirata.</param>
        public Pirata(float costo, bool EstadoReparado, string Nombre, EOperacion operacion, int Tripulacion)
            : base(costo, EstadoReparado, Nombre, operacion, Tripulacion)
        {

        }

        /// <summary>
        /// Propiedad abstracta sobreescrita que define y calcula la tripulación del barco Pirata.
        /// Si la tripulación es cero, genera un número aleatorio entre 10 y 31.
        /// </summary>
        public override int Tripulacion
        {
            get
            {
                if (tripulacion == 0)
                {
                    return GenerarRandom.EnteroAleatorio(10, 31);
                }
                return tripulacion;
            }
            set
            {
                tripulacion = value;
            }
        }

        /// <summary>
        /// Método sobreescrito que calcula el costo del barco Pirata de manera aleatoria entre 2000 y 12000.
        /// </summary>
        public override void CalcularCosto()
        {
            Costo = (float)GenerarRandom.DoubleAleatorio(2000, 12000);
        }

        /// <summary>
        /// Constructor por defecto de la clase Pirata.
        /// </summary>
        public Pirata()
        {
        }

        /// <summary>
        /// Método ToString sobreescrito que devuelve una cadena con los datos del barco Pirata.
        /// </summary>
        /// <returns>Cadena que representa los datos del barco Pirata.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Datos del Barco Pirata:");
            sb.AppendLine(base.ToString()); // Llama al método ToString de la clase base (Barco)
            return sb.ToString();
        }
    }

}
