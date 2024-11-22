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
    public partial class SelectionSort : Form
    {
        private Dictionary<string, decimal> productos;
        private List<Tuple<string, string, int, decimal, decimal>> listaProductos; // Nombre, Producto, Cantidad, Precio, Total

        public SelectionSort()
        {
            InitializeComponent();
            ConfigurarProductos();
        }

        private void ConfigurarProductos()
        {
            // Inicializar productos y precios
            productos = new Dictionary<string, decimal>
            {
                { "Ram DDR4", 25m },
                { "Disco Duro", 40m },
                { "Auriculares", 15m },
                { "Cámara", 120m },
                { "Teclado", 12m },
                { "Monitor", 170m },
                { "Mouse", 50m },
                { "Impresora", 100m },
                { "Router", 50m },
                { "Memoria USB", 10m },
                { "Altavoces", 80m },
                { "Cargador", 30m }
            };

            // Cargar productos en el ComboBox
            cmbProductos.Items.AddRange(productos.Keys.ToArray());

            // Configurar txtPrecio como deshabilitado
            txtPrecio.Enabled = false;

            // Inicializar la lista
            listaProductos = new List<Tuple<string, string, int, decimal, decimal>>();
        }

        private void cmbProductos_SelectedIndexChanged_1(object sender, EventArgs e)
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

            OrdenarPorTotal();
        }

        private async void OrdenarPorTotal()
        {
            for (int i = 0; i < listaProductos.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < listaProductos.Count; j++)
                {
                    if (listaProductos[j].Item5 < listaProductos[minIndex].Item5) // Comparar totales
                    {
                        minIndex = j;
                    }
                }

                // Intercambiar elementos
                if (minIndex != i)
                {
                    var temp = listaProductos[i];
                    listaProductos[i] = listaProductos[minIndex];
                    listaProductos[minIndex] = temp;

                    // Actualizar el ListBox
                    ActualizarListBox();

                    // Pausar para observar el ordenamiento
                    await Task.Delay(1000);
                }
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

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (listaProductos.Count == 0)
            {
                MessageBox.Show("No hay productos agregados para calcular", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal sumaTotal = listaProductos.Sum(p => p.Item5);
            MessageBox.Show($"El total de todos los productos es: {sumaTotal:C}", "Total", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
