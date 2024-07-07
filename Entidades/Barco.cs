using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{

    [Serializable]
    [XmlInclude(typeof(Pirata))] // Permite la serialización de la clase Pirata
    [XmlInclude(typeof(Marina))] // Permite la serialización de la clase Marina
    public abstract class Barco
    {
        protected float costo; // Costo del barco
        protected bool estadoReparado; // Estado de reparación del barco
        protected string nombre; // Nombre del barco
        protected EOperacion operacion; // Operación actual del barco
        protected int tripulacion; // Número de tripulantes del barco
        protected ETipoBarco tipo; // Tipo de barco


        public float Costo { get; set; }

        public bool EstadoReparado { get; set; }

        public string Nombre { get; set; }

        public EOperacion Operacion { get; set; }

        public abstract int Tripulacion { get; set; }

        public ETipoBarco Tipo { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase Barco.
        /// </summary>
        public Barco()
        {

        }

        /// <summary>
        /// Constructor parametrizado de la clase Barco que inicializa las propiedades básicas del barco.
        /// </summary>
        /// <param name="costo">Costo del barco.</param>
        /// <param name="EstadoReparado">Estado de reparación del barco.</param>
        /// <param name="Nombre">Nombre del barco.</param>
        /// <param name="operacion">Operación actual del barco.</param>
        /// <param name="Tripulacion">Número de tripulantes del barco.</param>
        public Barco(float costo, bool EstadoReparado, string Nombre, EOperacion operacion, int Tripulacion)
        {
            this.costo = costo;
            this.estadoReparado = EstadoReparado;
            this.nombre = Nombre;
            this.operacion = operacion;
            this.tripulacion = Tripulacion;
        }

        /// <summary>
        /// Método abstracto para calcular el costo total del barco.
        /// </summary>
        public abstract void CalcularCosto();

        /// <summary>
        /// Método para comparar dos barcos según su nombre.
        /// </summary>
        /// <param name="otroBarco">Otro barco a comparar.</param>
        /// <returns>True si los nombres de los barcos son iguales, False en caso contrario.</returns>
        public bool CompararBarcos(Barco otroBarco)
        {
            bool resultado = this.nombre == otroBarco.nombre;
            return resultado;
        }

        /// <summary>
        /// Sobrescritura del método ToString para obtener una representación en cadena del objeto Barco.
        /// </summary>
        /// <returns>Cadena que representa el objeto Barco con sus propiedades.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.nombre} ** ");
            sb.AppendLine($"Costo: {this.Costo} ** ");
            sb.AppendLine($"Estado Reparado: {this.EstadoReparado}  ** ");
            sb.AppendLine($"Operación: {this.Operacion} ** ");
            sb.AppendLine($"Tripulación: {this.Tripulacion}  ** ");
            return sb.ToString();
        }
    }

}
