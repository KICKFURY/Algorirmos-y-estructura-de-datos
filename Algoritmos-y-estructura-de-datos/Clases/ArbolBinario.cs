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
            bool esIzquierda = data.precio < nodoActual.Data.precio;
            Nodo siguiente = esIzquierda ? nodoActual.Izquierda : nodoActual.Derecho;
            
            if (siguiente == null) 
            {
                if (esIzquierda)
                    nodoActual.Izquierda = new Nodo(data);
                else 
                    nodoActual.Derecho = new Nodo(data);
            } 
            else 
            { 
                InsertarRecursivo(siguiente, data);
            }
        }

        public Nodo Eliminar(Nodo raiz, decimal precio)
        {
            if (raiz == null)
            {
                return raiz;
            }

            if (precio < raiz.Data.precio)
            {
                raiz.Izquierda = Eliminar(raiz.Izquierda, precio);
            }
            else if (precio > raiz.Data.precio)
            {
                raiz.Derecho = Eliminar(raiz.Derecho, precio);
            }
            else
            {
                if (raiz.Izquierda == null)
                {
                    return raiz.Derecho;
                }
                else if (raiz.Derecho == null)
                {
                    return raiz.Izquierda;
                }

                Nodo temp = NodoConValorMinimo(raiz.Derecho);
                raiz.Data = temp.Data;
                raiz.Derecho = Eliminar(raiz.Derecho, temp.Data.id);
            }

            return raiz;
        }

        private Nodo NodoConValorMinimo(Nodo nodo)
        {
            Nodo actual = nodo;

            while (actual.Izquierda != null)
            {
                actual = actual.Izquierda;
            }

            return actual;
        }
    }
}