using RecetasSLN.datos;
using RecetasSLN.dominio;
using RecetasSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Implementacion
{
    class Servicio
    {
        HelperDB ayudante;
        public Servicio()
        {
            ayudante = new HelperDB();
        }

        public int ProximaReceta()
        {
            return ayudante.ProximaReceta();
        }

        public bool CrearReceta(Receta oReceta)
        {
            return ayudante.Confirmar(oReceta);
        }

        public DataTable ObtenerIngredientes()
        {
            return ayudante.EjecutarSql();
        }
        

    }
}
