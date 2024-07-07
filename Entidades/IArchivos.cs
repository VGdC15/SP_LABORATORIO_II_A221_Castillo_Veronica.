using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz que define métodos para guardar y leer datos relacionados con un taller de barcos.
    /// </summary>
    public interface IArchivos
    {
        bool Guardar(string path, Taller taller);

        List<Barco> Leer(string path);
    }

}
