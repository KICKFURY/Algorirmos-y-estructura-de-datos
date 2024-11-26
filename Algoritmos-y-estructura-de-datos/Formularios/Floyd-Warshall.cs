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
    public partial class Floyd_Warshall : Form
    {
        private List<FacturaItem> facturaItems = new List<FacturaItem>();

        public Floyd_Warshall()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Floyd_Warshall_Load);

        }

        public class FacturaItem
        {
            public string Producto { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
            public decimal Total => Cantidad * Precio;
        }

        public class Producto
        {
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
        }

        private void Floyd_Warshall_Load(object sender, EventArgs e)
{
    //  productos
    var productos = new List<Producto>
    {
        new Producto { Nombre = "Producto A", Precio = 10.00m },
        new Producto { Nombre = "Producto B", Precio = 20.00m },
        new Producto { Nombre = "Producto C", Precio = 15.50m }
    };

    // datos al ComboBox
    cmbProducto.DataSource = productos;
    cmbProducto.DisplayMember = "Nombre";
    cmbProducto.ValueMember = "Precio";

    //Verificar si los datos se asignaron correctamente
    if (cmbProducto.Items.Count == 0)
    {
        MessageBox.Show("El ComboBox no cargó productos.");
    }
}


        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem is Producto producto)
            {
                txtPrecio.Text = producto.Precio.ToString("C2");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem != null && nudCantidad.Value > 0)
            {
                var producto = (dynamic)cmbProducto.SelectedItem;
                var item = new FacturaItem
                {
                    Producto = producto.Nombre,
                    Cantidad = (int)nudCantidad.Value,
                    Precio = producto.Precio
                };

                facturaItems.Add(item);
                ActualizarFactura();
            }
            else
            {
                MessageBox.Show("Seleccione un producto y cantidad válida.");
            }
        }

        private void ActualizarFactura()
        {
            dgvFactura.DataSource = null;
            dgvFactura.DataSource = facturaItems;

            // Actualizar total
            lblTotal.Text = "Total: " + facturaItems.Sum(i => i.Total).ToString("C2");
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (facturaItems.Count > 0 && !string.IsNullOrEmpty(txtNombre.Text))
            {
                string nombreCliente = txtNombre.Text;
                decimal totalFactura = facturaItems.Sum(i => i.Total);

                MessageBox.Show($"Factura generada para {nombreCliente}\nTotal: {totalFactura:C2}", "Factura");
                facturaItems.Clear();
                ActualizarFactura();
                txtNombre.Clear();
            }
            else
            {
                MessageBox.Show("Complete todos los datos antes de generar la factura.");
            }
        }
    }

   
}
