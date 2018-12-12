namespace PalcoNet.Editar_Publicacion
{
    partial class FormEditarPublicacion
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
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.lklCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPublicaciones = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbRangoFechas = new System.Windows.Forms.CheckBox();
            this.mcrHasta = new System.Windows.Forms.MonthCalendar();
            this.mcrDesde = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clbCategorias = new System.Windows.Forms.CheckedListBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.Location = new System.Drawing.Point(748, 411);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(197, 42);
            this.btnMenuPrincipal.TabIndex = 13;
            this.btnMenuPrincipal.Text = "MENÚ PRINCIPAL";
            this.btnMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // lklCerrarSesion
            // 
            this.lklCerrarSesion.AutoSize = true;
            this.lklCerrarSesion.Location = new System.Drawing.Point(856, 9);
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
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "PUBLICACIONES";
            // 
            // dgvPublicaciones
            // 
            this.dgvPublicaciones.AllowUserToAddRows = false;
            this.dgvPublicaciones.AllowUserToDeleteRows = false;
            this.dgvPublicaciones.AllowUserToResizeRows = false;
            this.dgvPublicaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublicaciones.Location = new System.Drawing.Point(12, 28);
            this.dgvPublicaciones.MultiSelect = false;
            this.dgvPublicaciones.Name = "dgvPublicaciones";
            this.dgvPublicaciones.ReadOnly = true;
            this.dgvPublicaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPublicaciones.Size = new System.Drawing.Size(508, 425);
            this.dgvPublicaciones.TabIndex = 15;
            this.dgvPublicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPublicaciones_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbRangoFechas);
            this.groupBox1.Controls.Add(this.mcrHasta);
            this.groupBox1.Controls.Add(this.mcrDesde);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.clbCategorias);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Location = new System.Drawing.Point(526, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 377);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE BÚSQUEDA";
            // 
            // ckbRangoFechas
            // 
            this.ckbRangoFechas.AutoSize = true;
            this.ckbRangoFechas.Location = new System.Drawing.Point(6, 67);
            this.ckbRangoFechas.Name = "ckbRangoFechas";
            this.ckbRangoFechas.Size = new System.Drawing.Size(149, 17);
            this.ckbRangoFechas.TabIndex = 20;
            this.ckbRangoFechas.Text = "Filtrar por rango de fechas";
            this.ckbRangoFechas.UseVisualStyleBackColor = true;
            // 
            // mcrHasta
            // 
            this.mcrHasta.Location = new System.Drawing.Point(222, 90);
            this.mcrHasta.MaxSelectionCount = 1;
            this.mcrHasta.Name = "mcrHasta";
            this.mcrHasta.TabIndex = 19;
            // 
            // mcrDesde
            // 
            this.mcrDesde.Location = new System.Drawing.Point(12, 90);
            this.mcrDesde.Name = "mcrDesde";
            this.mcrDesde.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Categorías";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Descripción";
            // 
            // clbCategorias
            // 
            this.clbCategorias.FormattingEnabled = true;
            this.clbCategorias.Location = new System.Drawing.Point(6, 277);
            this.clbCategorias.Name = "clbCategorias";
            this.clbCategorias.Size = new System.Drawing.Size(209, 94);
            this.clbCategorias.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(6, 36);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(413, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(221, 277);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(198, 44);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(221, 327);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(198, 44);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FormEditarPublicacion
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 465);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMenuPrincipal);
            this.Controls.Add(this.lklCerrarSesion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPublicaciones);
            this.MaximizeBox = false;
            this.Name = "FormEditarPublicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormMenuEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMenuPrincipal;
        private System.Windows.Forms.LinkLabel lklCerrarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPublicaciones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbCategorias;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox ckbRangoFechas;
        private System.Windows.Forms.MonthCalendar mcrHasta;
        private System.Windows.Forms.MonthCalendar mcrDesde;
    }
}