using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carreras.Dominio
{
    class Carrera
    {
        public int Id_Carrera { get; set; }
        public string Titulo { get; set; }
        public List<DetalleCarrera> Detalles { get; set; }

        public Carrera()
        {
            Detalles = new List<DetalleCarrera>();
        }


        public void AgregarDetalle(DetalleCarrera detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice)
        {
            Detalles.RemoveAt(indice);
        }


    }
}
