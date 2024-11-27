using Algoritmos_y_estructura_de_datos.Algoritmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_y_estructura_de_datos.Clases
{
    public class ArbolAVL
    {
        public NodoAVL Raiz;

        public ArbolAVL()
        {
            Raiz = null;
        }

        public int Altura(NodoAVL nodo)
        {
            return nodo == null ? 0 : nodo.Altura;
        }

        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public NodoAVL RotDerecha(NodoAVL y)
        {
            if (y == null || y.Izquierda == null)
            {
                throw new InvalidOperationException("No se puede realizar rotacion derecha en el nodo nulo o su hijo izquierdo nulo");
            }

            NodoAVL x = y.Izquierda;
            NodoAVL T2 = x.Derecha;

            x.Derecha = y;
            y.Izquierda = T2;

            y.Altura = Max(Altura(y.Izquierda), Altura(y.Derecha)) + 1;
            x.Altura = Max(Altura(x.Izquierda), Altura(x.Derecha)) + 1;

            return x;
        }

        public NodoAVL RotIzquierda(NodoAVL x)
        {
            if (x == null || x.Derecha== null)
            {
                throw new InvalidOperationException("No se puede realizar rotacion izquierda en el nodo nulo o su hijo derecho nulo");
            }

            NodoAVL y = x.Derecha;
            NodoAVL T2 = y.Izquierda;

            y.Izquierda = x;
            x.Derecha = T2;

            x.Altura = Max(Altura(x.Izquierda), Altura(x.Derecha)) + 1;
            y.Altura = Max(Altura(y.Izquierda), Altura(y.Derecha)) + 1;

            return y;
        }

        public int GetBalance(NodoAVL nodo)
        {
            return nodo == null ? 0 : Altura(nodo.Izquierda) - Altura(nodo.Derecha);
        }

        public NodoAVL Insertar(NodoAVL nodo, Producto data)
        {
            if (nodo == null)
            {
                return new NodoAVL(data);
            }

            if (data.precio < nodo.Data.precio)
            {
                nodo.Izquierda = Insertar(nodo.Izquierda, data);
            }
            else if (data.precio > nodo.Data.precio)
            {
                nodo.Derecha = Insertar(nodo.Derecha, data);
            }
            else
            {
                nodo.Data = data;
                return nodo;
            }

            nodo.Altura = 1 + Max(Altura(nodo.Izquierda), Altura(nodo.Derecha));
            int balance = GetBalance(nodo);

            if (balance > 1 && nodo.Izquierda != null && GetBalance(nodo.Izquierda) >= 0)
            {
                return RotDerecha(nodo);
            }

            if (balance < -1 && nodo.Derecha != null && GetBalance(nodo.Derecha) <= 0)
            {
                return RotIzquierda(nodo);
            }

            if (balance > 1 && nodo.Izquierda != null && GetBalance(nodo.Izquierda) < 0)
            {
                nodo.Izquierda = RotIzquierda(nodo.Izquierda);
                return RotDerecha(nodo);
            }

            if (balance < -1 && nodo.Derecha != null && GetBalance(nodo.Derecha) > 0)
            {
                nodo.Derecha = RotDerecha(nodo.Derecha);
                return RotIzquierda(nodo);
            }

            return nodo;
        }

        public NodoAVL Eliminar(NodoAVL raiz, int id)
        {
            if (raiz == null)
            {
                return raiz;
            }

            if (id < raiz.Data.id)
            {
                raiz.Izquierda = Eliminar(raiz.Izquierda, id);
            }
            else if (id > raiz.Data.id)
            {
                raiz.Derecha = Eliminar(raiz.Derecha, id);
            }
            else
            {
                if ((raiz.Izquierda == null) || (raiz.Derecha == null))
                {
                    NodoAVL temp = null;
                    if (temp == raiz.Izquierda)
                        temp = raiz.Derecha;
                    else
                        temp = raiz.Izquierda;

                    if (temp == null)
                    {
                        temp = raiz;
                        raiz = null;
                    }
                    else 
                        raiz = temp;
                }
                else
                {
                    NodoAVL temp = NodoConValorMinimo(raiz.Derecha);

                    raiz.Data = temp.Data;

                    raiz.Derecha = Eliminar(raiz.Derecha, temp.Data.id);
                }
            }

            if (raiz == null)
                return raiz;

            raiz.Altura = Max(Altura(raiz.Izquierda), Altura(raiz.Derecha)) + 1;

            int balance = GetBalance(raiz);

            if (balance > 1 && GetBalance(raiz.Izquierda) >= 0)
                return RotDerecha(raiz);

            if (balance > 1 && GetBalance(raiz.Izquierda) < 0)
            {
                raiz.Izquierda = RotIzquierda(raiz.Izquierda);
                return RotDerecha(raiz);
            }

            if (balance < -1 && GetBalance(raiz.Derecha) <= 0)
                return RotIzquierda(raiz);

            if (balance < -1 && GetBalance(raiz.Derecha) > 0)
            {
                raiz.Derecha = RotDerecha(raiz.Derecha);
                return RotIzquierda(raiz);
            }

            return raiz;
        }

        NodoAVL NodoConValorMinimo(NodoAVL nodo)
        {
            NodoAVL actual = nodo;

            while (actual.Izquierda != null)
                actual = actual.Izquierda;

            return actual;
        }
    }
}
