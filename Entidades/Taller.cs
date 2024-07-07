using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{

    public class Taller
    {
        private List<Barco> barcos; // Lista de barcos almacenados en el taller

        /// <summary>
        /// Propiedad para acceder a la lista de barcos del taller.
        /// </summary>
        public List<Barco> Barcos
        {
            get { return barcos; }
            set { barcos = value; }
        }

        /// <summary>
        /// Constructor de la clase Taller que inicializa la lista de barcos.
        /// </summary>
        public Taller()
        {
            this.barcos = new List<Barco>();
        }

        /// <summary>
        /// Método para verificar si un barco ya existe en el taller.
        /// </summary>
        /// <param name="barco">Barco a verificar.</param>
        /// <returns>True si el barco ya existe en el taller, False si no.</returns>
        public bool EncontrarBarco(Barco barco)
        {
            var resultado = false;
            foreach (var b in barcos)
            {
                if (b.CompararBarcos(barco))
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Método para ingresar un barco nuevo al taller, si no existe previamente.
        /// </summary>
        /// <param name="barco">Barco a ingresar.</param>
        /// <returns>Instancia del taller con el barco ingresado, o el mismo taller si ya existe.</returns>
        public Taller IngresarBarco(Barco barco)
        {
            if (!this.EncontrarBarco(barco))
            {
                this.barcos.Add(barco);
            }
            return this;
        }

        /// <summary>
        /// Método para reparar los barcos en el taller que no han sido reparados previamente.
        /// </summary>
        /// <param name="taller">Taller que contiene los barcos a reparar.</param>
        /// <returns>True si se reparó al menos un barco, False si no se reparó ninguno.</returns>
        public bool Reparar(Taller taller)
        {
            bool resultado = false;
            if (taller != null)
            {
                foreach (Barco listaBarcos in taller.barcos)
                {
                    if (!listaBarcos.EstadoReparado)
                    {
                        listaBarcos.CalcularCosto();
                        string mensaje = $"Se reparó el {listaBarcos.Nombre} a un costo de {listaBarcos.Costo} berries";
                        AccesoDatos.Guardar(mensaje);
                        listaBarcos.EstadoReparado = true;
                        resultado = true;
                        break;
                    }
                }
            }
            return resultado;
        }
    }

}
