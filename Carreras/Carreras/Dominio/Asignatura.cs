using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carreras.Dominio
{
    class Asignatura
    {
        public int Id_asignatura { get; set; }
        public string Nombre { get; set; }

        public Asignatura(int id,string nombre)
        {
            Id_asignatura = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
