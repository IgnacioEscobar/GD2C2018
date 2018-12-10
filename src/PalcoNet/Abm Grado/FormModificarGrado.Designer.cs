namespace PalcoNet.Abm_Grado
{
    partial class FormModificarGrado
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
            this.rdbAlto = new System.Windows.Forms.RadioButton();
            this.rdbMedio = new System.Windows.Forms.RadioButton();
            this.rdbBajo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbAlto
            // 
            this.rdbAlto.AutoSize = true;
            this.rdbAlto.Location = new System.Drawing.Point(12, 29);
            this.rdbAlto.Name = "rdbAlto";
            this.rdbAlto.Size = new System.Drawing.Size(53, 17);
            this.rdbAlto.TabIndex = 0;
            this.rdbAlto.TabStop = true;
            this.rdbAlto.Text = "ALTO";
            this.rdbAlto.UseVisualStyleBackColor = true;
            // 
            // rdbMedio
            // 
            this.rdbMedio.AutoSize = true;
            this.rdbMedio.Location = new System.Drawing.Point(12, 53);
            this.rdbMedio.Name = "rdbMedio";
            this.rdbMedio.Size = new System.Drawing.Size(60, 17);
            this.rdbMedio.TabIndex = 1;
            this.rdbMedio.TabStop = true;
            this.rdbMedio.Text = "MEDIO";
            this.rdbMedio.UseVisualStyleBackColor = true;
            // 
            // rdbBajo
            // 
            this.rdbBajo.AutoSize = true;
            this.rdbBajo.Location = new System.Drawing.Point(12, 77);
            this.rdbBajo.Name = "rdbBajo";
            this.rdbBajo.Size = new System.Drawing.Size(52, 17);
            this.rdbBajo.TabIndex = 2;
            this.rdbBajo.TabStop = true;
            this.rdbBajo.Text = "BAJO";
            this.rdbBajo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "GRADO DE PUBLICACIÓN:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(12, 101);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(260, 23);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 130);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(260, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormModificarGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 166);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbBajo);
            this.Controls.Add(this.rdbMedio);
            this.Controls.Add(this.rdbAlto);
            this.MaximizeBox = false;
            this.Name = "FormModificarGrado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormModificarGrado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbAlto;
        private System.Windows.Forms.RadioButton rdbMedio;
        private System.Windows.Forms.RadioButton rdbBajo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}