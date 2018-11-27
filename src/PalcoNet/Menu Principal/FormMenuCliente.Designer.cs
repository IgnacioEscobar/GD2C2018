namespace PalcoNet.Menu_Principal
{
    partial class FormMenuCliente
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
            this.lsbEspectaculos = new System.Windows.Forms.ListBox();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnPuntos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.clbCategorias = new System.Windows.Forms.CheckedListBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.mcrDesde = new System.Windows.Forms.MonthCalendar();
            this.mcrHasta = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbEspectaculos
            // 
            this.lsbEspectaculos.FormattingEnabled = true;
            this.lsbEspectaculos.Location = new System.Drawing.Point(11, 87);
            this.lsbEspectaculos.Name = "lsbEspectaculos";
            this.lsbEspectaculos.Size = new System.Drawing.Size(312, 329);
            this.lsbEspectaculos.TabIndex = 0;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(306, 12);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(221, 44);
            this.btnHistorial.TabIndex = 6;
            this.btnHistorial.Text = "HISTORIAL DE COMPRAS";
            this.btnHistorial.UseVisualStyleBackColor = true;
            // 
            // btnPuntos
            // 
            this.btnPuntos.Location = new System.Drawing.Point(533, 12);
            this.btnPuntos.Name = "btnPuntos";
            this.btnPuntos.Size = new System.Drawing.Size(221, 44);
            this.btnPuntos.TabIndex = 7;
            this.btnPuntos.Text = "ADMINISTRACIÓN DE PUNTOS";
            this.btnPuntos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "ESPECTÁCULOS DISPONIBLES";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mcrHasta);
            this.groupBox1.Controls.Add(this.clbCategorias);
            this.groupBox1.Controls.Add(this.mcrDesde);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Location = new System.Drawing.Point(329, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 377);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE BÚSQUEDA";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(221, 277);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(198, 44);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(221, 327);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(198, 44);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // clbCategorias
            // 
            this.clbCategorias.FormattingEnabled = true;
            this.clbCategorias.Location = new System.Drawing.Point(6, 277);
            this.clbCategorias.Name = "clbCategorias";
            this.clbCategorias.Size = new System.Drawing.Size(209, 94);
            this.clbCategorias.TabIndex = 10;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(6, 36);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(413, 20);
            this.txtDescripcion.TabIndex = 11;
            // 
            // mcrDesde
            // 
            this.mcrDesde.Location = new System.Drawing.Point(12, 90);
            this.mcrDesde.Name = "mcrDesde";
            this.mcrDesde.TabIndex = 12;
            // 
            // mcrHasta
            // 
            this.mcrHasta.Location = new System.Drawing.Point(222, 90);
            this.mcrHasta.MaxSelectionCount = 1;
            this.mcrHasta.Name = "mcrHasta";
            this.mcrHasta.TabIndex = 13;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Rango de fechas";
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
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(11, 420);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(312, 44);
            this.btnSeleccionar.TabIndex = 10;
            this.btnSeleccionar.Text = "SELECCIONAR";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // FormMenuCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 475);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPuntos);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.lsbEspectaculos);
            this.Name = "FormMenuCliente";
            this.Text = "PalcoNet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbEspectaculos;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnPuntos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar mcrHasta;
        private System.Windows.Forms.MonthCalendar mcrDesde;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckedListBox clbCategorias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}