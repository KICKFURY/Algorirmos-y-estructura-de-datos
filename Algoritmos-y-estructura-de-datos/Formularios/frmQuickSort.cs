using Algoritmos_y_estructura_de_datos.Algoritmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Algoritmos_y_estructura_de_datos.Formularios
{
    public partial class frmQuickSort : Form
    {
        private List<Producto> productos;
        private QuickSort quickSort;
        private Timer timer;

        public frmQuickSort()
        {
            InitializeComponent();
            CargarProductos();
            quickSort = new QuickSort(productos.ToArray(), MostrarProductos);
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;

            txtId.Text = (productos.Count + 1).ToString();
        }

        private void CargarProductos()
        {
            productos = new List<Producto>
            {
                new Producto(1, "Cuajada", 45),
                new Producto(2, "Crema", 25),
                new Producto(3, "Leche", 40),
                new Producto(4, "Queso Crema", 55),
                new Producto(5, "Yogurt", 20),
                new Producto(6, "Cuajada Picante", 30),
                new Producto(7, "Leche Agria", 15),
                new Producto(8, "Cuajada Seca", 3.50m)
            };
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(MostrarProductos));
            }
            else
            {
                listBoxProductos.Items.Clear();
                foreach (var producto in productos)
                {
                    listBoxProductos.Items.Add(producto.ToString());
                }
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            quickSort = new QuickSort(productos.ToArray(), ActualizarProductos);
            quickSort.IniciarQuickSort();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!quickSort.Paso())
            {
                timer.Stop();
                Console.WriteLine("QuickSort terminado");
            }
            else
            {
                Console.WriteLine("Paso ejecutado callStack size: " + quickSort.GetCallStackSize());
            }
        }

        private void ActualizarProductos()
        {
            productos = quickSort.GetProductos().ToList();
            MostrarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id) && decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                var nombre = txtNombreProducto.Text;
                var nuevoProducto = new Producto(id, nombre, precio);

                productos.Add(nuevoProducto);
                MostrarProductos();

                txtId.Text = (productos.Count + 1).ToString();
                txtNombreProducto.Clear();
                txtPrecio.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese valores validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
