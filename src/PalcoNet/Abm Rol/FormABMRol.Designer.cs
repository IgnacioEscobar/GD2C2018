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
            this.clbFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbHabilitado = new System.Windows.Forms.CheckBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnPanelDeControl = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.lsbRoles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ROLES";
            // 
            // clbFuncionalidades
            // 
            this.clbFuncionalidades.FormattingEnabled = true;
            this.clbFuncionalidades.Location = new System.Drawing.Point(221, 25);
            this.clbFuncionalidades.Name = "clbFuncionalidades";
            this.clbFuncionalidades.Size = new System.Drawing.Size(203, 184);
            this.clbFuncionalidades.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "FUNCIONALIDADES";
            // 
            // ckbHabilitado
            // 
            this.ckbHabilitado.AutoSize = true;
            this.ckbHabilitado.Location = new System.Drawing.Point(15, 215);
            this.ckbHabilitado.Name = "ckbHabilitado";
            this.ckbHabilitado.Size = new System.Drawing.Size(115, 17);
            this.ckbHabilitado.TabIndex = 5;
            this.ckbHabilitado.Text = "ROL HABILITADO";
            this.ckbHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(12, 185);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(203, 24);
            this.btnSeleccionar.TabIndex = 6;
            this.btnSeleccionar.Text = "SELECCIONAR";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnPanelDeControl
            // 
            this.btnPanelDeControl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPanelDeControl.Location = new System.Drawing.Point(12, 245);
            this.btnPanelDeControl.Name = "btnPanelDeControl";
            this.btnPanelDeControl.Size = new System.Drawing.Size(203, 44);
            this.btnPanelDeControl.TabIndex = 9;
            this.btnPanelDeControl.Text = "PANEL DE CONTROL";
            this.btnPanelDeControl.UseVisualStyleBackColor = true;
            this.btnPanelDeControl.Click += new System.EventHandler(this.btnPanelDeControl_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(221, 245);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(203, 44);
            this.btnAplicar.TabIndex = 8;
            this.btnAplicar.Text = "APLICAR";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // lsbRoles
            // 
            this.lsbRoles.FormattingEnabled = true;
            this.lsbRoles.Location = new System.Drawing.Point(12, 25);
            this.lsbRoles.Name = "lsbRoles";
            this.lsbRoles.Size = new System.Drawing.Size(203, 160);
            this.lsbRoles.TabIndex = 10;
            // 
            // FormABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnPanelDeControl;
            this.ClientSize = new System.Drawing.Size(436, 301);
            this.Controls.Add(this.lsbRoles);
            this.Controls.Add(this.btnPanelDeControl);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.ckbHabilitado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clbFuncionalidades);
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
        private System.Windows.Forms.CheckedListBox clbFuncionalidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbHabilitado;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnPanelDeControl;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.ListBox lsbRoles;
    }
}