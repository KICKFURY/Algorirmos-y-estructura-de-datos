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
    public partial class HeapSort : Form
    {
        public int tope = 0; 
        public bool cantidadEstablecida = false;
        private int elementos = 0;
        public HeapSort()
        {
            InitializeComponent();
            txtNoFactura.ReadOnly = true;
            txtNoFactura.Text = numeroFactura.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cantidadEstablecida)
            {
                MessageBox.Show("Ya se ha especificado una cantidad");
                txtCantidad.Text = tope.ToString();
                return;
            }

            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out tope) || tope <= 0)
            {
                error.SetError(txtCantidad, "Ingresa un número mayor que 0");
                return;
            }
            error.SetError(txtCantidad, "");

            cantidadEstablecida = true;
            txtCantidad.ReadOnly = true;

            for (int i = 0; i < tope; i++)
            {
                dgvFactura.Rows.Add();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (elementos >= tope)
            {
                MessageBox.Show("La tabla esta llena");
                return;
            }

            if (string.IsNullOrEmpty(txtProducto.Text))
            {
                error.SetError(txtProducto, "El campo esta vacio");
                return;
            }

            if (!double.TryParse(txtPrecio.Text, out double precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio valido");
                return;
            }
            error.SetError(txtProducto, "");

            dgvFactura.Rows[elementos].Cells[0].Value = txtProducto.Text;
            dgvFactura.Rows[elementos].Cells[1].Value = txtCantidad.Text;
            dgvFactura.Rows[elementos].Cells[2].Value = precio.ToString("F2");
            elementos++;

            OrdenarConHeapsort();
            ActualizarTotal();

            txtProducto.Clear();
            txtPrecio.Clear();
            txtProducto.Focus();
        }

        private void OrdenarConHeapsort()
        {
            List<double> precios = new List<double>();

            for (int i = 0; i < elementos; i++)
            {
                if (dgvFactura.Rows[i].Cells[2].Value != null &&
                    double.TryParse(dgvFactura.Rows[i].Cells[2].Value.ToString(), out double precio))
                {
                    precios.Add(precio);
                }
            }

            double[] preciosArray = precios.ToArray();

            // Aplicar Heapsort
            Heapsort(preciosArray);

            for (int i = 0; i < preciosArray.Length; i++)
            {
                dgvFactura.Rows[i].Cells[2].Value = preciosArray[i].ToString("F2");
            }
        }

        private void Heapsort(double[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            for (int i = n - 1; i > 0; i--)
            {
                double temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);
            }
        }

        private void Heapify(double[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1; 
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                double swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, n, largest);
            }
        }

        private void ActualizarTotal()
        {
            double total = 0;

            foreach (DataGridViewRow row in dgvFactura.Rows)
            {
                if (row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double precio))
                {
                    total += precio;
                }
            }

            txtTotal.Text = "C$ " + total.ToString("F2");
        }

        private void Facturar_Click(object sender, EventArgs e)
        {
            if (elementos == 0)
            {
                MessageBox.Show("No hay elementos en la lista para facturar");
                return;
            }

            elementos--;
            dgvFactura.Rows[elementos].Cells[0].Value = null;
            dgvFactura.Rows[elementos].Cells[1].Value = null;
            dgvFactura.Rows[elementos].Cells[2].Value = null;

            OrdenarConHeapsort();
            ActualizarTotal();

            MessageBox.Show("Producto facturado exitosamente");
        }

        private int numeroFactura = 1;
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("No se puede crear una nueva factura sin realizar compras");
                return;
            }

            numeroFactura++;
            txtNoFactura.Text = numeroFactura.ToString();

            txtProducto.Clear();
            txtPrecio.Clear();
            txtTotal.Clear();
            txtCantidad.Clear();
            txtCantidad.ReadOnly = false;

            dgvFactura.Rows.Clear();

            elementos = 0;
            cantidadEstablecida = false;
            tope = 0;

            txtCantidad.Focus();

            MessageBox.Show("Nueva factura creada");
        }
    }
}
