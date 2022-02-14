// See https://aka.ms/new-console-template for more information
using System;

namespace TablaPocisiones
{
    class Program
    {


        static void Main(string [] args)
        {
            CargarDatosJson cargar = new CargarDatosJson();
            cargar.ver_matriz();
            Console.WriteLine("Termino de cargar datos");
        }
    }
}
