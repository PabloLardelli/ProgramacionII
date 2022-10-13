using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Interfaz
{
    public interface IServicio
    {
        int ProximaReceta();
        bool CrearReceta(Receta oReceta);
        DataTable ObtenerIngredientes();
       

    }
}
