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
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lklCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.labelMes = new System.Windows.Forms.Label();
            this.comboMes = new System.Windows.Forms.ComboBox();
            this.labelGrado = new System.Windows.Forms.Label();
            this.comboGrado = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(250, 74);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(156, 21);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cmbConsulta
            // 
            this.cmbConsulta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbConsulta.FormattingEnabled = true;
            this.cmbConsulta.Location = new System.Drawing.Point(12, 34);
            this.cmbConsulta.Name = "cmbConsulta";
            this.cmbConsulta.Size = new System.Drawing.Size(395, 21);
            this.cmbConsulta.TabIndex = 0;
            this.cmbConsulta.SelectedIndexChanged += new System.EventHandler(this.cmbConsulta_SelectedIndexChanged);
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Location = new System.Drawing.Point(131, 74);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(113, 21);
            this.cmbTrimestre.TabIndex = 2;
            this.cmbTrimestre.SelectedIndexChanged += new System.EventHandler(this.cmbTrimestre_SelectedIndexChanged);
            // 
            // cmbAno
            // 
            this.cmbAno.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.Location = new System.Drawing.Point(12, 74);
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(113, 21);
            this.cmbAno.TabIndex = 1;
            // 
            // lsvConsulta
            // 
            this.lsvConsulta.Location = new System.Drawing.Point(12, 189);
            this.lsvConsulta.Name = "lsvConsulta";
            this.lsvConsulta.Size = new System.Drawing.Size(394, 335);
            this.lsvConsulta.TabIndex = 5;
            this.lsvConsulta.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "LISTADO";
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(12, 530);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(394, 21);
            this.btnMenuPrincipal.TabIndex = 4;
            this.btnMenuPrincipal.Text = "MENÚ PRINCIPAL";
            this.btnMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Consulta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Año";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Trimestre";
            // 
            // lklCerrarSesion
            // 
            this.lklCerrarSesion.AutoSize = true;
            this.lklCerrarSesion.Location = new System.Drawing.Point(312, 9);
            this.lklCerrarSesion.Name = "lklCerrarSesion";
            this.lklCerrarSesion.Size = new System.Drawing.Size(95, 13);
            this.lklCerrarSesion.TabIndex = 16;
            this.lklCerrarSesion.TabStop = true;
            this.lklCerrarSesion.Text = "CERRAR SESIÓN";
            this.lklCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklCerrarSesion_LinkClicked);
            // 
            // labelMes
            // 
            this.labelMes.AutoSize = true;
            this.labelMes.Location = new System.Drawing.Point(131, 105);
            this.labelMes.Name = "labelMes";
            this.labelMes.Size = new System.Drawing.Size(27, 13);
            this.labelMes.TabIndex = 18;
            this.labelMes.Text = "Mes";
            this.labelMes.UseWaitCursor = true;
            this.labelMes.Click += new System.EventHandler(this.label5_Click);
            // 
            // comboMes
            // 
            this.comboMes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboMes.FormattingEnabled = true;
            this.comboMes.Location = new System.Drawing.Point(131, 121);
            this.comboMes.Name = "comboMes";
            this.comboMes.Size = new System.Drawing.Size(113, 21);
            this.comboMes.TabIndex = 17;
            this.comboMes.SelectedIndexChanged += new System.EventHandler(this.cmbConsulta_SelectedIndexChanged);
            // 
            // labelGrado
            // 
            this.labelGrado.AutoSize = true;
            this.labelGrado.Location = new System.Drawing.Point(12, 105);
            this.labelGrado.Name = "labelGrado";
            this.labelGrado.Size = new System.Drawing.Size(36, 13);
            this.labelGrado.TabIndex = 20;
            this.labelGrado.Text = "Grado";
            this.labelGrado.UseWaitCursor = true;
            // 
            // comboGrado
            // 
            this.comboGrado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboGrado.FormattingEnabled = true;
            this.comboGrado.Location = new System.Drawing.Point(12, 121);
            this.comboGrado.Name = "comboGrado";
            this.comboGrado.Size = new System.Drawing.Size(113, 21);
            this.comboGrado.TabIndex = 19;
            // 
            // FormListadoEstadistico
            // 
            this.AcceptButton = this.btnConsultar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnMenuPrincipal;
            this.ClientSize = new System.Drawing.Size(419, 563);
            this.Controls.Add(this.labelGrado);
            this.Controls.Add(this.comboGrado);
            this.Controls.Add(this.labelMes);
            this.Controls.Add(this.comboMes);
            this.Controls.Add(this.lklCerrarSesion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMenuPrincipal);
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
        private System.Windows.Forms.Button btnMenuPrincipal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lklCerrarSesion;
        private System.Windows.Forms.Label labelMes;
        private System.Windows.Forms.ComboBox comboMes;
        private System.Windows.Forms.Label labelGrado;
        private System.Windows.Forms.ComboBox comboGrado;
    }
}