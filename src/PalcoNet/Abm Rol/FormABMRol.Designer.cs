namespace PalcoNet.Abm_Rol
{
    partial class FormABMRol
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
            this.lsvRoles = new System.Windows.Forms.ListView();
            this.clbFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbActivo = new System.Windows.Forms.CheckBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Roles:";
            // 
            // lsvRoles
            // 
            this.lsvRoles.Location = new System.Drawing.Point(12, 25);
            this.lsvRoles.Name = "lsvRoles";
            this.lsvRoles.Size = new System.Drawing.Size(203, 142);
            this.lsvRoles.TabIndex = 2;
            this.lsvRoles.UseCompatibleStateImageBehavior = false;
            // 
            // clbFuncionalidades
            // 
            this.clbFuncionalidades.FormattingEnabled = true;
            this.clbFuncionalidades.Location = new System.Drawing.Point(221, 25);
            this.clbFuncionalidades.Name = "clbFuncionalidades";
            this.clbFuncionalidades.Size = new System.Drawing.Size(203, 169);
            this.clbFuncionalidades.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Funcionalidades activas:";
            // 
            // ckbActivo
            // 
            this.ckbActivo.AutoSize = true;
            this.ckbActivo.Location = new System.Drawing.Point(12, 200);
            this.ckbActivo.Name = "ckbActivo";
            this.ckbActivo.Size = new System.Drawing.Size(90, 17);
            this.ckbActivo.TabIndex = 5;
            this.ckbActivo.Text = "ROL ACTIVO";
            this.ckbActivo.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(12, 170);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(203, 24);
            this.btnSeleccionar.TabIndex = 6;
            this.btnSeleccionar.Text = "SELECCIONAR";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 245);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(203, 44);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(221, 245);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(203, 44);
            this.btnAplicar.TabIndex = 8;
            this.btnAplicar.Text = "APLICAR";
            this.btnAplicar.UseVisualStyleBackColor = true;
            // 
            // FormABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 301);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.ckbActivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clbFuncionalidades);
            this.Controls.Add(this.lsvRoles);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FormABMRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormABMRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvRoles;
        private System.Windows.Forms.CheckedListBox clbFuncionalidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbActivo;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
    }
}