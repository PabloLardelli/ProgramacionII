using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    class DetalleReceta
    {
        public int Cantidad { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public DetalleReceta(int cantidad, Ingrediente ingrediente)
        {
            Cantidad = cantidad;
            Ingrediente = ingrediente;
        }

    }
}
