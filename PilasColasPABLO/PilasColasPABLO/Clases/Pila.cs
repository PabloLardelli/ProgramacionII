using PilasColasPABLO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColasPABLO.Clases
{
    public class Pila : ICollection
    {
        private object[] array;
        private int contador;

        public Pila(int cant)
        {
            contador = -1;
            array = new object[cant];
        }

        public bool EstaVacia()
        {
            return contador == -1;    
        }
        public object Extraer()
        {
            object e = null;

            if (!EstaVacia())
            {
                e = array[contador];
                array[contador] = null;
                contador--;
            }
            return e;

        }

        public object Primero()
        {
            object e = null;

            if (!EstaVacia())
            {
                e = array[0];
            }
            return e;

        }
        public bool Añadir(object elemento)
        {
            bool añadido = false;

            if (contador < array.Length)
            {
                array[++contador] = elemento;
                añadido = true;
            }

            return añadido;
        }




    }
}
