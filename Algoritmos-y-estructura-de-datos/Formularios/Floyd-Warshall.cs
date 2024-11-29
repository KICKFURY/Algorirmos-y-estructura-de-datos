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
    public partial class Floyd_Warshall : Form
    {
        private List<Vertice> vertices = new List<Vertice>();
        private List<Arista> aristas = new List<Arista>();
        private int idCounter = 1; // Contador para IDs de los vértices

        public Floyd_Warshall()
        {
            InitializeComponent();

        }

        // Clase para el vértice
        private class Vertice
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public Point Posicion { get; set; }
        }

        // Clase para la arista
        private class Arista
        {
            public int VerticeAId { get; set; }
            public int VerticeBId { get; set; }
            public int Distancia { get; set; }
        }

    private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombreProveedor = txtProveedor.Text;

            if (string.IsNullOrWhiteSpace(nombreProveedor))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el proveedor.");
                return;
            }

            // Generar una posición aleatoria dentro del panel
            Random random = new Random();
            var nuevoVertice = new Vertice
            {
                Id = idCounter,
                Nombre = nombreProveedor,
                Posicion = new Point(random.Next(50, panelGrafo.Width - 50), random.Next(50, panelGrafo.Height - 50))
            };

            vertices.Add(nuevoVertice);
            idCounter++;

            txtId.Text = idCounter.ToString();

            // Redibujar el panel
            panelGrafo.Invalidate();

            // Limpiar el campo de texto
            txtProveedor.Clear();
        }

        private void btnAgregarDistancia_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdVerticeA.Text, out int verticeAId) && int.TryParse(txtIdVerticeB.Text, out int verticeBId) && int.TryParse(txtDistancia.Text, out int distancia))
            {
                // Buscar los vértices por ID
                var verticeA = vertices.FirstOrDefault(v => v.Id == verticeAId);
                var verticeB = vertices.FirstOrDefault(v => v.Id == verticeBId);

                if (verticeA != null && verticeB != null)
                {
                    // Crear la arista entre los vértices A y B
                    var nuevaArista = new Arista
                    {
                        VerticeAId = verticeAId,
                        VerticeBId = verticeBId,
                        Distancia = distancia
                    };

                    aristas.Add(nuevaArista);

                    // Redibujar el panel de grafo
                    panelGrafo.Invalidate();
                }
                else
                {
                    MessageBox.Show("Uno o ambos vértices no existen.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores válidos para los vértices y la distancia.");
            }

            // Limpiar los campos de texto
            txtIdVerticeA.Clear();
            txtIdVerticeB.Clear();
            txtDistancia.Clear();

        }

        private void btnEditarDistancia_Click(object sender, EventArgs e)
        {
            // Validar los campos
            if (string.IsNullOrWhiteSpace(txtIdVerticeA.Text) ||
            string.IsNullOrWhiteSpace(txtIdVerticeB.Text) ||
            string.IsNullOrWhiteSpace(txtDistancia.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos para editar una distancia.");
                return;
            }

            if (!int.TryParse(txtDistancia.Text, out int nuevaDistancia) || nuevaDistancia <= 0)
            {
                MessageBox.Show("La distancia debe ser un número entero positivo.");
                return;
            }

            // Buscar por ID
            var verticeA = vertices.FirstOrDefault(v => v.Id == int.Parse(txtIdVerticeA.Text));
            var verticeB = vertices.FirstOrDefault(v => v.Id == int.Parse(txtIdVerticeB.Text));

            if (verticeA == null || verticeB == null)
            {
                MessageBox.Show("Uno o ambos vértices especificados no existen.");
                return;
            }

            // Buscar la arista existente
            var arista = aristas.FirstOrDefault(a =>
                (a.VerticeAId == verticeA.Id && a.VerticeBId == verticeB.Id) ||
                (a.VerticeAId == verticeB.Id && a.VerticeBId == verticeA.Id));

            if (arista == null)
            {
                MessageBox.Show("No existe una conexión entre los vértices especificados.");
                return;
            }

            // Actualizar la distancia
            arista.Distancia = nuevaDistancia;

            // Redibujar el grafo
            panelGrafo.Invalidate();

            // Limpiar los campos
            txtIdVerticeA.Clear();
            txtIdVerticeB.Clear();
            txtDistancia.Clear();

            MessageBox.Show("Distancia editada correctamente.");

        }

        private void btnEliminarDistancia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdVerticeA.Text) ||
        string.IsNullOrWhiteSpace(txtIdVerticeB.Text))
            {
                MessageBox.Show("Por favor, complete los campos de los vértices para eliminar una distancia.");
                return;
            }

            // Buscar vértices
            var verticeA = vertices.FirstOrDefault(v => v.Id == int.Parse(txtIdVerticeA.Text));
            var verticeB = vertices.FirstOrDefault(v => v.Id == int.Parse(txtIdVerticeB.Text));

            if (verticeA == null || verticeB == null)
            {
                MessageBox.Show("Uno o ambos vértices no existen.");
                return;
            }

            // Buscar la arista existente
            var arista = aristas.FirstOrDefault(a =>
                (a.VerticeAId == verticeA.Id && a.VerticeBId == verticeB.Id) ||
                (a.VerticeAId == verticeB.Id && a.VerticeBId == verticeA.Id));

            if (arista == null)
            {
                MessageBox.Show("No existe una conexión entre los vértices especificados.");
                return;
            }

            // Eliminar la arista
            aristas.Remove(arista);

            // Redibujar el grafo
            panelGrafo.Invalidate();

            // Limpiar los campos
            txtIdVerticeA.Clear();
            txtIdVerticeB.Clear();

            MessageBox.Show("Distancia eliminada correctamente.");

        }


        private void btnFLOYD_Click(object sender, EventArgs e)
        {
            int n = vertices.Count;

            if (n == 0)
            {
                MessageBox.Show("No hay vértices en el grafo.");
                return;
            }

            // Crear matriz de adyacencia inicial
            int[,] dist = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        dist[i, j] = 0; // Distancia a sí mismo es 0
                    else
                        dist[i, j] = int.MaxValue / 2; // Infinito
                }
            }

            foreach (var arista in aristas)
            {
                var origen = vertices.FindIndex(v => v.Id == arista.VerticeAId);
                var destino = vertices.FindIndex(v => v.Id == arista.VerticeBId);

                if (origen != -1 && destino != -1)
                {
                    dist[origen, destino] = arista.Distancia;
                    dist[destino, origen] = arista.Distancia; // Grafo no dirigido
                }
            }

            // Aplicar Floyd-Warshall
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            // Mostrar resultados en un cuadro de diálogo o DataGridView
            var resultado = "Matriz de distancias mínimas:\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultado += (dist[i, j] == int.MaxValue / 2 ? "∞" : dist[i, j].ToString()) + "\t";
                }
                resultado += "\n";
            }

            MessageBox.Show(resultado, "Floyd-Warshall Resultados");
        }

        private void panelGrafo_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            // Dibujar las aristas
            foreach (var arista in aristas)
            {
                var verticeA = vertices.Find(v => v.Id == arista.VerticeAId);
                var verticeB = vertices.Find(v => v.Id == arista.VerticeBId);

                if (verticeA != null && verticeB != null)
                {
                    graphics.DrawLine(Pens.Black, verticeA.Posicion, verticeB.Posicion);
                    // Dibujar la distancia en el centro de la línea
                    var midPoint = new Point(
                        (verticeA.Posicion.X + verticeB.Posicion.X) / 2,
                        (verticeA.Posicion.Y + verticeB.Posicion.Y) / 2
                    );
                    graphics.DrawString(arista.Distancia.ToString(), DefaultFont, Brushes.Red, midPoint);
                }
            }

            // Dibujar los vértices
            foreach (var vertice in vertices)
            {
                // Dibujar el círculo
                graphics.FillEllipse(Brushes.LightBlue, vertice.Posicion.X - 15, vertice.Posicion.Y - 15, 30, 30);
                graphics.DrawEllipse(Pens.Black, vertice.Posicion.X - 15, vertice.Posicion.Y - 15, 30, 30);

                // Dibujar el ID y el nombre
                graphics.DrawString(vertice.Id.ToString(), DefaultFont, Brushes.Black, vertice.Posicion.X - 5, vertice.Posicion.Y - 5);
                graphics.DrawString(vertice.Nombre, DefaultFont, Brushes.Black, vertice.Posicion.X - 20, vertice.Posicion.Y + 20);
            }
        }

    }
   
}
