namespace PalcoNet.Abm_Grado
{
    partial class FormABMGrado
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPublicaciones = new System.Windows.Forms.Label();
            this.lsbPublicaciones = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.rbnAlta = new System.Windows.Forms.RadioButton();
            this.rbnMedia = new System.Windows.Forms.RadioButton();
            this.rbnBaja = new System.Windows.Forms.RadioButton();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Grado de prioridad:";
            // 
            // lblPublicaciones
            // 
            this.lblPublicaciones.AutoSize = true;
            this.lblPublicaciones.Location = new System.Drawing.Point(12, 9);
            this.lblPublicaciones.Name = "lblPublicaciones";
            this.lblPublicaciones.Size = new System.Drawing.Size(76, 13);
            this.lblPublicaciones.TabIndex = 5;
            this.lblPublicaciones.Text = "Publicaciones:";
            // 
            // lsbPublicaciones
            // 
            this.lsbPublicaciones.FormattingEnabled = true;
            this.lsbPublicaciones.Location = new System.Drawing.Point(12, 25);
            this.lsbPublicaciones.Name = "lsbPublicaciones";
            this.lsbPublicaciones.Size = new System.Drawing.Size(203, 225);
            this.lsbPublicaciones.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(203, 44);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(221, 298);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(203, 44);
            this.btnAplicar.TabIndex = 10;
            this.btnAplicar.Text = "APLICAR";
            this.btnAplicar.UseVisualStyleBackColor = true;
            // 
            // rbnAlta
            // 
            this.rbnAlta.AutoSize = true;
            this.rbnAlta.Location = new System.Drawing.Point(343, 221);
            this.rbnAlta.Name = "rbnAlta";
            this.rbnAlta.Size = new System.Drawing.Size(52, 17);
            this.rbnAlta.TabIndex = 12;
            this.rbnAlta.TabStop = true;
            this.rbnAlta.Text = "ALTA";
            this.rbnAlta.UseVisualStyleBackColor = true;
            // 
            // rbnMedia
            // 
            this.rbnMedia.AutoSize = true;
            this.rbnMedia.Location = new System.Drawing.Point(343, 244);
            this.rbnMedia.Name = "rbnMedia";
            this.rbnMedia.Size = new System.Drawing.Size(59, 17);
            this.rbnMedia.TabIndex = 13;
            this.rbnMedia.TabStop = true;
            this.rbnMedia.Text = "MEDIA";
            this.rbnMedia.UseVisualStyleBackColor = true;
            // 
            // rbnBaja
            // 
            this.rbnBaja.AutoSize = true;
            this.rbnBaja.Location = new System.Drawing.Point(343, 267);
            this.rbnBaja.Name = "rbnBaja";
            this.rbnBaja.Size = new System.Drawing.Size(51, 17);
            this.rbnBaja.TabIndex = 14;
            this.rbnBaja.TabStop = true;
            this.rbnBaja.Text = "BAJA";
            this.rbnBaja.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(12, 256);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(203, 24);
            this.btnSeleccionar.TabIndex = 15;
            this.btnSeleccionar.Text = "SELECCIONAR";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Location = new System.Drawing.Point(222, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 186);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE BÚSQUEDA";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(6, 156);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(190, 24);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "FILTRAR";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // FormABMGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 354);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.rbnBaja);
            this.Controls.Add(this.rbnMedia);
            this.Controls.Add(this.rbnAlta);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPublicaciones);
            this.Controls.Add(this.lsbPublicaciones);
            this.MaximizeBox = false;
            this.Name = "FormABMGrado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPublicaciones;
        private System.Windows.Forms.ListBox lsbPublicaciones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.RadioButton rbnAlta;
        private System.Windows.Forms.RadioButton rbnMedia;
        private System.Windows.Forms.RadioButton rbnBaja;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltrar;

    }
}