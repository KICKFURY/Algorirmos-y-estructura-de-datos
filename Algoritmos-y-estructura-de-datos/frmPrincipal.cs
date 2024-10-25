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

namespace Algoritmos_y_estructura_de_datos
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void mostrarFormulario(Form frm)
        {
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnPilas_Click(object sender, EventArgs e)
        {
            frmPilas frmPilas = new frmPilas();
            mostrarFormulario(frmPilas);
        }

        private void btnColas_Click(object sender, EventArgs e)
        {
            var frmColas = new frmColas();
            mostrarFormulario(frmColas);
        }
    }
}
