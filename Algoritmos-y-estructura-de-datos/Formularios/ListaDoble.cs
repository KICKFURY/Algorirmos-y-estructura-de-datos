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
    public partial class ListaDoble : Form
    {
        public class ProductoNodo
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public double Precio { get; set; }
            public ProductoNodo Siguiente { get; set; }
            public ProductoNodo Anterior { get; set; }
        }

        private ProductoNodo inicio = null;
        private ProductoNodo fin = null;
        private int numeroFactura = 1;
        private int espaciosDisponibles = 0;

        public ListaDoble()
        {
            InitializeComponent();
            txtNoFactura.Text = numeroFactura.ToString();
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            if (espaciosDisponibles <= 0)
            {
                MessageBox.Show("No hay espacios disponibles");
                return;
            }

            if (String.IsNullOrEmpty(txtProducto.Text) || String.IsNullOrEmpty(txtPrecio.Text) || !double.TryParse(txtPrecio.Text, out double precio))
            {
                MessageBox.Show("Ingrese un producto y un precio validos");
                return;
            }

            ProductoNodo nuevoProducto = new ProductoNodo
            {
                Nombre = txtProducto.Text,
                Cantidad = 1,
                Precio = precio,
            };

            nuevoProducto.Siguiente = inicio;

            if (inicio != null)
            {
                inicio.Anterior = nuevoProducto;
            }

            inicio = nuevoProducto;

            if (fin == null)
            {
                fin = nuevoProducto;
            }

            if (dgvFactura.Rows.Count > 0 && espaciosDisponibles < dgvFactura.Rows.Count)
            {
                for (int i = dgvFactura.Rows.Count - 1; i > 0; i--)
                {
                    dgvFactura.Rows[i].Cells[0].Value = dgvFactura.Rows[i - 1].Cells[0].Value;
                    dgvFactura.Rows[i].Cells[1].Value = dgvFactura.Rows[i - 1].Cells[1].Value;
                    dgvFactura.Rows[i].Cells[2].Value = dgvFactura.Rows[i - 1].Cells[2].Value;
                }
            }

            InsertarEnTabla(0, nuevoProducto);
            espaciosDisponibles--;
            ActualizarTotal();
            LimpiarCampos();
        }

        private void InsertarEnTabla(int rowIndex, ProductoNodo producto)
        {
            if (dgvFactura.Rows.Count <= rowIndex)
            {
                dgvFactura.Rows.Add();
            }

            dgvFactura.Rows[rowIndex].Cells[0].Value = producto.Nombre;
            dgvFactura.Rows[rowIndex].Cells[1].Value = producto.Cantidad;
            dgvFactura.Rows[rowIndex].Cells[2].Value = producto.Precio.ToString("F2");

        }

        private void LimpiarCampos()
        {
            txtProducto.Clear();
            txtPrecio.Clear();
            txtProducto.Focus();
        }

        private void ActualizarTotal()
        {
            double total = 0;
            ProductoNodo actual = inicio;
            while (actual != null)
            {
                total += actual.Precio;
                actual = actual.Siguiente;
            }
            txtTotal.Text = "C$ " + total.ToString("F2");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCantidad.Text, out espaciosDisponibles) && espaciosDisponibles > 0)
            {
                dgvFactura.Rows.Clear();
                for (int i = 0; i < espaciosDisponibles; i++)
                {
                    dgvFactura.Rows.Add();
                }
                txtCantidad.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Por favor ingrese una cantidad valida mayor a 0.");
            }
        }

        private void Facturar_Click(object sender, EventArgs e)
        {
            if (fin == null)
            {
                MessageBox.Show("No hay productos en la tabla para facturar");
                return;
            }

            ProductoNodo nodoEliminar = fin;
            fin = fin.Anterior;

            if (fin != null)
            {
                fin.Siguiente = null;
            }
            else
            {
                inicio = null;
            }

            for (int i = dgvFactura.Rows.Count - 1; i >= 0; i--)
            {
                if (dgvFactura.Rows[i].Cells[0].Value != null)
                {
                    dgvFactura.Rows[i].Cells[0].Value = null;
                    dgvFactura.Rows[i].Cells[1].Value = null;
                    dgvFactura.Rows[i].Cells[2].Value = null;
                    break;
                }
            }

            ActualizarTotal();
            MessageBox.Show("Producto facturado");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            numeroFactura++;
            txtNoFactura.Text = numeroFactura.ToString();

            txtProducto.Clear();
            txtPrecio.Clear();
            txtTotal.Clear();
            txtCantidad.Clear();
            txtCantidad.ReadOnly = false;

            dgvFactura.Rows.Clear();

            inicio = null;
            fin = null;
            espaciosDisponibles = 0;

            txtCantidad.Focus();
            MessageBox.Show("Nueva factura creada");
        }
    }
}
