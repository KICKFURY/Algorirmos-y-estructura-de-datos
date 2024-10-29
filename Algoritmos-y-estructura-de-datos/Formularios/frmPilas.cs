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
    public partial class frmPilas : Form
    {
        public int tope = 0;
        public int frente = 0;
        public int final = 0;
        public bool cantidadEstablecida = false;
        public frmPilas()
        {
            InitializeComponent();
            txtNoFactura.ReadOnly = true;
            txtNoFactura.Text = numeroFactura.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cantidadEstablecida)
            {
                MessageBox.Show("Ya has especificado una cantidad");
                txtCantidad.Text = tope.ToString(); 
                return;
            }

            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                error.SetError(txtCantidad, "El campo está vacío");
                return;
            }
            error.SetError(txtCantidad, "");

            if (int.TryParse(txtCantidad.Text, out tope) && tope > 0)
            {
                for (int i = 0; i < tope; i++)
                {
                    dgvFactura.Rows.Add();
                }
                cantidadEstablecida = true;
                txtCantidad.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Por favor ingresar un numero mayor que 0");
            }
        }

        private int elementos = 0;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProducto.Text))
            {
                error.SetError(txtProducto, "El campo esta vacio");
                return;
            }
            error.SetError(txtProducto, "");

            if (!double.TryParse(txtPrecio.Text, out double precio))
            {
                MessageBox.Show("El campo solo debe contener numeros");
                return;
            }

            if (elementos == tope)
            {
                MessageBox.Show("La tabla esta llena");
                return;
            }

            dgvFactura.Rows[elementos].Cells[0].Value = txtProducto.Text;
            dgvFactura.Rows[elementos].Cells[1].Value = txtCantidad.Text;
            dgvFactura.Rows[elementos].Cells[2].Value = precio.ToString("F2");

            elementos++;

            double total = 0;
            foreach (DataGridViewRow row in dgvFactura.Rows)
            {
                if (row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double rowPrecio))
                {
                    total += rowPrecio;
                }
            }

            txtTotal.Text = "C$ " + total.ToString("F2");

            txtProducto.Clear();
            txtPrecio.Clear();
            txtProducto.Focus();
        }

        private void Facturar_Click(object sender, EventArgs e)
        {
            if (elementos == 0)
            {
                MessageBox.Show("La tabla está vacía");
                return;
            }

            elementos--;

            if (dgvFactura.Rows[elementos].Cells[2].Value != null &&
                double.TryParse(dgvFactura.Rows[elementos].Cells[2].Value.ToString(), out double precioEliminado))
            {
                dgvFactura.Rows[elementos].Cells[0].Value = null;
                dgvFactura.Rows[elementos].Cells[1].Value = null;
                dgvFactura.Rows[elementos].Cells[2].Value = null;

                double total = 0;
                foreach (DataGridViewRow row in dgvFactura.Rows)
                {
                    if (row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double rowPrecio))
                    {
                        total += rowPrecio;
                    }
                }

                txtTotal.Text = "C$ " + total.ToString("F2");

                MessageBox.Show("Elemento facturado y eliminado de la tabla");
            }
            else
            {
                dgvFactura.Rows[elementos].Cells[0].Value = null;
                dgvFactura.Rows[elementos].Cells[1].Value = null;
                dgvFactura.Rows[elementos].Cells[2].Value = null;

                double total = 0;
                foreach (DataGridViewRow row in dgvFactura.Rows)
                {
                    if (row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double rowPrecio))
                    {
                        total += rowPrecio;
                    }
                }

                txtTotal.Text = "C$ " + total.ToString("F2");

                MessageBox.Show("Elemento eliminado");
            }
        }

        private int numeroFactura = 1;
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("No se puede crear una nueva factura sin realizar compras.");
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
