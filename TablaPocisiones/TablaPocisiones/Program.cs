// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;

namespace TablaPocisiones
{
    class Program
    {


        static void Main(string [] args)
        {
            CargarDatosJson cargar = new CargarDatosJson();
            bool llave = true;
            string[,] datos = cargar.obtener_datos();
            
            while (llave)
            {
                Console.Write("\n---- MENU PRINCIPAL ----" +
                    "\n 0. Salir" +
                    "\n 1. Ver matriz" +
                    "\n 2. Modificar datos" +
                    "\n 3. Generar nuevo Json" +
                    "\n - Ingresse opcicon : ");
                string opcion = Console.ReadLine();
                

                if (Regex.IsMatch(opcion, @"^[0-9]+$"))
                {
                    int op = Convert.ToInt32(opcion);
                    switch (op)
                    {
                        case 0:
                            Console.Write("Desea salir de la aplicacion. Esciba 'SI' o 'NO': ");
                            string lectura = Console.ReadLine();
                            lectura = lectura.ToUpper();

                            if (lectura.Equals("SI"))
                            {
                                llave = false;
                            }
                            else if (lectura.Equals("NO"))
                            {
                                llave = true;
                            }
                            else
                            {
                                Console.WriteLine("Seleccionaste una opcion invalida....");
                            }

                            break;
                        case 1:
                            /*
                             * Aqui en vez de ver matriz se va a poner el metodo que ordena los equipos por puntuacion
                             */
                            Console.WriteLine("\n_____--- Datos de los equipos ---_____");
                            String[,] datos_ordenados = cargar.ordenar_por_puntos(datos);
                            cargar.ver_matriz(datos_ordenados);
                            Console.WriteLine("--------------- Final ---------------");
                            break;
                        case 2:
                            Console.WriteLine("\n_____--- Modificar datos ---_____");
                            Console.Write("Ingresa nombre del equipo: ");
                            string nombre_equipo = Console.ReadLine();
                            cargar.modificar_datos(nombre_equipo, datos);
                            Console.WriteLine("------------- Final -------------");
                            break;
                        case 3:
                            Console.WriteLine("\n_____--- Creando archivo ---_____");
                            cargar.archivo_nuevo(datos);
                            break;
                        default:
                            Console.WriteLine("\nOpcion invalida, volve a intentar por favor...");
                            break;

                    }

                }
                else
                {
                    Console.WriteLine("No es entero");
                }

                Console.WriteLine();
            }
            Console.WriteLine("Gracias por usar nuestros servicios <3");
        }
    }
}
