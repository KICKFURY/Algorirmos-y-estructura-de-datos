using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_y_estructura_de_datos.Clases
{
    public class Grafo
    {
        public List<Vertice> Vertices;

        public Grafo()
        {
            Vertices = new List<Vertice>();
        }

        public void AgregarVertice(Proveedores data)
        {
            Vertices.Add(new Vertice(data));
        }

        public void AgregarArista(int idOrigen, int idDestino, int peso)
        {
            Vertice vOrigen = Vertices.Find(v => v.Data.id == idOrigen);
            Vertice vDestino = Vertices.Find(v => v.Data.id == idDestino);

            if (vOrigen != null && vDestino != null)
            {
                vOrigen.Aristas.Add(new Arista(vDestino, peso));
                vDestino.Aristas.Add(new Arista(vOrigen, peso));
            }
        }

        public void ActualizarDistancia(int idOrigen, int idDestino, int distancia)
        {
            Vertice vOrigen = Vertices.Find(v => v.Data.id == idOrigen);
            Vertice vDestino = Vertices.Find(v => v.Data.id == idDestino);

            if (vOrigen != null && vDestino != null)
            {
                foreach (var arista in vOrigen.Aristas)
                {
                    if (arista.Destino == vDestino)
                    {
                        arista.Peso = distancia;
                    }
                }

                foreach (var arista in vDestino.Aristas)
                {
                    if (arista.Destino == vOrigen)
                    {
                        arista.Peso = distancia;
                    }
                }
            }
        }

        public void EliminarDistancia(int idOrigen, int idDestino)
        {
            Vertice vOrigen = Vertices.Find(v => v.Data.id == idOrigen);
            Vertice vDestino = Vertices.Find(v => v.Data.id == idDestino);

            if (vOrigen != null && vDestino != null)
            {
                vOrigen.Aristas.RemoveAll(a => a.Destino == vDestino);
                vDestino.Aristas.RemoveAll(a => a.Destino == vOrigen);
            }
        }

        public void Dijkstra(int idorigen)
        {
            Vertice vOrigen = Vertices.Find(v => v.Data.id == idorigen);
            if (vOrigen == null)
                return;

            vOrigen.Distancia = 0;
            var colaPrioridad = new SortedSet<Vertice>(Comparer<Vertice>.Create((a, b) =>
            {
                int result = a.Distancia.CompareTo(b.Distancia);
                return result == 0 ? a.GetHashCode().CompareTo(b.GetHashCode()) : result;
            }));

            colaPrioridad.Add(vOrigen);

            while (colaPrioridad.Any())
            {
                Vertice u = colaPrioridad.Min;
                colaPrioridad.Remove(u);
                u.Visitado = true;

                foreach (var arista in u.Aristas)
                {
                    if (!arista.Destino.Visitado && u.Distancia + arista.Peso < arista.Destino.Distancia)
                    {
                        colaPrioridad.Remove(arista.Destino);
                        arista.Destino.Distancia = u.Distancia + arista.Peso;
                        arista.Destino.Previo = u;
                        colaPrioridad.Add(arista.Destino);
                    }
                }
            }
        }

        public List<Proveedores> ObtenerRutaMasCorta(int idDestino)
        {
            Vertice vDestino = Vertices.Find(v => v.Data.id == idDestino);
            var ruta = new List<Proveedores>();

            while (vDestino != null)
            {
                ruta.Insert(0, vDestino.Data);
                vDestino = vDestino.Previo;
            }

            return ruta;
        }
    }
}
