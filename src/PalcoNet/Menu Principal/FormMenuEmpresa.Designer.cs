namespace PalcoNet.Menu_Principal
{
    partial class FormMenuEmpresa
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
            this.btnGenerarPublicacion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbAlto = new System.Windows.Forms.CheckBox();
            this.ckbMedio = new System.Windows.Forms.CheckBox();
            this.ckbBajo = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbPublicada = new System.Windows.Forms.CheckBox();
            this.ckbBorrador = new System.Windows.Forms.CheckBox();
            this.ckbFinalizada = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.lklCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPublicaciones = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerarPublicacion
            // 
            this.btnGenerarPublicacion.Location = new System.Drawing.Point(482, 253);
            this.btnGenerarPublicacion.Name = "btnGenerarPublicacion";
            this.btnGenerarPublicacion.Size = new System.Drawing.Size(216, 43);
            this.btnGenerarPublicacion.TabIndex = 12;
            this.btnGenerarPublicacion.Text = "GENERAR PUBLICACIÓN";
            this.btnGenerarPublicacion.UseVisualStyleBackColor = true;
            this.btnGenerarPublicacion.Click += new System.EventHandler(this.btnGenerarPublicacion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Location = new System.Drawing.Point(482, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE BÚSQUEDA";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(7, 37);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(203, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descripción";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckbAlto);
            this.groupBox3.Controls.Add(this.ckbMedio);
            this.groupBox3.Controls.Add(this.ckbBajo);
            this.groupBox3.Location = new System.Drawing.Point(111, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(99, 89);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grado";
            // 
            // ckbAlto
            // 
            this.ckbAlto.AutoSize = true;
            this.ckbAlto.Checked = true;
            this.ckbAlto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAlto.Location = new System.Drawing.Point(6, 19);
            this.ckbAlto.Name = "ckbAlto";
            this.ckbAlto.Size = new System.Drawing.Size(44, 17);
            this.ckbAlto.TabIndex = 7;
            this.ckbAlto.Text = "Alto";
            this.ckbAlto.UseVisualStyleBackColor = true;
            // 
            // ckbMedio
            // 
            this.ckbMedio.AutoSize = true;
            this.ckbMedio.Checked = true;
            this.ckbMedio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMedio.Location = new System.Drawing.Point(6, 43);
            this.ckbMedio.Name = "ckbMedio";
            this.ckbMedio.Size = new System.Drawing.Size(55, 17);
            this.ckbMedio.TabIndex = 8;
            this.ckbMedio.Text = "Medio";
            this.ckbMedio.UseVisualStyleBackColor = true;
            // 
            // ckbBajo
            // 
            this.ckbBajo.AutoSize = true;
            this.ckbBajo.Checked = true;
            this.ckbBajo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbBajo.Location = new System.Drawing.Point(6, 67);
            this.ckbBajo.Name = "ckbBajo";
            this.ckbBajo.Size = new System.Drawing.Size(47, 17);
            this.ckbBajo.TabIndex = 9;
            this.ckbBajo.Text = "Bajo";
            this.ckbBajo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbPublicada);
            this.groupBox2.Controls.Add(this.ckbBorrador);
            this.groupBox2.Controls.Add(this.ckbFinalizada);
            this.groupBox2.Location = new System.Drawing.Point(6, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(99, 89);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado";
            // 
            // ckbPublicada
            // 
            this.ckbPublicada.AutoSize = true;
            this.ckbPublicada.Checked = true;
            this.ckbPublicada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbPublicada.Location = new System.Drawing.Point(6, 43);
            this.ckbPublicada.Name = "ckbPublicada";
            this.ckbPublicada.Size = new System.Drawing.Size(73, 17);
            this.ckbPublicada.TabIndex = 4;
            this.ckbPublicada.Text = "Publicada";
            this.ckbPublicada.UseVisualStyleBackColor = true;
            // 
            // ckbBorrador
            // 
            this.ckbBorrador.AutoSize = true;
            this.ckbBorrador.Checked = true;
            this.ckbBorrador.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbBorrador.Location = new System.Drawing.Point(6, 19);
            this.ckbBorrador.Name = "ckbBorrador";
            this.ckbBorrador.Size = new System.Drawing.Size(66, 17);
            this.ckbBorrador.TabIndex = 3;
            this.ckbBorrador.Text = "Borrador";
            this.ckbBorrador.UseVisualStyleBackColor = true;
            // 
            // ckbFinalizada
            // 
            this.ckbFinalizada.AutoSize = true;
            this.ckbFinalizada.Checked = true;
            this.ckbFinalizada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbFinalizada.Location = new System.Drawing.Point(6, 67);
            this.ckbFinalizada.Name = "ckbFinalizada";
            this.ckbFinalizada.Size = new System.Drawing.Size(73, 17);
            this.ckbFinalizada.TabIndex = 5;
            this.ckbFinalizada.Text = "Finalizada";
            this.ckbFinalizada.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(6, 188);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(204, 24);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(6, 158);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(204, 24);
            this.btnFiltrar.TabIndex = 10;
            this.btnFiltrar.Text = "FILTRAR";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Location = new System.Drawing.Point(482, 410);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(216, 43);
            this.btnConfiguracion.TabIndex = 13;
            this.btnConfiguracion.Text = "CONFIGURACIÓN DE CUENTA";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // lklCerrarSesion
            // 
            this.lklCerrarSesion.AutoSize = true;
            this.lklCerrarSesion.Location = new System.Drawing.Point(603, 9);
            this.lklCerrarSesion.Name = "lklCerrarSesion";
            this.lklCerrarSesion.Size = new System.Drawing.Size(95, 13);
            this.lklCerrarSesion.TabIndex = 14;
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
            this.label1.Size = new System.Drawing.Size(197, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "PUBLICACIONES PROPIAS";
            // 
            // dgvPublicaciones
            // 
            this.dgvPublicaciones.AllowUserToAddRows = false;
            this.dgvPublicaciones.AllowUserToDeleteRows = false;
            this.dgvPublicaciones.AllowUserToResizeRows = false;
            this.dgvPublicaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublicaciones.Location = new System.Drawing.Point(12, 28);
            this.dgvPublicaciones.Name = "dgvPublicaciones";
            this.dgvPublicaciones.Size = new System.Drawing.Size(464, 425);
            this.dgvPublicaciones.TabIndex = 15;
            this.dgvPublicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPublicaciones_CellContentClick);
            // 
            // FormMenuEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 465);
            this.Controls.Add(this.btnGenerarPublicacion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConfiguracion);
            this.Controls.Add(this.lklCerrarSesion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPublicaciones);
            this.MaximizeBox = false;
            this.Name = "FormMenuEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormMenuEmpresa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarPublicacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.LinkLabel lklCerrarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPublicaciones;
        private System.Windows.Forms.CheckBox ckbBajo;
        private System.Windows.Forms.CheckBox ckbMedio;
        private System.Windows.Forms.CheckBox ckbAlto;
        private System.Windows.Forms.CheckBox ckbFinalizada;
        private System.Windows.Forms.CheckBox ckbPublicada;
        private System.Windows.Forms.CheckBox ckbBorrador;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnFiltrar;
    }
}