namespace PalcoNet.Registro_de_Usuario
{
    partial class FormRegistroComun
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rbnEmpresa = new System.Windows.Forms.RadioButton();
            this.rbnCliente = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegresar);
            this.groupBox1.Controls.Add(this.btnSiguiente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbnEmpresa);
            this.groupBox1.Controls.Add(this.rbnCliente);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "REGISTRARSE";
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(6, 128);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(247, 29);
            this.btnRegresar.TabIndex = 10;
            this.btnRegresar.Text = "REGRESAR";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(6, 78);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(247, 44);
            this.btnSiguiente.TabIndex = 9;
            this.btnSiguiente.Text = "SIGUIENTE";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seleccione su perfil:";
            // 
            // rbnEmpresa
            // 
            this.rbnEmpresa.AutoSize = true;
            this.rbnEmpresa.Location = new System.Drawing.Point(9, 55);
            this.rbnEmpresa.Name = "rbnEmpresa";
            this.rbnEmpresa.Size = new System.Drawing.Size(66, 17);
            this.rbnEmpresa.TabIndex = 7;
            this.rbnEmpresa.TabStop = true;
            this.rbnEmpresa.Text = "Empresa";
            this.rbnEmpresa.UseVisualStyleBackColor = true;
            // 
            // rbnCliente
            // 
            this.rbnCliente.AutoSize = true;
            this.rbnCliente.Location = new System.Drawing.Point(9, 32);
            this.rbnCliente.Name = "rbnCliente";
            this.rbnCliente.Size = new System.Drawing.Size(57, 17);
            this.rbnCliente.TabIndex = 6;
            this.rbnCliente.TabStop = true;
            this.rbnCliente.Text = "Cliente";
            this.rbnCliente.UseVisualStyleBackColor = true;
            // 
            // FormRegistroComun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 188);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormRegistroComun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormRegistroComun_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbnEmpresa;
        private System.Windows.Forms.RadioButton rbnCliente;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnSiguiente;
    }
}