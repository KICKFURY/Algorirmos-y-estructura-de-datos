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
    public partial class frmColas : Form
    {
        private Queue<string> pedidos;

        public frmColas()
        {
            InitializeComponent();
            pedidos = new Queue<string>();
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
            if (!string.IsNullOrEmpty(txtProducto.Text))
                pedidos.Enqueue(txtProducto.Text);
                ActualizarLista();
                txtProducto.Clear();
                MessageBox.Show("Producto agregado exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (pedidos.Count == 0)
            {
                MessageBox.Show("No hay productos para facturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }        
                
            string producto = pedidos.Dequeue();
            MessageBox.Show($"Facturado {producto}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            listBoxInventario.Items.Clear();
            listBoxInventario.Items.AddRange(pedidos.ToArray());
        }
    }
}