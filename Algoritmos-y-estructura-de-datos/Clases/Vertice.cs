using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_y_estructura_de_datos.Clases
{
    public struct Proveedores
    {
        public int id;
        public string nombre;

        public Proveedores(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }

    public class Vertice
    {
        public Proveedores Data;
        public List<Arista> Aristas;
        public bool Visitado;
        public int Distancia;
        public Vertice Previo;

        public Vertice(Proveedores data)
        {
            Data = data;
            Aristas = new List<Arista>();
            Visitado = false;
            Distancia = int.MaxValue;
            Previo = null;
        }
    }
}
