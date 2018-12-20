namespace PalcoNet.Historial_Cliente
{
    partial class FormHistorialCliente
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
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.lklCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.paginaLabel = new System.Windows.Forms.Label();
            this.Primera = new System.Windows.Forms.Button();
            this.Ultima = new System.Windows.Forms.Button();
            this.siguiente = new System.Windows.Forms.Button();
            this.anterior = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AllowUserToResizeRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(12, 41);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.Size = new System.Drawing.Size(665, 450);
            this.dgvHistorial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "HISTORIAL DE COMPRAS";
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(410, 544);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(194, 44);
            this.btnMenuPrincipal.TabIndex = 0;
            this.btnMenuPrincipal.Text = "MENÚ PRINCIPAL";
            this.btnMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // lklCerrarSesion
            // 
            this.lklCerrarSesion.AutoSize = true;
            this.lklCerrarSesion.Location = new System.Drawing.Point(582, 9);
            this.lklCerrarSesion.Name = "lklCerrarSesion";
            this.lklCerrarSesion.Size = new System.Drawing.Size(95, 13);
            this.lklCerrarSesion.TabIndex = 16;
            this.lklCerrarSesion.TabStop = true;
            this.lklCerrarSesion.Text = "CERRAR SESIÓN";
            this.lklCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklCerrarSesion_LinkClicked);
            // 
            // paginaLabel
            // 
            this.paginaLabel.AutoSize = true;
            this.paginaLabel.Location = new System.Drawing.Point(332, 511);
            this.paginaLabel.Name = "paginaLabel";
            this.paginaLabel.Size = new System.Drawing.Size(0, 13);
            this.paginaLabel.TabIndex = 32;
            // 
            // Primera
            // 
            this.Primera.Location = new System.Drawing.Point(96, 497);
            this.Primera.Name = "Primera";
            this.Primera.Size = new System.Drawing.Size(75, 41);
            this.Primera.TabIndex = 31;
            this.Primera.Text = "Primera";
            this.Primera.UseVisualStyleBackColor = true;
            this.Primera.Click += new System.EventHandler(this.Primera_Click);
            // 
            // Ultima
            // 
            this.Ultima.Location = new System.Drawing.Point(529, 497);
            this.Ultima.Name = "Ultima";
            this.Ultima.Size = new System.Drawing.Size(75, 41);
            this.Ultima.TabIndex = 30;
            this.Ultima.Text = "Última";
            this.Ultima.UseVisualStyleBackColor = true;
            this.Ultima.Click += new System.EventHandler(this.Ultima_Click);
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(410, 497);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(113, 41);
            this.siguiente.TabIndex = 29;
            this.siguiente.Text = "Siguiente";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // anterior
            // 
            this.anterior.Location = new System.Drawing.Point(177, 497);
            this.anterior.Name = "anterior";
            this.anterior.Size = new System.Drawing.Size(113, 41);
            this.anterior.TabIndex = 28;
            this.anterior.Text = "Anterior";
            this.anterior.UseVisualStyleBackColor = true;
            this.anterior.Click += new System.EventHandler(this.anterior_Click);
            // 
            // FormHistorialCliente
            // 
            this.AcceptButton = this.btnMenuPrincipal;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnMenuPrincipal;
            this.ClientSize = new System.Drawing.Size(690, 600);
            this.Controls.Add(this.paginaLabel);
            this.Controls.Add(this.Primera);
            this.Controls.Add(this.Ultima);
            this.Controls.Add(this.siguiente);
            this.Controls.Add(this.anterior);
            this.Controls.Add(this.lklCerrarSesion);
            this.Controls.Add(this.btnMenuPrincipal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHistorial);
            this.MaximizeBox = false;
            this.Name = "FormHistorialCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenuPrincipal;
        private System.Windows.Forms.LinkLabel lklCerrarSesion;
        private System.Windows.Forms.Label paginaLabel;
        private System.Windows.Forms.Button Primera;
        private System.Windows.Forms.Button Ultima;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Button anterior;
    }
}