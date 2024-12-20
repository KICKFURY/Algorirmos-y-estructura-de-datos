﻿using Algoritmos_y_estructura_de_datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos_y_estructura_de_datos.Formularios
{
    public partial class ShellSort : Form
    {
        private Dictionary<string, decimal> productos;
        private List<Tuple<string, string, int, decimal, decimal>> listaProductos; // Nombre, Producto, Cantidad, Precio, Total

        public ShellSort()
        {
            InitializeComponent();
            ConfigurarProductos();
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;

        }

        private void ConfigurarProductos()
        {
            // Inicializar productos y precios
            productos = new Dictionary<string, decimal>
            {
                { "Procesador", 120m },
                { "Placa Base", 80m },
                { "Memoria RAM 8GB", 40m },
                { "Disco SSD 240GB", 30m },
                { "Disco Duro 500GB", 40m },
                { "Fuente de Alimentación", 50m },
                { "Tarjeta Gráfica", 150m },
                { "Caja/Torre", 40m },
                { "Ventilador de CPU", 15m },
                { "Teclado Mecánico", 30m },
                { "Ratón Óptico", 10m },
                { "Unidad Óptica (DVD)", 20m },
            };

            // Cargar productos en el ComboBox
            cmbProductos.Items.AddRange(productos.Keys.ToArray());

            // Configurar txtPrecio como deshabilitado
            txtPrecio.Enabled = false;

            // Inicializar la lista
            listaProductos = new List<Tuple<string, string, int, decimal, decimal>>();
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem != null)
            {
                string productoSeleccionado = cmbProductos.SelectedItem.ToString();
                txtPrecio.Text = productos[productoSeleccionado].ToString("C");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || cmbProductos.SelectedIndex == -1 || string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar cantidad
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombre.Text;
            string producto = cmbProductos.SelectedItem.ToString();
            decimal precio = productos[producto];
            decimal total = cantidad * precio;

            // Agregar a la lista y al ListBox
            listaProductos.Add(new Tuple<string, string, int, decimal, decimal>(nombre, producto, cantidad, precio, total));
            listBoxLista.Items.Add($"{nombre} - {producto} - Cantidad: {cantidad} - Precio: {precio:C} - Total: {total:C}");
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (listaProductos.Count < 2)
            {
                MessageBox.Show("No hay suficientes productos para ordenar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OrdenarConShellSort();
        }

        private async void OrdenarConShellSort()
        {
            int n = listaProductos.Count;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    var temp = listaProductos[i];
                    int j = i;

                    while (j >= gap && listaProductos[j - gap].Item5 > temp.Item5) // Ordenar por el Total
                    {
                        listaProductos[j] = listaProductos[j - gap];
                        j -= gap;

                        // Actualizar ListBox durante el proceso
                        ActualizarListBox();
                        await Task.Delay(500);
                    }

                    listaProductos[j] = temp;

                    // Actualizar ListBox
                    ActualizarListBox();
                    await Task.Delay(500);
                }
                gap /= 2;
            }

            MessageBox.Show("Ordenamiento completado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarListBox()
        {
            listBoxLista.Items.Clear();
            foreach (var item in listaProductos)
            {
                listBoxLista.Items.Add($"{item.Item1} - {item.Item2} - Cantidad: {item.Item3} - Precio: {item.Item4:C} - Total: {item.Item5:C}");
            }
        }
    }
}
