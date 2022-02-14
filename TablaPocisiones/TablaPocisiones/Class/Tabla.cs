using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablaPocisiones.Class
{
    internal class Tabla
    {
        /*
         * Modelo de la tabla que me sirve para obtener datos del Achivo JSON que cree. 
         * 
         * 
         */
        public string nombreEquipo { get; set; }
        public int jornada { get; set; }
        public int puntos { get; set; }
        public int ganados { get; set; }
        public int goles_favor { get; set; }
        public int goles_contra { get; set; }
        public int empates { get; set; }
        public int perdidos { get; set; }
        public int df_goles { get; set; }
        
    }
}
