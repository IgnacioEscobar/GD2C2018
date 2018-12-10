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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCantEntradas = new System.Windows.Forms.Button();
            this.btnUbicacion = new System.Windows.Forms.Button();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.comboBoxUbicacion = new System.Windows.Forms.ComboBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numericBtn = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCantEntradas);
            this.groupBox1.Controls.Add(this.btnUbicacion);
            this.groupBox1.Controls.Add(this.lblMontoTotal);
            this.groupBox1.Controls.Add(this.btnPagar);
            this.groupBox1.Controls.Add(this.comboBoxUbicacion);
            this.groupBox1.Controls.Add(this.lblUbicacion);
            this.groupBox1.Controls.Add(this.numericBtn);
            this.groupBox1.Controls.Add(this.lblCantidad);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comprar Entrada";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCantEntradas
            // 
            this.btnCantEntradas.Location = new System.Drawing.Point(198, 72);
            this.btnCantEntradas.Name = "btnCantEntradas";
            this.btnCantEntradas.Size = new System.Drawing.Size(173, 23);
            this.btnCantEntradas.TabIndex = 16;
            this.btnCantEntradas.Text = "Confirmar";
            this.btnCantEntradas.UseVisualStyleBackColor = true;
            this.btnCantEntradas.Click += new System.EventHandler(this.btnCantEntradas_Click);
            // 
            // btnUbicacion
            // 
            this.btnUbicacion.Location = new System.Drawing.Point(12, 73);
            this.btnUbicacion.Name = "btnUbicacion";
            this.btnUbicacion.Size = new System.Drawing.Size(173, 23);
            this.btnUbicacion.TabIndex = 15;
            this.btnUbicacion.Text = "Confirmar";
            this.btnUbicacion.UseVisualStyleBackColor = true;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(8, 116);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(101, 24);
            this.lblMontoTotal.TabIndex = 12;
            this.lblMontoTotal.Text = "Monto total";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(12, 152);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(359, 44);
            this.btnPagar.TabIndex = 11;
            this.btnPagar.Text = "PROCEDER AL PAGO";
            this.btnPagar.UseVisualStyleBackColor = true;
            // 
            // comboBoxUbicacion
            // 
            this.comboBoxUbicacion.FormattingEnabled = true;
            this.comboBoxUbicacion.Location = new System.Drawing.Point(12, 46);
            this.comboBoxUbicacion.Name = "comboBoxUbicacion";
            this.comboBoxUbicacion.Size = new System.Drawing.Size(173, 21);
            this.comboBoxUbicacion.TabIndex = 6;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicacion.Location = new System.Drawing.Point(9, 26);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(70, 17);
            this.lblUbicacion.TabIndex = 5;
            this.lblUbicacion.Text = "Ubicacion";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(195, 26);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(145, 17);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad de Entradas";
            this.lblCantidad.Click += new System.EventHandler(this.lblCantidad_Click);
            // 
            // numericBtn
            // 
            this.numericBtn.Location = new System.Drawing.Point(198, 46);
            this.numericBtn.Name = "numericBtn";
            this.numericBtn.Size = new System.Drawing.Size(173, 20);
            this.numericBtn.TabIndex = 4;
            this.numericBtn.ValueChanged += new System.EventHandler(this.numericBtn_ValueChanged);
            // 
            // FormComprarEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 236);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormComprarEntrada";
            this.Text = "PalcoNet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.ComboBox comboBoxUbicacion;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnCantEntradas;
        private System.Windows.Forms.Button btnUbicacion;
        private System.Windows.Forms.NumericUpDown numericBtn;
    }
}