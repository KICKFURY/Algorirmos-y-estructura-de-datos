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
                    !string.IsNullOrEmpty(txtIdFactura.Text) &&
                    int.TryParse(txtPlazos.Text, out int plazos))
                {
                    Cliente nuevoCliente = new Cliente
                    {
                        NombreCliente = txtNombreCliente.Text,
                        SaldoPendiente = saldoPendiente,
                        IdFactura = txtIdFactura.Text,
                        Plazos = plazos
                    };

                    colaClientes.Enqueue(nuevoCliente);
                    ActualizarDataGridView();
                    LimpiarCampos();
                    MessageBox.Show("Cliente agregado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FormColaCircular_Load(object sender, EventArgs e)
        {

        }

        private void btnMostrarCola_Click(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }


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
                foreach (Cliente cliente in colaClientes)
                {
                    if (cliente.NombreCliente.Equals(nombreCliente, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Cliente encontrado:\nNombre: {cliente.NombreCliente}\nSaldo Pendiente: {cliente.SaldoPendiente}\nID Factura: {cliente.IdFactura}\nPlazos: {cliente.Plazos}", "Cliente Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtIdFactura.Clear();
            txtPlazos.Clear();
            txtBuscar.Clear();
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
