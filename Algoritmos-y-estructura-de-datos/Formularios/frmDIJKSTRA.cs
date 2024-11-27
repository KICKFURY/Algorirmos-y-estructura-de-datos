using Algoritmos_y_estructura_de_datos.Algoritmos;
using Algoritmos_y_estructura_de_datos.Clases;
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
    public partial class frmDIJKSTRA : Form
    {
        private Grafo grafo;
        private Vertice verticeOrigen;

        public frmDIJKSTRA()
        {
            InitializeComponent();
            grafo = new Grafo();
            txtId.Text = 2.ToString();
            CrearLacteos();
        }

        private void CrearLacteos()
        {
            var id = 1;
            var nombre = "Nuestra empresa";

            Proveedores local = new Proveedores(id, nombre);
            grafo.AgregarVertice(local);

            panelGrafo.Invalidate();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nombre = txtNombreProveedor.Text;

                Proveedores proveedor = new Proveedores(id, nombre);
                grafo.AgregarVertice(proveedor);

                txtId.Text = (id + 1).ToString();
                txtNombreProveedor.Clear();
                txtNombreProveedor.Focus();

                panelGrafo.Invalidate();
            } 
            catch (Exception ex) 
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnAgregarArista_Click(object sender, EventArgs e)
        {
            try
            {
                int idOrigen = int.Parse(txtIdVerticeA.Text);
                int idDestino = int.Parse(txtIdVerticeB.Text);
                int distancia = int.Parse(txtDistancia.Text);

                grafo.AgregarArista(idOrigen, idDestino, distancia);

                txtIdVerticeA.Clear();
                txtIdVerticeB.Clear();
                txtDistancia.Clear();
                txtIdVerticeA.Focus();

                panelGrafo.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnEditarDistancia_Click(object sender, EventArgs e)
        {
            try
            {
                int idOrigen = int.Parse(txtIdVerticeA.Text);
                int idDestino = int.Parse(txtIdVerticeB.Text);
                int distancia = int.Parse(txtDistancia.Text);

                grafo.ActualizarDistancia(idOrigen, idDestino, distancia);

                txtIdVerticeA.Clear();
                txtIdVerticeB.Clear();
                txtDistancia.Clear();
                txtIdVerticeA.Focus();

                panelGrafo.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDistancia_Click(object sender, EventArgs e)
        {
            try
            {
                int idOrigen = int.Parse(txtIdVerticeA.Text);
                int idDestino = int.Parse(txtIdVerticeB.Text);

                grafo.EliminarDistancia(idOrigen, idDestino);

                txtIdVerticeA.Clear();
                txtIdVerticeB.Clear();
                txtDistancia.Clear();
                txtIdVerticeA.Focus();

                panelGrafo.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDIJKSTRA_Click(object sender, EventArgs e)
        { 
            try
            {
                int idOrigen = int.Parse(txtIdOrigen.Text);
                int idDestino = int.Parse(txtIdDestino.Text);

                grafo.Dijkstra(idOrigen);
                verticeOrigen = grafo.Vertices.Find(v => v.Data.id == idOrigen);

                var rutaMasCorta = grafo.ObtenerRutaMasCorta(idDestino);

                txtIdDestino.Focus();

                panelGrafo.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelGrafo_Paint(object sender, PaintEventArgs e)
        {
            DibujarGrafo(e.Graphics);
        }

        private void DibujarGrafo(Graphics graphics)
        {
            int radio = 35;
            int centerX = panelGrafo.Width / 2;
            int centerY = panelGrafo.Height / 2;
            int bigRadius = Math.Min(panelGrafo.Width, panelGrafo.Height) / 2 - radio * 2;
            Dictionary<Vertice, Point> posiciones = new Dictionary<Vertice, Point>();

            int n = grafo.Vertices.Count;
            for (int i = 0; i < n; i++)
            {
                double angle = 2 * Math.PI * i / n;
                int x = centerX + (int)(bigRadius * Math.Cos(angle));
                int y = centerY + (int)(bigRadius * Math.Sin(angle));
                posiciones[grafo.Vertices[i]] = new Point(x, y);
            }

            foreach (var vertice in grafo.Vertices)
            {
                foreach (var arista in vertice.Aristas)
                {
                    Point origen = posiciones[vertice];
                    Point destino = posiciones[arista.Destino];
                    graphics.DrawLine(Pens.Black, origen, destino);
                    int midX = (origen.X + destino.X) / 2;
                    int midY = (origen.Y + destino.Y) / 2;
                    graphics.DrawString(arista.Peso.ToString(), this.Font, Brushes.Red, midX, midY);
                }
            }

            foreach (var vertice in grafo.Vertices)
            {
                Point posicion = posiciones[vertice];
                Rectangle rect = new Rectangle(posicion.X - radio, posicion.Y - radio, radio * 2, radio * 2);
                graphics.FillEllipse(Brushes.White, rect);
                graphics.DrawEllipse(Pens.Black, rect);

                string texto = $"{vertice.Data.id}: {vertice.Data.nombre}";
                SizeF tamTexto = graphics.MeasureString(texto, this.Font);
                PointF textoPosicion = new PointF(posicion.X - tamTexto.Width / 2, posicion.Y - tamTexto.Height / 2);
                graphics.DrawString(texto, this.Font, Brushes.Black, textoPosicion);
            }

            if (verticeOrigen != null)
            {
                var ruta = grafo.ObtenerRutaMasCorta(int.Parse(txtIdDestino.Text));
                for (int i = 0; i < ruta.Count - 1; i++)
                {
                    Vertice vInicio = grafo.Vertices.Find(v => v.Data.id == ruta[i].id);
                    Vertice vFin = grafo.Vertices.Find(v => v.Data.id == ruta[i + 1].id);

                    if (vInicio != null && vFin != null)
                    {
                        Point origen = posiciones[vInicio];
                        Point destino = posiciones[vFin];
                        graphics.DrawLine(Pens.Blue, origen, destino);
                    }
                }
            }
        }
    }
}
