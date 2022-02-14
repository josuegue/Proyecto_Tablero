using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TablaPocisiones.Class;
using Newtonsoft.Json;


namespace TablaPocisiones
{
    internal class CargarDatosJson
    {
        //Variable en a que se va a guardar la matriz
        private string [,] contenido;
        //path de donde esta la ubicacion del archivo
        private static string path_archivo = @"C:\Users\click\source\repos\TablaPocisiones\TablaPocisiones\Class\Archivos\TablaEquipos.json";
        private void obtener_datos()
        {
            // Inicializo las variables siguientes
            /*
             * Una me sirve para guardar los datos en el array 
             * El otro me sirve para calcular el tamaño de filas del array 
             * 
             * 
             */
            string[,] array2d;
            int count = 0;
            /*
             * Inicio con un try por que ahi proceso el archivo Json lo paso a una lista y de una lista a Matriz 
             */
            try
            {
                // las siguientes 3 lineas de codigo sirven para leer el Json y asignarlo a una Lista
                StreamReader r = new StreamReader(path_archivo);
                string lecturaJson = r.ReadToEnd();
                var listado =  JsonConvert.DeserializeObject<List<Tabla>>(lecturaJson);

                //foreach usado para calcular el tamaño de mi matriz
                foreach (Tabla tabla in listado)
                {
                    if (tabla != null)
                    {
                        count++;
                        continue;
                    }

                }
                //Defino el tamaño de mi Matriz
                array2d = new string[count, 9];

                //Asigno los valores a cada iteracion de la matriz.
                for (int i = 0; i < count; i++)
                {
                        array2d[i, 0] = listado[i].nombreEquipo.ToString();
                        array2d[i, 1] = listado[i].jornada.ToString();
                        array2d[i, 2] = listado[i].puntos.ToString();
                        array2d[i, 3] = listado[i].ganados.ToString();
                        array2d[i, 4] = listado[i].perdidos.ToString();
                        array2d[i, 5] = listado[i].empates.ToString();
                        array2d[i, 6] = listado[i].goles_favor.ToString();
                        array2d[i, 7] = listado[i].goles_contra.ToString();
                        array2d[i, 8] = listado[i].df_goles.ToString();

                    
                }
                //se asigna a mi variable global para poder manipular las busquedas y las reasignaciones de datos.
                this.contenido = array2d;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void ver_matriz()
        {
            obtener_datos();

            for (int i = 0; i < this.contenido.GetLength(0); i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(this.contenido[i,j] + "| ");
                    

                }
                Console.WriteLine();
            }
        }
        /*
         * Ordenar los datos por punteo. 
         * 
         */
        public void ordenar_por_puntos()
        {

        }


        /*
         * Modificar los valores de la tabla. Pero primero se debe de 
         * buscar al equipo por el nombre.
         * 
         */
        public void modificar_datos(string nombre_equipo)
        {

        }

        /*
         * Geneerar un nuevo archivo Json 
         */
        public void archivo_nuevo()
        {

        }
    }
}
