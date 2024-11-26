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
    public partial class ShakerSort : Form
    {
        public int tope = 0;
        public bool cantidadEstablecida = false;
        private int elementos = 0;
        public ShakerSort()
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (elementos >= tope)
            {
                MessageBox.Show("La tabla está llena");
                return;
            }

            if (string.IsNullOrEmpty(txtProducto.Text))
            {
                error.SetError(txtProducto, "El campo está vacío");
                return;
            }

            if (!double.TryParse(txtPrecio.Text, out double precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido");
                return;
            }
            error.SetError(txtProducto, "");

            dgvFactura.Rows[elementos].Cells[0].Value = txtProducto.Text;
            dgvFactura.Rows[elementos].Cells[1].Value = txtCantidad.Text;
            dgvFactura.Rows[elementos].Cells[2].Value = precio.ToString("F2");
            elementos++;

            OrdenarConShakerSort();
            ActualizarTotal();

            txtProducto.Clear();
            txtPrecio.Clear();
            txtProducto.Focus();
        }

        private void OrdenarConShakerSort()
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

            OrdenarShakerSort(preciosArray);

            for (int i = 0; i < preciosArray.Length; i++)
            {
                dgvFactura.Rows[i].Cells[2].Value = preciosArray[i].ToString("F2");
            }
        }

        private void OrdenarShakerSort(double[] array)
        {
            int left = 0;
            int right = array.Length - 1;
            bool swapped = true;

            while (swapped)
            {
                swapped = false;

                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        double temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped) break;

                swapped = false;
                right--;

                for (int i = right; i > left; i--)
                {
                    if (array[i - 1] > array[i])
                    {
                        double temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        swapped = true;
                    }
                }

                left++;
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

            OrdenarConShakerSort();
            ActualizarTotal();

            MessageBox.Show("Producto facturado exitosamente");
        }
    }
}
