namespace PalcoNet.Comprar
{
    partial class FormComprarEntrada
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
            System.Windows.Forms.Button btnCosto;
            System.Windows.Forms.Button btnPremio;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.comboPremios = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ubicacionesListBox = new System.Windows.Forms.CheckedListBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            btnCosto = new System.Windows.Forms.Button();
            btnPremio = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCosto
            // 
            btnCosto.Location = new System.Drawing.Point(12, 273);
            btnCosto.Name = "btnCosto";
            btnCosto.Size = new System.Drawing.Size(359, 23);
            btnCosto.TabIndex = 20;
            btnCosto.Text = "Calcular Costo - Confirmar Ubicaciones";
            btnCosto.UseVisualStyleBackColor = true;
            btnCosto.Click += new System.EventHandler(this.btnCosto_Click);
            // 
            // btnPremio
            // 
            btnPremio.Location = new System.Drawing.Point(12, 357);
            btnPremio.Name = "btnPremio";
            btnPremio.Size = new System.Drawing.Size(359, 23);
            btnPremio.TabIndex = 22;
            btnPremio.Text = "Confirmar premio a usar";
            btnPremio.UseVisualStyleBackColor = true;
            btnPremio.Click += new System.EventHandler(this.btnPremio_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVolver);
            this.groupBox1.Controls.Add(this.comboPremios);
            this.groupBox1.Controls.Add(btnPremio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(btnCosto);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ubicacionesListBox);
            this.groupBox1.Controls.Add(this.btnPagar);
            this.groupBox1.Controls.Add(this.comboTipo);
            this.groupBox1.Controls.Add(this.lblUbicacion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 531);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comprar Entrada";
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(12, 474);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(359, 44);
            this.btnVolver.TabIndex = 24;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // comboPremios
            // 
            this.comboPremios.FormattingEnabled = true;
            this.comboPremios.Location = new System.Drawing.Point(12, 330);
            this.comboPremios.Name = "comboPremios";
            this.comboPremios.Size = new System.Drawing.Size(359, 21);
            this.comboPremios.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Premios";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(359, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ubicaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Monto total:";
            // 
            // ubicacionesListBox
            // 
            this.ubicacionesListBox.FormattingEnabled = true;
            this.ubicacionesListBox.Location = new System.Drawing.Point(12, 128);
            this.ubicacionesListBox.Name = "ubicacionesListBox";
            this.ubicacionesListBox.Size = new System.Drawing.Size(359, 139);
            this.ubicacionesListBox.TabIndex = 16;
            // 
            // btnPagar
            // 
            this.btnPagar.Enabled = false;
            this.btnPagar.Location = new System.Drawing.Point(12, 424);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(359, 44);
            this.btnPagar.TabIndex = 11;
            this.btnPagar.Text = "CONFIRMAR COMPRA";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(12, 46);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(359, 21);
            this.comboTipo.TabIndex = 6;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicacion.Location = new System.Drawing.Point(9, 26);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(122, 17);
            this.lblUbicacion.TabIndex = 5;
            this.lblUbicacion.Text = "Tipo de Ubicación";
            // 
            // FormComprarEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(406, 555);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormComprarEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox ubicacionesListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboPremios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolver;
    }
}