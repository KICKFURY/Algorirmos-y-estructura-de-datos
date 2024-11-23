using Algoritmos_y_estructura_de_datos.Algoritmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_y_estructura_de_datos.Clases
{
    public class ArbolBinario
    {
        public Nodo Raiz;

        public ArbolBinario() 
        {
            Raiz = null;
        }

        public void Insertar(Producto data)
        {
            if (Raiz == null)
            {
                Raiz = new Nodo(data);
            }
            else
            {
                InsertarRecursivo(Raiz, data);
            }
        }

        private void InsertarRecursivo(Nodo nodoActual, Producto data)
        {
            if (data.precio < nodoActual.Data.precio)
            {
                if (nodoActual.Izquierda == null)
                {
                    nodoActual.Izquierda = new Nodo(data);
                } 
                else
                {
                    InsertarRecursivo(nodoActual.Izquierda, data);
                }
            }
            else
            {
                if(nodoActual.Derecho == null)
                {
                    nodoActual.Derecho = new Nodo(data);
                }
                else
                {
                    InsertarRecursivo(nodoActual.Derecho, data);
                }
            }
        }

        public void RecorrerEnOrden(Nodo nodo, Action<Producto> accion)
        {
            if (nodo != null)
            {
                RecorrerEnOrden(nodo.Izquierda, accion);
                accion(nodo.Data);
                RecorrerEnOrden(nodo.Derecho, accion);
            }
        }
    }
}
