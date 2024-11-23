using Algoritmos_y_estructura_de_datos.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Algoritmos_y_estructura_de_datos.Formularios.FormColaCircular;

namespace Algoritmos_y_estructura_de_datos.Formularios
{
    public struct Cliente
    {
        public string NombreCliente { get; set; }
        public double SaldoPendiente { get; set; }
        public string IdFactura { get; set; }
        public int Plazos { get; set; }
        public bool Procesado { get; set; }
    }


    public partial class FormColaCircular : Form
    {

        private Queue<Cliente> colaClientes;
        private int capacidadMaxima;

        public FormColaCircular()

        {
            InitializeComponent();
            colaClientes = new Queue<Cliente>();
            capacidadMaxima = 5; // Define el tamaño máximo de la cola circular
            ConfigurarDataGridView();

            txtIdFactura.Enabled = false; // Txt desabilitado
            txtIdFactura.Text = "1"; //El valor con el que comenzaremos la factura
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewClientes.Columns.Add("NombreCliente", "Nombre del Cliente");
            dataGridViewClientes.Columns.Add("SaldoPendiente", "Saldo Pendiente");
            dataGridViewClientes.Columns.Add("IdFactura", "ID de la Factura");
            dataGridViewClientes.Columns.Add("Plazos", "Plazos");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (colaClientes.Count < capacidadMaxima)
            {
                if (!string.IsNullOrEmpty(txtNombreCliente.Text) &&
                    double.TryParse(txtSaldoPendiente.Text, out double saldoPendiente) &&
                    int.TryParse(txtPlazos.Text, out int plazos) && plazos <= 24) // Límite de plazos a 24
                {
                    Cliente nuevoCliente = new Cliente
                    {
                        NombreCliente = txtNombreCliente.Text,
                        SaldoPendiente = saldoPendiente,
                        Plazos = plazos,
                        IdFactura = txtIdFactura.Text,
                        Procesado = false
                    };

                    colaClientes.Enqueue(nuevoCliente);
                    ActualizarDataGridView();
                    LimpiarCampos();

                    // Incrementar ID de la factura
                    txtIdFactura.Text = (int.Parse(txtIdFactura.Text) + 1).ToString();

                    MessageBox.Show("Cliente agregado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente y recuerde el plazo es 24 o menos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La cola está llena. No se pueden agregar más clientes hasta que uno pague su deuda.", "Cola llena", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnPago_Click(object sender, EventArgs e)
        {
            if (colaClientes.Count > 0)
            {
                Cliente clientePagado = colaClientes.Dequeue();
                MessageBox.Show($"Cliente {clientePagado.NombreCliente} ha pagado su deuda y ha sido eliminado de la cola.", "Pago Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("La cola está vacía. No hay clientes para pagar.", "Cola Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMostrarCola_Click(object sender, EventArgs e)
        {
            ActualizarDataGridView(); //cuando le demos click al boton despues de una busqueda se
        }                            //mostrara todo el contnido del DataGrid


        private void ActualizarDataGridView()
        {
            dataGridViewClientes.Rows.Clear();
            foreach (var cliente in colaClientes)
            {
                dataGridViewClientes.Rows.Add(cliente.NombreCliente, cliente.SaldoPendiente, cliente.IdFactura, cliente.Plazos);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(nombreCliente))
            {
                bool encontrado = false;
                dataGridViewClientes.Rows.Clear(); //mostrar solo el cliente buscado

                foreach (Cliente cliente in colaClientes)
                {
                    if (cliente.NombreCliente.Equals(nombreCliente, StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridViewClientes.Rows.Add(cliente.NombreCliente, cliente.SaldoPendiente, cliente.IdFactura, cliente.Plazos);
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("Cliente no encontrado en la cola.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarCampos() 
        {
            txtNombreCliente.Clear();
            txtSaldoPendiente.Clear();
            txtPlazos.Clear();
            txtBuscar.Clear();
        }

        private void FormColaCircular_Load(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData) //Salir del formulario hacia el menu principal usando la tecla "esc"
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    }
}
