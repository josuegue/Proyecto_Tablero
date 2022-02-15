// See https://aka.ms/new-console-template for more information
using System;

namespace TablaPocisiones
{
    class Program
    {


        static void Main(string [] args)
        {
            CargarDatosJson cargar = new CargarDatosJson();
            String[,] datos = cargar.obtener_datos();
            cargar.ver_matriz(datos);
            Console.WriteLine("Termino de cargar datos");
        }
    }
}
