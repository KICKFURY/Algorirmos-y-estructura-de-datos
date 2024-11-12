using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Algoritmos_y_estructura_de_datos.Algoritmos
{
    public struct Producto
    {
        public int id;
        public string nombre;
        public decimal precio;

        public Producto(int id, string nombre, decimal precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
        }

        public override string ToString()
        {
            return $"{id}: {nombre} - {precio:C}";
        }
    }

    public class QuickSort
    {
        private Producto[] productos;
        private Action actualizarUI;
        //private int left, rigth;
        private Stack<Tuple<int, int>> callStack;

        public QuickSort(Producto[] productos, Action actualizarUI)
        {
           this.productos = productos;
           this.actualizarUI = actualizarUI;
            callStack = new Stack<Tuple<int, int>>();
        }

        public void IniciarQuickSort()
        {
            //left = 0;
            //rigth = productos.Length -1;
            callStack.Clear();
            callStack.Push(Tuple.Create(0, productos.Length - 1));
        }

        public bool Paso()
        {
            if (callStack.Count > 0)
            {
                var (left, right) = callStack.Pop();
                Console.WriteLine($"Esta particionando: left={left}, right={right}");
                if (left < right)
                {
                    int pivotIndex = Particion(left, right);

                    if (pivotIndex > left)
                    {
                        callStack.Push(Tuple.Create(left, pivotIndex - 1));
                    }
                    if (pivotIndex < right)
                    {
                        callStack.Push(Tuple.Create(pivotIndex + 1, right));
                    }
                }

                actualizarUI();
                return true;
            }
            return false;
        }

        private int Particion(int left, int right)
        {
            Producto pivot = productos[left];
            int storeIndex = left + 1;

            for (int i = left + 1; i <= right; i++)
            {
                if (productos[i].precio < pivot.precio ||
                   (productos[i].precio == pivot.precio && Suerte()))
                {
                    Intercambiar(i, storeIndex);
                    storeIndex++;
                    actualizarUI();
                }
            }

            Intercambiar(left, storeIndex - 1);
            actualizarUI();
            return storeIndex - 1;
        }

        private void Intercambiar(int i, int j)
        {
            Producto temp = productos[i];
            productos[i] = productos[j];
            productos[j] = temp;
        }

        private static bool Suerte()
        {
            return new Random().Next(2) == 0;
        }

        public int GetCallStackSize()
        {
            return callStack.Count;
        }

        public Producto[] GetProductos()
        { 
            return productos; 
        }
    }
}
