﻿namespace PalcoNet.Registro_de_Usuario
{
    partial class FormRegistroEmpresa
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
            this.lblError = new System.Windows.Forms.Label();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNroTelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodTelefono = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCUIT1 = new System.Windows.Forms.TextBox();
            this.txtCUIT2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCUIT3 = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(280, 139);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(90, 13);
            this.lblError.TabIndex = 33;
            this.lblError.Text = "mensajes de error";
            this.lblError.Visible = false;
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.Location = new System.Drawing.Point(280, 155);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(262, 59);
            this.btnCrearCuenta.TabIndex = 32;
            this.btnCrearCuenta.Text = "CREAR CUENTA";
            this.btnCrearCuenta.UseVisualStyleBackColor = true;
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(280, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(262, 32);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtCodigoPostal);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtLocalidad);
            this.groupBox3.Controls.Add(this.txtDpto);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtCalle);
            this.groupBox3.Controls.Add(this.txtPiso);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 133);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DIRECCIÓN";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Código postal";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(6, 104);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(89, 20);
            this.txtCodigoPostal.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(120, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(120, 104);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(136, 20);
            this.txtLocalidad.TabIndex = 25;
            // 
            // txtDpto
            // 
            this.txtDpto.Location = new System.Drawing.Point(200, 58);
            this.txtDpto.Name = "txtDpto";
            this.txtDpto.Size = new System.Drawing.Size(56, 20);
            this.txtDpto.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(120, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Departamento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Calle";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(6, 32);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(250, 20);
            this.txtCalle.TabIndex = 18;
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(39, 58);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(56, 20);
            this.txtPiso.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Piso";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNroTelefono);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCodTelefono);
            this.groupBox2.Controls.Add(this.txtMail);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(280, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 101);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONTACTO";
            // 
            // txtNroTelefono
            // 
            this.txtNroTelefono.Location = new System.Drawing.Point(83, 71);
            this.txtNroTelefono.Name = "txtNroTelefono";
            this.txtNroTelefono.Size = new System.Drawing.Size(173, 20);
            this.txtNroTelefono.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Mail";
            // 
            // txtCodTelefono
            // 
            this.txtCodTelefono.Location = new System.Drawing.Point(6, 71);
            this.txtCodTelefono.Name = "txtCodTelefono";
            this.txtCodTelefono.Size = new System.Drawing.Size(71, 20);
            this.txtCodTelefono.TabIndex = 20;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(6, 32);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(250, 20);
            this.txtMail.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Teléfono";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCUIT1);
            this.groupBox1.Controls.Add(this.txtCUIT2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRazonSocial);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCUIT3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 101);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DE LA EMPRESA";
            // 
            // txtCUIT1
            // 
            this.txtCUIT1.Location = new System.Drawing.Point(6, 71);
            this.txtCUIT1.MaxLength = 2;
            this.txtCUIT1.Name = "txtCUIT1";
            this.txtCUIT1.Size = new System.Drawing.Size(42, 20);
            this.txtCUIT1.TabIndex = 19;
            // 
            // txtCUIT2
            // 
            this.txtCUIT2.Location = new System.Drawing.Point(54, 71);
            this.txtCUIT2.MaxLength = 8;
            this.txtCUIT2.Name = "txtCUIT2";
            this.txtCUIT2.Size = new System.Drawing.Size(154, 20);
            this.txtCUIT2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razón social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(6, 32);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(250, 20);
            this.txtRazonSocial.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "CUIT";
            // 
            // txtCUIT3
            // 
            this.txtCUIT3.Location = new System.Drawing.Point(214, 71);
            this.txtCUIT3.MaxLength = 1;
            this.txtCUIT3.Name = "txtCUIT3";
            this.txtCUIT3.Size = new System.Drawing.Size(42, 20);
            this.txtCUIT3.TabIndex = 10;
            // 
            // FormRegistroEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 264);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnCrearCuenta);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormRegistroEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormRegistroEmpresa_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtDpto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNroTelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodTelefono;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCUIT1;
        private System.Windows.Forms.TextBox txtCUIT2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCUIT3;
    }
}