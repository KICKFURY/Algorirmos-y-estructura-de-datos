namespace Algoritmos_y_estructura_de_datos.Formularios
{
    partial class Floyd_Warshall
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFLOYD = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIdVerticeB = new System.Windows.Forms.TextBox();
            this.txtIdVerticeA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminarDistancia = new System.Windows.Forms.Button();
            this.btnEditarDistancia = new System.Windows.Forms.Button();
            this.btnAgregarDistancia = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDistancia = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelGrafo = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.btnFLOYD);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(675, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 110);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Distancias mas corta";
            // 
            // btnFLOYD
            // 
            this.btnFLOYD.Location = new System.Drawing.Point(22, 51);
            this.btnFLOYD.Name = "btnFLOYD";
            this.btnFLOYD.Size = new System.Drawing.Size(135, 23);
            this.btnFLOYD.TabIndex = 1;
            this.btnFLOYD.Text = "Distancias cortas";
            this.btnFLOYD.UseVisualStyleBackColor = true;
            this.btnFLOYD.Click += new System.EventHandler(this.btnFLOYD_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.txtIdVerticeB);
            this.groupBox2.Controls.Add(this.txtIdVerticeA);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnEliminarDistancia);
            this.groupBox2.Controls.Add(this.btnEditarDistancia);
            this.groupBox2.Controls.Add(this.btnAgregarDistancia);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDistancia);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(340, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 124);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar distancia entre aristas";
            // 
            // txtIdVerticeB
            // 
            this.txtIdVerticeB.Location = new System.Drawing.Point(124, 46);
            this.txtIdVerticeB.Name = "txtIdVerticeB";
            this.txtIdVerticeB.Size = new System.Drawing.Size(151, 21);
            this.txtIdVerticeB.TabIndex = 1;
            this.txtIdVerticeB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdVerticeA
            // 
            this.txtIdVerticeA.Location = new System.Drawing.Point(124, 20);
            this.txtIdVerticeA.Name = "txtIdVerticeA";
            this.txtIdVerticeA.Size = new System.Drawing.Size(151, 21);
            this.txtIdVerticeA.TabIndex = 0;
            this.txtIdVerticeA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // btnEliminarDistancia
            // 
            this.btnEliminarDistancia.Location = new System.Drawing.Point(228, 98);
            this.btnEliminarDistancia.Name = "btnEliminarDistancia";
            this.btnEliminarDistancia.Size = new System.Drawing.Size(73, 23);
            this.btnEliminarDistancia.TabIndex = 5;
            this.btnEliminarDistancia.Text = "Eliminar";
            this.btnEliminarDistancia.UseVisualStyleBackColor = true;
            this.btnEliminarDistancia.Click += new System.EventHandler(this.btnEliminarDistancia_Click);
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
            // btnAgregarDistancia
            // 
            this.btnAgregarDistancia.Location = new System.Drawing.Point(9, 98);
            this.btnAgregarDistancia.Name = "btnAgregarDistancia";
            this.btnAgregarDistancia.Size = new System.Drawing.Size(73, 23);
            this.btnAgregarDistancia.TabIndex = 3;
            this.btnAgregarDistancia.Text = "Agregar";
            this.btnAgregarDistancia.UseVisualStyleBackColor = true;
            this.btnAgregarDistancia.Click += new System.EventHandler(this.btnAgregarDistancia_Click);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Distancia:";
            // 
            // txtDistancia
            // 
            this.txtDistancia.Location = new System.Drawing.Point(124, 72);
            this.txtDistancia.Name = "txtDistancia";
            this.txtDistancia.Size = new System.Drawing.Size(151, 21);
            this.txtDistancia.TabIndex = 2;
            this.txtDistancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 124);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Vertice";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(87, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(151, 21);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "1";
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(87, 56);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(151, 21);
            this.txtProveedor.TabIndex = 1;
            this.txtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Id:";
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
            this.panelGrafo.Location = new System.Drawing.Point(19, 170);
            this.panelGrafo.Name = "panelGrafo";
            this.panelGrafo.Size = new System.Drawing.Size(834, 325);
            this.panelGrafo.TabIndex = 44;
            this.panelGrafo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGrafo_Paint);
            // 
            // Floyd_Warshall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 507);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelGrafo);
            this.Name = "Floyd_Warshall";
            this.Text = "Floyd_Warshall";
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFLOYD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIdVerticeB;
        private System.Windows.Forms.TextBox txtIdVerticeA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminarDistancia;
        private System.Windows.Forms.Button btnEditarDistancia;
        private System.Windows.Forms.Button btnAgregarDistancia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDistancia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelGrafo;
    }
}