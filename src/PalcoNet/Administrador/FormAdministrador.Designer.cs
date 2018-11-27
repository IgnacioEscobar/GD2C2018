namespace PalcoNet.Administrador
{
    partial class FormAdministrador
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
            this.btnABMRol = new System.Windows.Forms.Button();
            this.btnABMEmpresa = new System.Windows.Forms.Button();
            this.btnABMRubro = new System.Windows.Forms.Button();
            this.btnABMGrado = new System.Windows.Forms.Button();
            this.btnABMCliente = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnABMRol);
            this.groupBox1.Controls.Add(this.btnABMEmpresa);
            this.groupBox1.Controls.Add(this.btnABMRubro);
            this.groupBox1.Controls.Add(this.btnABMGrado);
            this.groupBox1.Controls.Add(this.btnABMCliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administrador";
            // 
            // btnABMRol
            // 
            this.btnABMRol.Location = new System.Drawing.Point(208, 118);
            this.btnABMRol.Name = "btnABMRol";
            this.btnABMRol.Size = new System.Drawing.Size(95, 33);
            this.btnABMRol.TabIndex = 17;
            this.btnABMRol.Text = "ABM ROL";
            this.btnABMRol.UseVisualStyleBackColor = true;
            this.btnABMRol.Click += new System.EventHandler(this.btnABMRol_Click);
            // 
            // btnABMEmpresa
            // 
            this.btnABMEmpresa.Location = new System.Drawing.Point(6, 118);
            this.btnABMEmpresa.Name = "btnABMEmpresa";
            this.btnABMEmpresa.Size = new System.Drawing.Size(95, 33);
            this.btnABMEmpresa.TabIndex = 16;
            this.btnABMEmpresa.Text = "ABM EMPRESA";
            this.btnABMEmpresa.UseVisualStyleBackColor = true;
            this.btnABMEmpresa.Click += new System.EventHandler(this.btnABMEmpresa_Click);
            // 
            // btnABMRubro
            // 
            this.btnABMRubro.Location = new System.Drawing.Point(208, 19);
            this.btnABMRubro.Name = "btnABMRubro";
            this.btnABMRubro.Size = new System.Drawing.Size(95, 33);
            this.btnABMRubro.TabIndex = 4;
            this.btnABMRubro.Text = "ABM RUBRO";
            this.btnABMRubro.UseVisualStyleBackColor = true;
            this.btnABMRubro.Click += new System.EventHandler(this.btnABMRubro_Click);
            // 
            // btnABMGrado
            // 
            this.btnABMGrado.Location = new System.Drawing.Point(109, 66);
            this.btnABMGrado.Name = "btnABMGrado";
            this.btnABMGrado.Size = new System.Drawing.Size(95, 33);
            this.btnABMGrado.TabIndex = 3;
            this.btnABMGrado.Text = "ABM GRADO";
            this.btnABMGrado.UseVisualStyleBackColor = true;
            this.btnABMGrado.Click += new System.EventHandler(this.btnABMGrado_Click);
            // 
            // btnABMCliente
            // 
            this.btnABMCliente.Location = new System.Drawing.Point(6, 19);
            this.btnABMCliente.Name = "btnABMCliente";
            this.btnABMCliente.Size = new System.Drawing.Size(95, 33);
            this.btnABMCliente.TabIndex = 2;
            this.btnABMCliente.Text = "ABM CLIENTE";
            this.btnABMCliente.UseVisualStyleBackColor = true;
            this.btnABMCliente.Click += new System.EventHandler(this.btnABMCliente_Click);
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 180);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAdministrador";
            this.Text = "PalcoNet";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnABMCliente;
        private System.Windows.Forms.Button btnABMRol;
        private System.Windows.Forms.Button btnABMEmpresa;
        private System.Windows.Forms.Button btnABMRubro;
        private System.Windows.Forms.Button btnABMGrado;
    }
}