namespace PalcoNet.Comprar
{
    partial class FormPagar
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
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.textBoxCSV = new System.Windows.Forms.TextBox();
            this.comboBoxAnio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSiguiente);
            this.groupBox1.Controls.Add(this.textBoxCSV);
            this.groupBox1.Controls.Add(this.comboBoxAnio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxMes);
            this.groupBox1.Controls.Add(this.textBoxNum);
            this.groupBox1.Controls.Add(this.Nombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Realizar Pago";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(7, 148);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(139, 44);
            this.btnSiguiente.TabIndex = 8;
            this.btnSiguiente.Text = "PAGAR";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // textBoxCSV
            // 
            this.textBoxCSV.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxCSV.Location = new System.Drawing.Point(7, 113);
            this.textBoxCSV.Name = "textBoxCSV";
            this.textBoxCSV.Size = new System.Drawing.Size(53, 20);
            this.textBoxCSV.TabIndex = 7;
            this.textBoxCSV.Text = "CSV";
            // 
            // comboBoxAnio
            // 
            this.comboBoxAnio.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.comboBoxAnio.FormattingEnabled = true;
            this.comboBoxAnio.Location = new System.Drawing.Point(92, 85);
            this.comboBoxAnio.Name = "comboBoxAnio";
            this.comboBoxAnio.Size = new System.Drawing.Size(54, 21);
            this.comboBoxAnio.TabIndex = 6;
            this.comboBoxAnio.Text = "YYYY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(72, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "/";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Location = new System.Drawing.Point(6, 85);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxMes.Size = new System.Drawing.Size(54, 21);
            this.comboBoxMes.TabIndex = 4;
            this.comboBoxMes.Text = "MM";
            // 
            // textBoxNum
            // 
            this.textBoxNum.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxNum.Location = new System.Drawing.Point(6, 54);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(196, 20);
            this.textBoxNum.TabIndex = 3;
            this.textBoxNum.Text = "Numero de tarjeta";
            // 
            // Nombre
            // 
            this.Nombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Nombre.Location = new System.Drawing.Point(6, 19);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(199, 20);
            this.Nombre.TabIndex = 0;
            this.Nombre.Text = "Nombre y Apellido";
            // 
            // FormPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 239);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPagar";
            this.Text = "Pagar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.ComboBox comboBoxAnio;
        private System.Windows.Forms.TextBox textBoxCSV;
        private System.Windows.Forms.Button btnSiguiente;
    }
}