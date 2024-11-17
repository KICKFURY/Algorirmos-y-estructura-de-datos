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
    public partial class ListaSimple : Form
    {
        private class Nodo
        {
            public int NumeroFactura { get; set; }
            public string Cliente { get; set; }
            public decimal Total { get; set; }
            public DateTime Fecha { get; set; }
            public string Estado { get; set; }
            public string Producto { get; set; }
            public decimal Precio { get; set; }
            public Nodo Siguiente { get; set; }

            public Nodo(int numeroFactura, string cliente, string producto, decimal precio, DateTime fecha)
            {
                NumeroFactura = numeroFactura;
                Cliente = cliente;
                Producto = producto;
                Precio = precio;
                Total = precio;
                Fecha = fecha;
                Estado = "Pendiente";
                Siguiente = null;
            }
        }

        private Nodo primero;
        private int consecutivo = 1;
        private Dictionary<string, decimal> preciosProductos;

        public ListaSimple()
        {
            InitializeComponent();
            primero = null;
            ConfigurarInicial();
        }

        private void ConfigurarInicial()
        {
            // Configurar precios de productos
            preciosProductos = new Dictionary<string, decimal>
            {
                { "Celular", 599m },
                { "Camara", 299m },
                { "Televisor", 799m },
                { "Bocinas", 149m }
            };

            //productos del combobox
            cmbProductos.Items.AddRange(new string[] { "Celular", "Camara", "Televisor", "Bocinas" });

            // Elementos datagrid
            dgFacturas.Columns.Add("Numero", "Numero");
            dgFacturas.Columns.Add("Cliente", "Cliente");
            dgFacturas.Columns.Add("Total", "Total");
            dgFacturas.Columns.Add("Fecha", "Fecha");
            dgFacturas.Columns.Add("Estado", "Estado");

            //numero de factura inicial
            txtNumeroFactura.Text = consecutivo.ToString();
            txtNumeroFactura.Enabled = false;
            txtPrecio.Enabled = false;

            // Asegurarnos de que el botón de eliminar esté habilitado
            if (btnEliminar != null)
            {
                btnEliminar.Enabled = true;  // Habilitamos el botón Eliminar
            }
        }

        // Método para insertar al final de la lista
        private void InsertarFinal(int numeroFactura, string cliente, string producto, decimal precio, DateTime fecha)
        {
            Nodo nuevo = new Nodo(numeroFactura, cliente, producto, precio, fecha);

            if (primero == null)
            {
                primero = nuevo;
                return;
            }

            Nodo actual = primero;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }


        private void EliminarPrimero()
        {
            if (primero == null)
            {
                MessageBox.Show("No hay facturas para eliminar", "Informacion",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Guardamos la información de la factura que vamos a eliminar
            int numeroFacturaEliminada = primero.NumeroFactura;

            // Eliminamos la primera factura (FIFO)
            primero = primero.Siguiente;

            //mensaje que se ha eliminado la factura
            MessageBox.Show($"Se ha eliminado la factura #{numeroFacturaEliminada}", "Eliminacion exitosa",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Actualizamos el datagrid después de la eliminación
            ActualizarDataGridView();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (primero == null)
            {
                MessageBox.Show("No hay facturas para eliminar", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Preguntamos si está seguro de eliminar la primera factura
            DialogResult respuesta = MessageBox.Show(
                $"¿Esta seguro que desea eliminar la factura #{primero.NumeroFactura}?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                EliminarPrimero(); // Llamar al método para eliminar la primera factura
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCliente.Text) || cmbProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor complete todos los campos", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cliente = txtCliente.Text;
            string producto = cmbProductos.SelectedItem.ToString();
            decimal precio = decimal.Parse(txtPrecio.Text);
            DateTime fecha = dateTimePicker1.Value;

            InsertarFinal(consecutivo, cliente, producto, precio, fecha);

            ActualizarDataGridView();
            LimpiarCampos();
            consecutivo++;
            txtNumeroFactura.Text = consecutivo.ToString();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (primero == null)
            {
                MessageBox.Show("No hay facturas para procesar", "Informacion",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Nodo actual = primero;
            while (actual != null)
            {
                actual.Estado = "Procesado";
                actual = actual.Siguiente;
            }

            ActualizarDataGridView();
        }


        private void ActualizarDataGridView()
        {
            dgFacturas.Rows.Clear(); // Limpiar las filas

            Nodo actual = primero;
            while (actual != null)
            {
                // Añado una nueva fila para la factura
                dgFacturas.Rows.Add(
                    actual.NumeroFactura,
                    actual.Cliente,
                    actual.Total.ToString("C"),  //moneda
                    actual.Fecha.ToShortDateString(),
                    actual.Estado
                );
                actual = actual.Siguiente; // siguiente nodo
            }
        }

        private void LimpiarCampos()
        {
            txtCliente.Clear();
            cmbProductos.SelectedIndex = -1;
            txtPrecio.Clear();
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem != null)
            {
                string productoSeleccionado = cmbProductos.SelectedItem.ToString();
                txtPrecio.Text = preciosProductos[productoSeleccionado].ToString("0");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
    }
}