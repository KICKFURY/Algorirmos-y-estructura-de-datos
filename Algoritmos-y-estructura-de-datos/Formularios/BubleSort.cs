using Algoritmos_y_estructura_de_datos.Algoritmos;
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

    public partial class BubleSort : Form
    {
        private Dictionary<string, decimal> productos;
        private List<Tuple<string, string, decimal>> listaProductos; // Lista con los datos

        public BubleSort()
        {
            InitializeComponent();
            ConfigurarProductos();
        }

        private void ConfigurarProductos()
        {
            //diccionario con productos y sus precios
            productos = new Dictionary<string, decimal>
            {
                { "Laptop", 1200m },
                { "Smartphone", 800m },
                { "Tablet", 500m },
                { "Auriculares", 150m },
                { "Smartwatch", 300m },
                { "Cámara", 1000m },
                { "Teclado", 100m },
                { "Monitor", 400m },
                { "Mouse", 50m },
                { "Impresora", 250m },
                { "Disco Duro", 100m },
                { "Router", 80m },
                { "Memoria USB", 20m },
                { "Altavoces", 120m },
                { "Cargador", 30m }
            };

            //productos al ComboBox
            cmbProductos.Items.AddRange(productos.Keys.ToArray());

            //TextBox de precio como deshabilitado
            txtPrecio.Enabled = false;

            // Inicializar la lista de productos
            listaProductos = new List<Tuple<string, string, decimal>>();
        }

        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || cmbProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombre.Text;
            string producto = cmbProductos.SelectedItem.ToString();
            decimal precio = productos[producto];

            // Agregar los productos al ListBox
            listaProductos.Add(new Tuple<string, string, decimal>(nombre, producto, precio));
            listBoxLista.Items.Add($"{nombre} - {producto} - {precio}");

            LimpiarCampos();
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbProductos.SelectedItem != null)
            {
                string productoSeleccionado = cmbProductos.SelectedItem.ToString();
                txtPrecio.Text = productos[productoSeleccionado].ToString("C");
            }

        }

        private async void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (listaProductos.Count < 2)
            {
                MessageBox.Show("No hay suficientes productos para ordenar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Bubble Sort con un retraso de 5 segundos para ver el ordenamiento
            for (int i = 0; i < listaProductos.Count - 1; i++)
            {
                for (int j = 0; j < listaProductos.Count - i - 1; j++)
                {
                    if (listaProductos[j].Item3 > listaProductos[j + 1].Item3) // Compara el precio
                    {
                        // Intercambiar los elementos
                        var temp = listaProductos[j];
                        listaProductos[j] = listaProductos[j + 1];
                        listaProductos[j + 1] = temp;
                        
                        // Actualizar el ListBox para mostrar el progreso
                        ActualizarListBox();

                        //observar el proceso
                        await Task.Delay(1000);
                    }
                }
            }

            MessageBox.Show("Ordenamiento completado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarListBox()
        {
            listBoxLista.Items.Clear();
            foreach (var item in listaProductos)
            {
                listBoxLista.Items.Add($"{item.Item1} - {item.Item2} - {item.Item3}"); //nombre, producto y precio
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);//La tecla esc permite volver
                                                        //al menu principal

        }

       
    }

}
