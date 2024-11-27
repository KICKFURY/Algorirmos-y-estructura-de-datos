namespace Algoritmos_y_estructura_de_datos.Formularios
{
    partial class frmDIJKSTRA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelGrafo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDIJKSTRA = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDistancia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdVerticeA = new System.Windows.Forms.TextBox();
            this.txtIdVerticeB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditarDistancia = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdOrigen = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtIdDestino = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEliminarDistancia = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(87, 98);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelGrafo
            // 
            this.panelGrafo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrafo.AutoSize = true;
            this.panelGrafo.Location = new System.Drawing.Point(6, 142);
            this.panelGrafo.Name = "panelGrafo";
            this.panelGrafo.Size = new System.Drawing.Size(834, 374);
            this.panelGrafo.TabIndex = 36;
            this.panelGrafo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGrafo_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAgregarArista_Click);
            // 
            // btnDIJKSTRA
            // 
            this.btnDIJKSTRA.Location = new System.Drawing.Point(23, 103);
            this.btnDIJKSTRA.Name = "btnDIJKSTRA";
            this.btnDIJKSTRA.Size = new System.Drawing.Size(135, 23);
            this.btnDIJKSTRA.TabIndex = 1;
            this.btnDIJKSTRA.Text = "Distancia corta";
            this.btnDIJKSTRA.UseVisualStyleBackColor = true;
            this.btnDIJKSTRA.Click += new System.EventHandler(this.btnDIJKSTRA_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "Proveedor:";
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Location = new System.Drawing.Point(87, 56);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(151, 21);
            this.txtNombreProveedor.TabIndex = 1;
            this.txtNombreProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(87, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(151, 21);
            this.txtId.TabIndex = 0;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.txtNombreProveedor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 124);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Vertice";
            // 
            // txtDistancia
            // 
            this.txtDistancia.Location = new System.Drawing.Point(124, 72);
            this.txtDistancia.Name = "txtDistancia";
            this.txtDistancia.Size = new System.Drawing.Size(151, 21);
            this.txtDistancia.TabIndex = 2;
            this.txtDistancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Distancia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "Id Vertice B:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Id Vertice A:";
            // 
            // txtIdVerticeA
            // 
            this.txtIdVerticeA.Location = new System.Drawing.Point(124, 20);
            this.txtIdVerticeA.Name = "txtIdVerticeA";
            this.txtIdVerticeA.Size = new System.Drawing.Size(151, 21);
            this.txtIdVerticeA.TabIndex = 0;
            this.txtIdVerticeA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdVerticeB
            // 
            this.txtIdVerticeB.Location = new System.Drawing.Point(124, 46);
            this.txtIdVerticeB.Name = "txtIdVerticeB";
            this.txtIdVerticeB.Size = new System.Drawing.Size(151, 21);
            this.txtIdVerticeB.TabIndex = 1;
            this.txtIdVerticeB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.txtIdVerticeB);
            this.groupBox2.Controls.Add(this.txtIdVerticeA);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnEliminarDistancia);
            this.groupBox2.Controls.Add(this.btnEditarDistancia);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDistancia);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(327, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 124);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar distancia entre aristas";
            // 
            // btnEditarDistancia
            // 
            this.btnEditarDistancia.Location = new System.Drawing.Point(124, 98);
            this.btnEditarDistancia.Name = "btnEditarDistancia";
            this.btnEditarDistancia.Size = new System.Drawing.Size(66, 23);
            this.btnEditarDistancia.TabIndex = 4;
            this.btnEditarDistancia.Text = "Editar";
            this.btnEditarDistancia.UseVisualStyleBackColor = true;
            this.btnEditarDistancia.Click += new System.EventHandler(this.btnEditarDistancia_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 37;
            this.label6.Text = "Id Vertice A:";
            // 
            // txtIdOrigen
            // 
            this.txtIdOrigen.Enabled = false;
            this.txtIdOrigen.Location = new System.Drawing.Point(95, 27);
            this.txtIdOrigen.Name = "txtIdOrigen";
            this.txtIdOrigen.Size = new System.Drawing.Size(77, 21);
            this.txtIdOrigen.TabIndex = 0;
            this.txtIdOrigen.Text = "1";
            this.txtIdOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.txtIdDestino);
            this.groupBox3.Controls.Add(this.txtIdOrigen);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnDIJKSTRA);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(662, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 129);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Distancia mas corta";
            // 
            // txtIdDestino
            // 
            this.txtIdDestino.Location = new System.Drawing.Point(95, 53);
            this.txtIdDestino.Name = "txtIdDestino";
            this.txtIdDestino.Size = new System.Drawing.Size(77, 21);
            this.txtIdDestino.TabIndex = 0;
            this.txtIdDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 38;
            this.label7.Text = "Id Vertice B:";
            // 
            // btnEliminarDistancia
            // 
            this.btnEliminarDistancia.Location = new System.Drawing.Point(235, 98);
            this.btnEliminarDistancia.Name = "btnEliminarDistancia";
            this.btnEliminarDistancia.Size = new System.Drawing.Size(66, 23);
            this.btnEliminarDistancia.TabIndex = 5;
            this.btnEliminarDistancia.Text = "Eliminar";
            this.btnEliminarDistancia.UseVisualStyleBackColor = true;
            this.btnEliminarDistancia.Click += new System.EventHandler(this.btnEliminarDistancia_Click);
            // 
            // frmDIJKSTRA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(852, 528);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelGrafo);
            this.Name = "frmDIJKSTRA";
            this.Text = "frmDIJKSTRA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelGrafo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDIJKSTRA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDistancia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdVerticeA;
        private System.Windows.Forms.TextBox txtIdVerticeB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdOrigen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtIdDestino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEditarDistancia;
        private System.Windows.Forms.Button btnEliminarDistancia;
    }
}