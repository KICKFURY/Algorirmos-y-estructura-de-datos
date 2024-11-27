using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_y_estructura_de_datos.Clases
{
    public class Arista
    {
        public Vertice Destino;
        public int Peso;

        public Arista(Vertice destino, int peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }
}
