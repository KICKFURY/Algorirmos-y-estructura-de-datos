using Algoritmos_y_estructura_de_datos.Algoritmos;
using Algoritmos_y_estructura_de_datos.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmos_y_estructura_de_datos.Formularios
{
    public partial class frmArbolBinario : Form
    {
        private ArbolBinario arbol;

        public frmArbolBinario()
        {
            InitializeComponent();
            arbol = new ArbolBinario();
            txtId.Text = "1";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreProducto.Text) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Todos los campos son requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtPrecio.Text, out int precio))
            {
                int id = int.Parse(txtId.Text);
                string nombre = txtNombreProducto.Text;

                Producto producto = new Producto(id, nombre, precio);
                arbol.Insertar(producto);

                txtId.Text = (id + 1).ToString();
                txtNombreProducto.Clear();
                txtPrecio.Clear();

                MessageBox.Show("Producto agregado correctamente");

                panelArbol.Invalidate();
            }
            else
            {
                MessageBox.Show("Ingrese valores validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void panelArbol_Paint(object sender, PaintEventArgs e)
        {
            if (arbol.Raiz != null)
            {
                DibujarNodo(e.Graphics, arbol.Raiz, panelArbol.Width / 2, 20, panelArbol.Width / 4);
            }
        }

        private void DibujarNodo(Graphics graphics, Nodo nodo, int x, int y, int distancia)
        {
            if (nodo != null)
            {
                string texto = nodo.Data.ToString(); 
                SizeF tamañoTexto = graphics.MeasureString(texto, this.Font);
                RectangleF rectangulo = new RectangleF(x - tamañoTexto.Width / 2, y, tamañoTexto.Width, tamañoTexto.Height);
                graphics.FillRectangle(Brushes.White, rectangulo);
                graphics.DrawRectangle(Pens.Black, x - tamañoTexto.Width / 2, y, tamañoTexto.Width, tamañoTexto.Height);
                graphics.DrawString(texto, this.Font, Brushes.Black, rectangulo);

                if (nodo.Izquierda != null) 
                { 
                    graphics.DrawLine(Pens.Black, x, y + tamañoTexto.Height / 2, x - distancia, y + 50); 
                    DibujarNodo(graphics, nodo.Izquierda, x - distancia, y + 50, distancia / 2); 
                }

                if (nodo.Derecho != null) 
                {
                    graphics.DrawLine(Pens.Black, x, y + tamañoTexto.Height / 2, x + distancia, y + 50);
                    DibujarNodo(graphics, nodo.Derecho, x + distancia, y + 50, distancia / 2);
                }
            }
        }
    }
}
