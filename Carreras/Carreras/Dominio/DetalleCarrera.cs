using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carreras.Dominio
{
    class DetalleCarrera
    {
        public int AnioCursado { get; set; }
        public int Cuatrimestre { get; set; }
        public Asignatura Asignatura { get; set; }

        public DetalleCarrera(int año, int cuatrimestre, Asignatura asignatura)
        {
            AnioCursado = año;
            Cuatrimestre = cuatrimestre;
            Asignatura = asignatura;
        }



    }
}
