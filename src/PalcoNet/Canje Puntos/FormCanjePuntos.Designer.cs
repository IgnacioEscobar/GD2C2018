namespace PalcoNet.Canje_Puntos
{
    partial class FormCanjePuntos
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
            this.lblPuntosDisponibles = new System.Windows.Forms.Label();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvPremiosDisponibles = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.lsbCanjeados = new System.Windows.Forms.ListBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.lklCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblPuntosDisponibles
            // 
            this.lblPuntosDisponibles.AutoSize = true;
            this.lblPuntosDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntosDisponibles.Location = new System.Drawing.Point(13, 13);
            this.lblPuntosDisponibles.Name = "lblPuntosDisponibles";
            this.lblPuntosDisponibles.Size = new System.Drawing.Size(178, 16);
            this.lblPuntosDisponibles.TabIndex = 0;
            this.lblPuntosDisponibles.Text = "PUNTOS DISPONIBLES:";
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.Location = new System.Drawing.Point(283, 299);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(175, 42);
            this.btnMenuPrincipal.TabIndex = 14;
            this.btnMenuPrincipal.Text = "MENÚ PRINCIPAL";
            this.btnMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "PREMIOS PARA CANJEAR";
            // 
            // lsvPremiosDisponibles
            // 
            this.lsvPremiosDisponibles.Location = new System.Drawing.Point(13, 65);
            this.lsvPremiosDisponibles.Name = "lsvPremiosDisponibles";
            this.lsvPremiosDisponibles.Size = new System.Drawing.Size(264, 199);
            this.lsvPremiosDisponibles.TabIndex = 16;
            this.lsvPremiosDisponibles.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "PREMIOS CANJEADOS";
            // 
            // lsbCanjeados
            // 
            this.lsbCanjeados.FormattingEnabled = true;
            this.lsbCanjeados.Location = new System.Drawing.Point(283, 65);
            this.lsbCanjeados.Name = "lsbCanjeados";
            this.lsbCanjeados.Size = new System.Drawing.Size(175, 199);
            this.lsbCanjeados.TabIndex = 18;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(13, 271);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(264, 23);
            this.btnSeleccionar.TabIndex = 19;
            this.btnSeleccionar.Text = "CANJEAR";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // lklCerrarSesion
            // 
            this.lklCerrarSesion.AutoSize = true;
            this.lklCerrarSesion.Location = new System.Drawing.Point(363, 9);
            this.lklCerrarSesion.Name = "lklCerrarSesion";
            this.lklCerrarSesion.Size = new System.Drawing.Size(95, 13);
            this.lklCerrarSesion.TabIndex = 20;
            this.lklCerrarSesion.TabStop = true;
            this.lklCerrarSesion.Text = "CERRAR SESIÓN";
            this.lklCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklCerrarSesion_LinkClicked);
            // 
            // FormCanjePuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 353);
            this.Controls.Add(this.lklCerrarSesion);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.lsbCanjeados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lsvPremiosDisponibles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMenuPrincipal);
            this.Controls.Add(this.lblPuntosDisponibles);
            this.Name = "FormCanjePuntos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormCanjePuntos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPuntosDisponibles;
        private System.Windows.Forms.Button btnMenuPrincipal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvPremiosDisponibles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lsbCanjeados;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.LinkLabel lklCerrarSesion;

    }
}