namespace PalcoNet.Listado_Estadistico
{
    partial class FormListadoEstadistico
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
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cmbConsulta = new System.Windows.Forms.ComboBox();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.cmbAno = new System.Windows.Forms.ComboBox();
            this.lsvConsulta = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(250, 39);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(156, 21);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.UseVisualStyleBackColor = true;
            // 
            // cmbConsulta
            // 
            this.cmbConsulta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbConsulta.FormattingEnabled = true;
            this.cmbConsulta.Location = new System.Drawing.Point(12, 12);
            this.cmbConsulta.Name = "cmbConsulta";
            this.cmbConsulta.Size = new System.Drawing.Size(394, 21);
            this.cmbConsulta.TabIndex = 2;
            this.cmbConsulta.Text = "CONSULTA";
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Location = new System.Drawing.Point(131, 39);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(113, 21);
            this.cmbTrimestre.TabIndex = 1;
            this.cmbTrimestre.Text = "TRIMESTRE";
            // 
            // cmbAno
            // 
            this.cmbAno.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.Location = new System.Drawing.Point(12, 39);
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(113, 21);
            this.cmbAno.TabIndex = 0;
            this.cmbAno.Text = "AÑO";
            // 
            // lsvConsulta
            // 
            this.lsvConsulta.Location = new System.Drawing.Point(12, 89);
            this.lsvConsulta.Name = "lsvConsulta";
            this.lsvConsulta.Size = new System.Drawing.Size(394, 391);
            this.lsvConsulta.TabIndex = 5;
            this.lsvConsulta.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "LISTADO";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(12, 486);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(394, 21);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FormListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(418, 520);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsvConsulta);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cmbAno);
            this.Controls.Add(this.cmbConsulta);
            this.Controls.Add(this.cmbTrimestre);
            this.MaximizeBox = false;
            this.Name = "FormListadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormListado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox cmbConsulta;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.ComboBox cmbAno;
        private System.Windows.Forms.ListView lsvConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
    }
}