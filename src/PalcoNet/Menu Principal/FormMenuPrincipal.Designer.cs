namespace PalcoNet.Menu_Principal
{
    partial class FormMenuPrincipal
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
            this.dgvFuncionalidades = new System.Windows.Forms.DataGridView();
            this.lklCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.btnModificarContrasena = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvFuncionalidades);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FUNCIONALIDADES ACTIVAS";
            // 
            // dgvFuncionalidades
            // 
            this.dgvFuncionalidades.AllowUserToAddRows = false;
            this.dgvFuncionalidades.AllowUserToDeleteRows = false;
            this.dgvFuncionalidades.AllowUserToResizeRows = false;
            this.dgvFuncionalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuncionalidades.Location = new System.Drawing.Point(6, 19);
            this.dgvFuncionalidades.MultiSelect = false;
            this.dgvFuncionalidades.Name = "dgvFuncionalidades";
            this.dgvFuncionalidades.ReadOnly = true;
            this.dgvFuncionalidades.Size = new System.Drawing.Size(543, 289);
            this.dgvFuncionalidades.TabIndex = 16;
            this.dgvFuncionalidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFuncionalidades_CellContentClick);
            // 
            // lklCerrarSesion
            // 
            this.lklCerrarSesion.AutoSize = true;
            this.lklCerrarSesion.Location = new System.Drawing.Point(472, 9);
            this.lklCerrarSesion.Name = "lklCerrarSesion";
            this.lklCerrarSesion.Size = new System.Drawing.Size(95, 13);
            this.lklCerrarSesion.TabIndex = 15;
            this.lklCerrarSesion.TabStop = true;
            this.lklCerrarSesion.Text = "CERRAR SESIÓN";
            this.lklCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklCerrarSesion_LinkClicked);
            // 
            // btnModificarContrasena
            // 
            this.btnModificarContrasena.Location = new System.Drawing.Point(313, 345);
            this.btnModificarContrasena.Name = "btnModificarContrasena";
            this.btnModificarContrasena.Size = new System.Drawing.Size(254, 30);
            this.btnModificarContrasena.TabIndex = 16;
            this.btnModificarContrasena.Text = "MODIFICAR CONTRASEÑA";
            this.btnModificarContrasena.UseVisualStyleBackColor = true;
            this.btnModificarContrasena.Click += new System.EventHandler(this.btnModificarContrasena_Click);
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 387);
            this.Controls.Add(this.btnModificarContrasena);
            this.Controls.Add(this.lklCerrarSesion);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFuncionalidades;
        private System.Windows.Forms.LinkLabel lklCerrarSesion;
        private System.Windows.Forms.Button btnModificarContrasena;
    }
}