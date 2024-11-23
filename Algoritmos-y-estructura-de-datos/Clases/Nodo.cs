using Algoritmos_y_estructura_de_datos.Algoritmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_y_estructura_de_datos.Clases
{
    public class Nodo
    {
        public Producto Data;
        public Nodo Izquierda;
        public Nodo Derecho;

        public Nodo(Producto data)
        {
            Data = data;
            Izquierda = null;
            Derecho = null;
        }
    }
}
