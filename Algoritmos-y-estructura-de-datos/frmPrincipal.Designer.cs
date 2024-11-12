namespace Algoritmos_y_estructura_de_datos
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnColasCirculares = new System.Windows.Forms.Button();
            this.btnColas = new System.Windows.Forms.Button();
            this.btnPilas = new System.Windows.Forms.Button();
            this.btnQuickSort = new System.Windows.Forms.Button();
            this.btnListaDoble = new System.Windows.Forms.Button();
            this.btnListaSimple = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnColasCirculares);
            this.groupBox1.Controls.Add(this.btnColas);
            this.groupBox1.Controls.Add(this.btnPilas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pilas y Colas";
            // 
            // btnColasCirculares
            // 
            this.btnColasCirculares.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColasCirculares.Location = new System.Drawing.Point(17, 91);
            this.btnColasCirculares.Name = "btnColasCirculares";
            this.btnColasCirculares.Size = new System.Drawing.Size(113, 23);
            this.btnColasCirculares.TabIndex = 0;
            this.btnColasCirculares.Text = "Colas Circulares";
            this.btnColasCirculares.UseVisualStyleBackColor = true;
            this.btnColasCirculares.Click += new System.EventHandler(this.btnColasCirculares_Click);
            // 
            // btnColas
            // 
            this.btnColas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColas.Location = new System.Drawing.Point(17, 55);
            this.btnColas.Name = "btnColas";
            this.btnColas.Size = new System.Drawing.Size(113, 23);
            this.btnColas.TabIndex = 0;
            this.btnColas.Text = "Colas";
            this.btnColas.UseVisualStyleBackColor = true;
            this.btnColas.Click += new System.EventHandler(this.btnColas_Click);
            // 
            // btnPilas
            // 
            this.btnPilas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPilas.Location = new System.Drawing.Point(17, 19);
            this.btnPilas.Name = "btnPilas";
            this.btnPilas.Size = new System.Drawing.Size(113, 23);
            this.btnPilas.TabIndex = 0;
            this.btnPilas.Text = "Pilas";
            this.btnPilas.UseVisualStyleBackColor = true;
            this.btnPilas.Click += new System.EventHandler(this.btnPilas_Click);
            // 
            // btnQuickSort
            // 
            this.btnQuickSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickSort.Location = new System.Drawing.Point(22, 41);
            this.btnQuickSort.Name = "btnQuickSort";
            this.btnQuickSort.Size = new System.Drawing.Size(113, 23);
            this.btnQuickSort.TabIndex = 3;
            this.btnQuickSort.Text = "QuickSort";
            this.btnQuickSort.UseVisualStyleBackColor = true;
            this.btnQuickSort.Click += new System.EventHandler(this.btnQuickSort_Click);
            // 
            // btnListaDoble
            // 
            this.btnListaDoble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaDoble.Location = new System.Drawing.Point(22, 65);
            this.btnListaDoble.Name = "btnListaDoble";
            this.btnListaDoble.Size = new System.Drawing.Size(113, 23);
            this.btnListaDoble.TabIndex = 2;
            this.btnListaDoble.Text = "Lista doble";
            this.btnListaDoble.UseVisualStyleBackColor = true;
            this.btnListaDoble.Click += new System.EventHandler(this.btnListaDoble_Click);
            // 
            // btnListaSimple
            // 
            this.btnListaSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaSimple.Location = new System.Drawing.Point(22, 23);
            this.btnListaSimple.Name = "btnListaSimple";
            this.btnListaSimple.Size = new System.Drawing.Size(113, 23);
            this.btnListaSimple.TabIndex = 1;
            this.btnListaSimple.Text = "Lista simple";
            this.btnListaSimple.UseVisualStyleBackColor = true;
            this.btnListaSimple.Click += new System.EventHandler(this.btnListaSimple_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnListaSimple);
            this.groupBox2.Controls.Add(this.btnListaDoble);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 105);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listas";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnQuickSort);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(202, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 105);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Algoritmos";
            // 
            // groupBox4
            // 
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(202, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(327, 105);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Arboles";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(535, 274);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Estructuras";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 305);
            this.Controls.Add(this.groupBox5);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPilas;
        private System.Windows.Forms.Button btnColasCirculares;
        private System.Windows.Forms.Button btnColas;
        private System.Windows.Forms.Button btnQuickSort;
        private System.Windows.Forms.Button btnListaDoble;
        private System.Windows.Forms.Button btnListaSimple;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

