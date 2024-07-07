using System;
using Entidades;

namespace PRUEBA
{
    class Program
    {
        static void Main(string[] args)
        {
            Taller taller = new Taller();
            Pirata b1 = new Pirata(323, false, "oscar", EOperacion.Reparar_Mascaron, 20);
            Marina m1 = new Marina(234, false, "pepe", EOperacion.Pintar, 54);

            taller.IngresarBarco(b1);
            taller.IngresarBarco(m1);

            XmlManager xml = new XmlManager();
            xml.Guardar("C:\\Users\\Verónica\\Desktop\\archivo\\pueba.xml",taller);

        }
    }
}
