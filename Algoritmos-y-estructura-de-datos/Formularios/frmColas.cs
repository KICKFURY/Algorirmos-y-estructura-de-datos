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

    public struct Inventario
    {
        public string nombreProducto { get; set; }
        public string nombreCliente { get; set; }
        public int cantidadProducto { get; set; }
        public double precioProducto { get; set; }
    }

    public partial class frmColas : Form
    {
        private Queue<Inventario> pedidos;

        public frmColas()
        {
            InitializeComponent();
            pedidos = new Queue<Inventario>();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProducto.Text) && !string.IsNullOrEmpty(txtCliente.Text) &&
                int.TryParse(txtCantidad.Text, out int cantidad) && double.TryParse(txtPrecio.Text, out double precio))
            {
                Inventario nuevoPedido = new Inventario
                {
                    nombreProducto = txtProducto.Text,
                    nombreCliente = txtCliente.Text,
                    cantidadProducto = cantidad,
                    precioProducto = precio
                };

                pedidos.Enqueue(nuevoPedido);
                ActualizarLista();
                txtProducto.Clear();
                txtCliente.Clear();
                txtCantidad.Clear();
                txtPrecio.Clear();
                MessageBox.Show("Producto agregado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (pedidos.Count == 0)
            {
                MessageBox.Show("No hay productos para facturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }        
                
            Inventario producto = pedidos.Dequeue();
            MessageBox.Show($"Facturada a {producto.nombreCliente}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            listBoxInventario.Items.Clear();
            listBoxInventario.Items.AddRange(pedidos.Select(pedido =>
        $"{pedido.nombreProducto} - {pedido.nombreCliente} - {pedido.cantidadProducto} unidades - ${pedido.precioProducto} - Subtotal ${pedido.precioProducto * pedido.cantidadProducto}").ToArray());
        }
    }
}