using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GenerarRandom
    {
        /// <summary>
        /// Genera un número aleatorio de tipo double dentro de un rango especificado.
        /// </summary>
        /// <param name="num1">Límite inferior del rango.</param>
        /// <param name="num2">Límite superior del rango.</param>
        /// <returns>Número aleatorio de tipo double.</returns>
        public static double DoubleAleatorio(int num1, int num2)
        {
            Random rand = new Random();
            double resultado = rand.NextDouble() * (num2 - num1) + num1;
            return resultado;
        }

        /// <summary>
        /// Genera un número aleatorio de tipo entero dentro de un rango especificado.
        /// </summary>
        /// <param name="min">Valor mínimo del rango (por defecto: 0).</param>
        /// <param name="max">Valor máximo del rango (por defecto: int.MaxValue).</param>
        /// <returns>Número aleatorio de tipo entero.</returns>
        public static int EnteroAleatorio(int min = 0, int max = int.MaxValue)
        {
            Random rand = new Random();
            int resultado = rand.Next(min, max);
            return resultado;
        }
    }

}
