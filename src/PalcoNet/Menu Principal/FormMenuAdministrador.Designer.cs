namespace PalcoNet.Menu_Principal
{
    partial class FormMenuAdministrador
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
            this.lklCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnResumen = new System.Windows.Forms.Button();
            this.btnRendicion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPublicaciones = new System.Windows.Forms.Button();
            this.btnGrados = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEmpresas = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lklCerrarSesion
            // 
            this.lklCerrarSesion.AutoSize = true;
            this.lklCerrarSesion.Location = new System.Drawing.Point(527, 5);
            this.lklCerrarSesion.Name = "lklCerrarSesion";
            this.lklCerrarSesion.Size = new System.Drawing.Size(95, 13);
            this.lklCerrarSesion.TabIndex = 9;
            this.lklCerrarSesion.TabStop = true;
            this.lklCerrarSesion.Text = "CERRAR SESIÓN";
            this.lklCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklCerrarSesion_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "PANEL DE CONTROL";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnResumen);
            this.groupBox3.Controls.Add(this.btnRendicion);
            this.groupBox3.Location = new System.Drawing.Point(11, 211);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(610, 69);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ADMINISTRACIÓN DE COMISIONES";
            // 
            // btnResumen
            // 
            this.btnResumen.Location = new System.Drawing.Point(314, 19);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(290, 43);
            this.btnResumen.TabIndex = 8;
            this.btnResumen.Text = "RESUMEN DE FACTURACIÓN";
            this.btnResumen.UseVisualStyleBackColor = true;
            // 
            // btnRendicion
            // 
            this.btnRendicion.Location = new System.Drawing.Point(6, 19);
            this.btnRendicion.Name = "btnRendicion";
            this.btnRendicion.Size = new System.Drawing.Size(290, 43);
            this.btnRendicion.TabIndex = 7;
            this.btnRendicion.Text = "GENERAR RENDICIÓN";
            this.btnRendicion.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPublicaciones);
            this.groupBox2.Controls.Add(this.btnGrados);
            this.groupBox2.Controls.Add(this.btnCategorias);
            this.groupBox2.Location = new System.Drawing.Point(319, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 168);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADMINISTRACIÓN DE PUBLICACIONES";
            // 
            // btnPublicaciones
            // 
            this.btnPublicaciones.Location = new System.Drawing.Point(6, 19);
            this.btnPublicaciones.Name = "btnPublicaciones";
            this.btnPublicaciones.Size = new System.Drawing.Size(290, 43);
            this.btnPublicaciones.TabIndex = 4;
            this.btnPublicaciones.Text = "PUBLICACIONES";
            this.btnPublicaciones.UseVisualStyleBackColor = true;
            // 
            // btnGrados
            // 
            this.btnGrados.Location = new System.Drawing.Point(6, 117);
            this.btnGrados.Name = "btnGrados";
            this.btnGrados.Size = new System.Drawing.Size(290, 43);
            this.btnGrados.TabIndex = 6;
            this.btnGrados.Text = "GRADOS";
            this.btnGrados.UseVisualStyleBackColor = true;
            this.btnGrados.Click += new System.EventHandler(this.btnGrados_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Location = new System.Drawing.Point(6, 68);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(290, 43);
            this.btnCategorias.TabIndex = 5;
            this.btnCategorias.Text = "CATEGORÍAS";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEmpresas);
            this.groupBox1.Controls.Add(this.btnClientes);
            this.groupBox1.Controls.Add(this.btnUsuarios);
            this.groupBox1.Controls.Add(this.btnRoles);
            this.groupBox1.Location = new System.Drawing.Point(11, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 168);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ADMINISTRACIÓN DE USUARIOS";
            // 
            // btnEmpresas
            // 
            this.btnEmpresas.Location = new System.Drawing.Point(154, 68);
            this.btnEmpresas.Name = "btnEmpresas";
            this.btnEmpresas.Size = new System.Drawing.Size(142, 43);
            this.btnEmpresas.TabIndex = 2;
            this.btnEmpresas.Text = "EMPRESAS";
            this.btnEmpresas.UseVisualStyleBackColor = true;
            this.btnEmpresas.Click += new System.EventHandler(this.btnEmpresas_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(6, 68);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(142, 43);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "CLIENTES";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(6, 19);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(290, 43);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "CUENTAS DE USUARIO";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Location = new System.Drawing.Point(6, 117);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(290, 43);
            this.btnRoles.TabIndex = 3;
            this.btnRoles.Text = "ROLES";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // FormMenuAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 291);
            this.Controls.Add(this.lklCerrarSesion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormMenuAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lklCerrarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnResumen;
        private System.Windows.Forms.Button btnRendicion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPublicaciones;
        private System.Windows.Forms.Button btnGrados;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEmpresas;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnRoles;
    }
}