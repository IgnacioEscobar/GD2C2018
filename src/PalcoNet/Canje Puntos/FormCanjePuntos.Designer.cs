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
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.lklCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.lsvPremiosCanjeados = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnMenuPrincipal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(242, 272);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(223, 42);
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
            this.lsvPremiosDisponibles.FullRowSelect = true;
            this.lsvPremiosDisponibles.Location = new System.Drawing.Point(13, 65);
            this.lsvPremiosDisponibles.MultiSelect = false;
            this.lsvPremiosDisponibles.Name = "lsvPremiosDisponibles";
            this.lsvPremiosDisponibles.Size = new System.Drawing.Size(223, 199);
            this.lsvPremiosDisponibles.TabIndex = 16;
            this.lsvPremiosDisponibles.UseCompatibleStateImageBehavior = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(13, 271);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(223, 42);
            this.btnSeleccionar.TabIndex = 19;
            this.btnSeleccionar.Text = "CANJEAR";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
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
            // lsvPremiosCanjeados
            // 
            this.lsvPremiosCanjeados.FullRowSelect = true;
            this.lsvPremiosCanjeados.Location = new System.Drawing.Point(242, 65);
            this.lsvPremiosCanjeados.MultiSelect = false;
            this.lsvPremiosCanjeados.Name = "lsvPremiosCanjeados";
            this.lsvPremiosCanjeados.Size = new System.Drawing.Size(223, 199);
            this.lsvPremiosCanjeados.TabIndex = 22;
            this.lsvPremiosCanjeados.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "PREMIOS CANJEADOS";
            // 
            // FormCanjePuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnMenuPrincipal;
            this.ClientSize = new System.Drawing.Size(470, 326);
            this.Controls.Add(this.lsvPremiosCanjeados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lklCerrarSesion);
            this.Controls.Add(this.btnSeleccionar);
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
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.LinkLabel lklCerrarSesion;
        private System.Windows.Forms.ListView lsvPremiosCanjeados;
        private System.Windows.Forms.Label label1;

    }
}