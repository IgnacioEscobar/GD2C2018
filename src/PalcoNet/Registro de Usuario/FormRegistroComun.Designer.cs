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
            this.lblError = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rbnEmpresa = new System.Windows.Forms.RadioButton();
            this.rbnCliente = new System.Windows.Forms.RadioButton();
            this.txtContrasena2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContrasena1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.btnRegresar);
            this.groupBox1.Controls.Add(this.btnSiguiente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbnEmpresa);
            this.groupBox1.Controls.Add(this.rbnCliente);
            this.groupBox1.Controls.Add(this.txtContrasena2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtContrasena1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 323);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "REGISTRARSE";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 220);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(90, 13);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "mensajes de error";
            this.lblError.Visible = false;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(6, 286);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(247, 29);
            this.btnRegresar.TabIndex = 10;
            this.btnRegresar.Text = "REGRESAR";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(6, 236);
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
            this.label4.Location = new System.Drawing.Point(6, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seleccione su perfil:";
            // 
            // rbnEmpresa
            // 
            this.rbnEmpresa.AutoSize = true;
            this.rbnEmpresa.Location = new System.Drawing.Point(9, 196);
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
            this.rbnCliente.Location = new System.Drawing.Point(9, 173);
            this.rbnCliente.Name = "rbnCliente";
            this.rbnCliente.Size = new System.Drawing.Size(57, 17);
            this.rbnCliente.TabIndex = 6;
            this.rbnCliente.TabStop = true;
            this.rbnCliente.Text = "Cliente";
            this.rbnCliente.UseVisualStyleBackColor = true;
            // 
            // txtContrasena2
            // 
            this.txtContrasena2.Location = new System.Drawing.Point(7, 125);
            this.txtContrasena2.Name = "txtContrasena2";
            this.txtContrasena2.PasswordChar = '*';
            this.txtContrasena2.Size = new System.Drawing.Size(246, 20);
            this.txtContrasena2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirmar contraseña:";
            // 
            // txtContrasena1
            // 
            this.txtContrasena1.Location = new System.Drawing.Point(7, 81);
            this.txtContrasena1.Name = "txtContrasena1";
            this.txtContrasena1.PasswordChar = '*';
            this.txtContrasena1.Size = new System.Drawing.Size(246, 20);
            this.txtContrasena1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(7, 37);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(246, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // FormRegistroComun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 348);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormRegistroComun";
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormRegistroComun_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContrasena1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbnEmpresa;
        private System.Windows.Forms.RadioButton rbnCliente;
        private System.Windows.Forms.TextBox txtContrasena2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblError;
    }
}