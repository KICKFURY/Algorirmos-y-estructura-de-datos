using Algoritmos_y_estructura_de_datos.Algoritmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_y_estructura_de_datos.Clases
{
    public class NodoAVL
    {
        public Producto Data;
        public NodoAVL Izquierda;
        public NodoAVL Derecha;
        public int Altura;

        public NodoAVL(Producto data)
        {
            Data = data;
            Izquierda = null;
            Derecha = null;
            Altura = 1;
        }
    }
}
