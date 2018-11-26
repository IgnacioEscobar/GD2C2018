namespace PalcoNet.Login
{
    partial class FormElegirRol
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
            this.rbnCliente = new System.Windows.Forms.RadioButton();
            this.rbnEmpresa = new System.Windows.Forms.RadioButton();
            this.rbnAdministrativo = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbnCliente
            // 
            this.rbnCliente.AutoSize = true;
            this.rbnCliente.Enabled = false;
            this.rbnCliente.Location = new System.Drawing.Point(10, 19);
            this.rbnCliente.Name = "rbnCliente";
            this.rbnCliente.Size = new System.Drawing.Size(57, 17);
            this.rbnCliente.TabIndex = 0;
            this.rbnCliente.Text = "Cliente";
            this.rbnCliente.UseVisualStyleBackColor = true;
            // 
            // rbnEmpresa
            // 
            this.rbnEmpresa.AutoSize = true;
            this.rbnEmpresa.Enabled = false;
            this.rbnEmpresa.Location = new System.Drawing.Point(10, 43);
            this.rbnEmpresa.Name = "rbnEmpresa";
            this.rbnEmpresa.Size = new System.Drawing.Size(66, 17);
            this.rbnEmpresa.TabIndex = 2;
            this.rbnEmpresa.Text = "Empresa";
            this.rbnEmpresa.UseVisualStyleBackColor = true;
            // 
            // rbnAdministrativo
            // 
            this.rbnAdministrativo.AutoSize = true;
            this.rbnAdministrativo.Enabled = false;
            this.rbnAdministrativo.Location = new System.Drawing.Point(10, 67);
            this.rbnAdministrativo.Name = "rbnAdministrativo";
            this.rbnAdministrativo.Size = new System.Drawing.Size(90, 17);
            this.rbnAdministrativo.TabIndex = 3;
            this.rbnAdministrativo.Text = "Administrativo";
            this.rbnAdministrativo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(6, 90);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 44);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(127, 90);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(115, 44);
            this.btnSiguiente.TabIndex = 7;
            this.btnSiguiente.Text = "SIGUIENTE";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.rbnAdministrativo);
            this.groupBox1.Controls.Add(this.btnSiguiente);
            this.groupBox1.Controls.Add(this.rbnCliente);
            this.groupBox1.Controls.Add(this.rbnEmpresa);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 141);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECCIONAR ROL";
            // 
            // FormElegirRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 164);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormElegirRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormElegirRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbnCliente;
        private System.Windows.Forms.RadioButton rbnEmpresa;
        private System.Windows.Forms.RadioButton rbnAdministrativo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}