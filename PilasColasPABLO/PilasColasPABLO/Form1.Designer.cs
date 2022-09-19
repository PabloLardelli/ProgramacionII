namespace PilasColasPABLO
{
    partial class Form1
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
            this.txtElemento = new System.Windows.Forms.TextBox();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.lstElemento = new System.Windows.Forms.ListBox();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnVacia = new System.Windows.Forms.Button();
            this.btnExtraer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtElemento
            // 
            this.txtElemento.Location = new System.Drawing.Point(12, 12);
            this.txtElemento.Name = "txtElemento";
            this.txtElemento.Size = new System.Drawing.Size(209, 20);
            this.txtElemento.TabIndex = 0;
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(227, 10);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(75, 23);
            this.btnAñadir.TabIndex = 1;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // lstElemento
            // 
            this.lstElemento.FormattingEnabled = true;
            this.lstElemento.Location = new System.Drawing.Point(12, 38);
            this.lstElemento.Name = "lstElemento";
            this.lstElemento.Size = new System.Drawing.Size(290, 186);
            this.lstElemento.TabIndex = 2;
            // 
            // btnPrimero
            // 
            this.btnPrimero.Location = new System.Drawing.Point(47, 230);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(75, 23);
            this.btnPrimero.TabIndex = 3;
            this.btnPrimero.Text = "Primero";
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnVacia
            // 
            this.btnVacia.Location = new System.Drawing.Point(128, 230);
            this.btnVacia.Name = "btnVacia";
            this.btnVacia.Size = new System.Drawing.Size(75, 23);
            this.btnVacia.TabIndex = 4;
            this.btnVacia.Text = "Vacia?";
            this.btnVacia.UseVisualStyleBackColor = true;
            this.btnVacia.Click += new System.EventHandler(this.btnVacia_Click);
            // 
            // btnExtraer
            // 
            this.btnExtraer.Location = new System.Drawing.Point(209, 230);
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(75, 23);
            this.btnExtraer.TabIndex = 5;
            this.btnExtraer.Text = "Extraer";
            this.btnExtraer.UseVisualStyleBackColor = true;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 299);
            this.Controls.Add(this.btnExtraer);
            this.Controls.Add(this.btnVacia);
            this.Controls.Add(this.btnPrimero);
            this.Controls.Add(this.lstElemento);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.txtElemento);
            this.Name = "Form1";
            this.Text = "Coleccion | Pilas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtElemento;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.ListBox lstElemento;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnVacia;
        private System.Windows.Forms.Button btnExtraer;
    }
}

