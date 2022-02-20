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


        private string path_archivo_new = @"C:\Users\click\Downloads\NuevoJson.json";
        //path de donde esta la ubicacion del archivo
        private static string path_archivo = @"C:\Users\click\Documents\ProyectosCsharp\Equipofut\TablaPocisiones\TablaPocisiones\Class\Archivos\TablaEquipos.json";
        public string [,]? obtener_datos()
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
                return array2d;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
			return null;

        }

        public void ver_matriz(string [,] matriz)
        {

            Console.WriteLine("Equipo | J  | Pts | G | P | E | GF | GC | DG| ");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    
                    Console.Write(matriz[i,j] + "| ");
                    

                }
                Console.WriteLine();
            }
        }
        /*
         * Ordenar los datos por punteo. 
         * 
         */
        public string [,] ordenar_por_puntos(string [,] matriz)
        {
            string[,] mat_aux = new string[1, 9];
            for (int i = 0; i< matriz.GetLength(0); i++)
            {
                for(int j = 1; j <matriz.GetLength(0); j++)
                {
                    if (int.Parse(matriz[i, 1]) < int.Parse(matriz[j, 1]) )
                    {
                        mat_aux[i, 0] = matriz[i, 0];
                        mat_aux[i, 1] = matriz[i, 1];
                        mat_aux[i, 2] = matriz[i, 2];
                        mat_aux[i, 3] = matriz[i, 3];
                        mat_aux[i, 4] = matriz[i, 4];
                        mat_aux[i, 5] = matriz[i, 5];
                        mat_aux[i, 6] = matriz[i, 6];
                        mat_aux[i, 7] = matriz[i, 7];
                        mat_aux[i, 8] = matriz[i, 8];

                        matriz[i, 0] = matriz[j, 0];
                        matriz[i, 1] = matriz[j, 1];
                        matriz[i, 2] = matriz[j, 2];
                        matriz[i, 3] = matriz[j, 3];
                        matriz[i, 4] = matriz[j, 4];
                        matriz[i, 5] = matriz[j, 5];
                        matriz[i, 6] = matriz[j, 6];
                        matriz[i, 7] = matriz[j, 7];
                        matriz[i, 8] = matriz[j, 8];

                        matriz[j, 0] = mat_aux[i, 0];
                        matriz[j, 1] = mat_aux[i, 1];
                        matriz[j, 2] = mat_aux[i, 2];
                        matriz[j, 3] = mat_aux[i, 3];
                        matriz[j, 4] = mat_aux[i, 4];
                        matriz[j, 5] = mat_aux[i, 5];
                        matriz[j, 6] = mat_aux[i, 6];
                        matriz[j, 7] = mat_aux[i, 7];
                        matriz[j, 8] = mat_aux[i, 8];







                    }
                }
            }
            return matriz;
        }



        /*
         * Modificar los valores de la tabla. Pero primero se debe de 
         * buscar al equipo por el nombre.
         * 
         */
        public void modificar_datos(string nombre_equipo, string [,] matriz)
        {
            for(int i = 0; i < matriz.GetLength(0); i++)
            {
                if (nombre_equipo.ToLower().Equals(matriz[i, 0].ToLower()))
                {
                    Console.Write("Escribe 'si', 'no' o e'empate' y los formularios se desplegaran." +
                        "\nEscribe opcion: ");
                    string verificador = Console.ReadLine();
                    if (verificador.ToLower().Equals("si"))
                    {

                        Console.Write("Goles a favor: ");
                        int goles_fv = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Goles en contra: ");
                        int goles_c = Convert.ToInt32(Console.ReadLine());
                        int df_goles = (goles_fv) + (goles_c);

                        int jornada = Convert.ToInt32(matriz[i, 1]) + 1;
                        int puntos = Convert.ToInt32(matriz[i, 2]) + 3;
                        int ganados = Convert.ToInt32(matriz[i, 3]) + 1;
                        goles_fv = Convert.ToInt32(matriz[i, 6]) + goles_fv;
                        goles_c = Convert.ToInt32(matriz[i, 7]) + goles_c;
                        df_goles = goles_fv - goles_c;

                        //jornada
                        matriz[i, 1] = jornada.ToString();
                        //puntos
                        matriz[i, 2] = puntos.ToString();
                        //ganados
                        matriz[i, 3] = ganados.ToString();
                        //Asignacion de goles
                        matriz[i, 6] = goles_fv.ToString();
                        matriz[i, 7] = goles_c.ToString();
                        matriz[i,8]=df_goles.ToString();

                        
                    }
                    else if (verificador.ToLower().Equals("no")){
                        
                        Console.Write("Goles a favor: ");
                        int goles_fv = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Goles en contra: ");
                        int goles_c = Convert.ToInt32(Console.ReadLine());
                        int df_goles = (goles_fv) + (goles_c);

                        int jornada = Convert.ToInt32(matriz[i, 1]) + 1;
                        goles_fv = Convert.ToInt32(matriz[i, 6]) + goles_fv;
                        goles_c = Convert.ToInt32(matriz[i, 7]) + goles_c;
                        df_goles = goles_fv - goles_c;
                        int perdidos = Convert.ToInt32(matriz[i, 4]) +1;
                        //jornada
                        matriz[i, 1] = jornada.ToString();
                        //perdidos
                        matriz[i, 4] = perdidos.ToString();
                        //Asignacion de goles
                        matriz[i, 6] = goles_fv.ToString();
                        matriz[i, 7] = goles_c.ToString();
                        matriz[i, 8] = df_goles.ToString();
                    }
                    else if (verificador.ToLower().Equals("empate"))
                    {

                        Console.Write("Goles a favor: ");
                        int goles_fv = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Goles en contra: ");
                        int goles_c = Convert.ToInt32(Console.ReadLine());


                        int df_goles = (goles_fv) + (goles_c);
                        int jornada = Convert.ToInt32(matriz[i, 1]) + 1;
                        goles_fv = Convert.ToInt32(matriz[i, 6]) + goles_fv;
                        goles_c = Convert.ToInt32(matriz[i, 7]) + goles_c;
                        df_goles = goles_fv - goles_c;
                        int empate = Convert.ToInt32(matriz[i, 5]) + 1;
                        int puntos = Convert.ToInt32(matriz[i, 2]) + 1;

                        //jornada
                        matriz[i, 1] = jornada.ToString(); 
                        //puntos
                        matriz[i, 2] = puntos.ToString();
                        //empates
                        matriz[i, 5] = empate.ToString();
                        //Asignacion de goles
                        matriz[i, 6] =  goles_fv.ToString();
                        matriz[i, 7] = goles_c.ToString();
                        matriz[i, 8] = df_goles.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Opcion equivocada");
                        break;
                    }

                }

            }

        }

        /*
         * Geneerar un nuevo archivo Json 
         */
        public void archivo_nuevo(string [,] matriz_datos)
        {
            Tabla data;
            List<Tabla> lista = new List<Tabla>();
            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                data = new Tabla();
                data.nombreEquipo = matriz_datos[i, 0];
                data.jornada = Int32.Parse(matriz_datos[i, 1]);
                data.puntos = Int32.Parse(matriz_datos[i, 2]);
                data.ganados = Int32.Parse(matriz_datos[i, 3]);
                data.perdidos = Int32.Parse(matriz_datos[i, 4]);
                data.empates = Int32.Parse(matriz_datos[i, 5]);
                data.goles_favor = Int32.Parse(matriz_datos[i, 6]);
                data.goles_contra = Int32.Parse(matriz_datos[i, 7]);
                data.df_goles = Int32.Parse(matriz_datos[i, 8]);
                lista.Add(data);
                
            }

            var listaJson = JsonConvert.SerializeObject(lista);
            System.IO.File.WriteAllText(this.path_archivo_new, listaJson);
            Console.WriteLine($"Archivo Json creado, ver en el path {this.path_archivo_new}");
        }
    }
}
