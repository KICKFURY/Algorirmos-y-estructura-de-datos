using Algoritmos_y_estructura_de_datos.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
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

        private void btnColasCirculares_Click(object sender, EventArgs e)
        {
            var formColaCircular = new FormColaCircular();
            mostrarFormulario(formColaCircular);
        }

        private void btnListaSimple_Click(object sender, EventArgs e)
        {
            var listaSimple = new ListaSimple();
            mostrarFormulario(listaSimple);
        }

        private void btnListaDoble_Click(object sender, EventArgs e)
        {
            var listaDoble = new ListaDoble();
            mostrarFormulario(listaDoble);
        }

        private void btnQuickSort_Click(object sender, EventArgs e)
        {
            var quickSort = new frmQuickSort();
            mostrarFormulario(quickSort);
        }

        private void btnBubleSort_Click(object sender, EventArgs e)
        {
            var BubleSort = new BubleSort();
            mostrarFormulario(BubleSort);
        }

        private void btnSelectionSort_Click(object sender, EventArgs e)
        {
            var SelectionSort = new SelectionSort();
            mostrarFormulario(SelectionSort);
        }

        private void btnHeapSort_Click(object sender, EventArgs e)
        {
            var HeapSort = new HeapSort();
            mostrarFormulario(HeapSort);
        }

        private void btnBinarios_Click(object sender, EventArgs e)
        {
            var arbolesBinarios = new frmArbolBinario();
            mostrarFormulario(arbolesBinarios);
        }

        private void btnShellSort_Click(object sender, EventArgs e)
        {
            var shellsort = new ShellSort();
            mostrarFormulario(shellsort);
        }

        private void btnShakerSort_Click(object sender, EventArgs e)
        {
            var shakerSort = new ShakerSort();
            mostrarFormulario(shakerSort);
        }

        private void btnAVL_Click(object sender, EventArgs e)
        {
            var AVL = new frmArbolAVL();
            mostrarFormulario(AVL);
        }

        private void btnDIJKSTRA_Click(object sender, EventArgs e)
        {
            var dijkstra = new frmDIJKSTRA();
            mostrarFormulario(dijkstra);
        }

        private void btnFLOYD_Click(object sender, EventArgs e)
        {
            var Floyd_Warshall = new Floyd_Warshall();
            mostrarFormulario(Floyd_Warshall);
        }

        private void btnMARSHALL_Click(object sender, EventArgs e)
        {


        }
    }
}
