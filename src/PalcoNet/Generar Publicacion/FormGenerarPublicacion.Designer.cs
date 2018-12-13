namespace PalcoNet.Generar_Publicacion
{
    partial class FormGenerarPublicacion
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAno = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.nudHora = new System.Windows.Forms.NumericUpDown();
            this.nudMinuto = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.btnGuardarBorrador = new System.Windows.Forms.Button();
            this.btnFinalizarPublicacion = new System.Windows.Forms.Button();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.btnAgregarFecha = new System.Windows.Forms.Button();
            this.lsvFechaHora = new System.Windows.Forms.ListView();
            this.btnDefinirUbicaciones = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinuto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(12, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(403, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DESCRIPCIÓN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAno);
            this.groupBox1.Controls.Add(this.cmbMes);
            this.groupBox1.Controls.Add(this.cmbDia);
            this.groupBox1.Location = new System.Drawing.Point(200, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 47);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FECHA";
            // 
            // cmbAno
            // 
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.Location = new System.Drawing.Point(116, 19);
            this.cmbAno.MaxLength = 4;
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(93, 21);
            this.cmbAno.TabIndex = 5;
            this.cmbAno.Text = "Año";
            this.cmbAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAno_KeyPress);
            // 
            // cmbMes
            // 
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(61, 19);
            this.cmbMes.MaxLength = 2;
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(49, 21);
            this.cmbMes.TabIndex = 4;
            this.cmbMes.Text = "Mes";
            this.cmbMes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMes_KeyPress);
            // 
            // cmbDia
            // 
            this.cmbDia.FormattingEnabled = true;
            this.cmbDia.Location = new System.Drawing.Point(6, 19);
            this.cmbDia.MaxLength = 2;
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(49, 21);
            this.cmbDia.TabIndex = 3;
            this.cmbDia.Text = "Día";
            this.cmbDia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDia_KeyPress);
            // 
            // nudHora
            // 
            this.nudHora.Location = new System.Drawing.Point(7, 20);
            this.nudHora.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHora.Name = "nudHora";
            this.nudHora.Size = new System.Drawing.Size(49, 20);
            this.nudHora.TabIndex = 7;
            this.nudHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudHora_KeyPress);
            // 
            // nudMinuto
            // 
            this.nudMinuto.Location = new System.Drawing.Point(78, 20);
            this.nudMinuto.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMinuto.Name = "nudMinuto";
            this.nudMinuto.Size = new System.Drawing.Size(49, 20);
            this.nudMinuto.TabIndex = 8;
            this.nudMinuto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudMinuto_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nudHora);
            this.groupBox2.Controls.Add(this.nudMinuto);
            this.groupBox2.Location = new System.Drawing.Point(200, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 47);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HORA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = ":";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtAltura);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtCodigoPostal);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtLocalidad);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtCalle);
            this.groupBox3.Location = new System.Drawing.Point(12, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 97);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DIRECCIÓN";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(339, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Altura";
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(339, 32);
            this.txtAltura.MaxLength = 6;
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(58, 20);
            this.txtAltura.TabIndex = 12;
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAltura_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Código postal";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(6, 71);
            this.txtCodigoPostal.MaxLength = 4;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(89, 20);
            this.txtCodigoPostal.TabIndex = 13;
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodPostal_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(101, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocalidad.Location = new System.Drawing.Point(101, 71);
            this.txtLocalidad.MaxLength = 60;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(296, 20);
            this.txtLocalidad.TabIndex = 14;
            this.txtLocalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLocalidad_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Calle";
            // 
            // txtCalle
            // 
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalle.Location = new System.Drawing.Point(6, 32);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(327, 20);
            this.txtCalle.TabIndex = 11;
            this.txtCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalle_KeyPress);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbRubro);
            this.groupBox5.Location = new System.Drawing.Point(12, 264);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(238, 49);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RUBRO";
            // 
            // cmbRubro
            // 
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(7, 19);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(225, 21);
            this.cmbRubro.TabIndex = 16;
            // 
            // btnPublicar
            // 
            this.btnPublicar.Location = new System.Drawing.Point(12, 319);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(403, 42);
            this.btnPublicar.TabIndex = 18;
            this.btnPublicar.Text = "PUBLICAR";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // btnGuardarBorrador
            // 
            this.btnGuardarBorrador.Location = new System.Drawing.Point(12, 367);
            this.btnGuardarBorrador.Name = "btnGuardarBorrador";
            this.btnGuardarBorrador.Size = new System.Drawing.Size(238, 42);
            this.btnGuardarBorrador.TabIndex = 19;
            this.btnGuardarBorrador.Text = "GUARDAR BORRADOR";
            this.btnGuardarBorrador.UseVisualStyleBackColor = true;
            this.btnGuardarBorrador.Click += new System.EventHandler(this.btnGuardarBorrador_Click);
            // 
            // btnFinalizarPublicacion
            // 
            this.btnFinalizarPublicacion.Location = new System.Drawing.Point(256, 367);
            this.btnFinalizarPublicacion.Name = "btnFinalizarPublicacion";
            this.btnFinalizarPublicacion.Size = new System.Drawing.Size(159, 42);
            this.btnFinalizarPublicacion.TabIndex = 20;
            this.btnFinalizarPublicacion.Text = "FINALIZAR PUBLICACIÓN";
            this.btnFinalizarPublicacion.UseVisualStyleBackColor = true;
            this.btnFinalizarPublicacion.Click += new System.EventHandler(this.btnFinalizarPublicacion_Click);
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(12, 416);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(403, 23);
            this.btnMenuPrincipal.TabIndex = 21;
            this.btnMenuPrincipal.Text = "MENÚ PRINCIPAL";
            this.btnMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // btnAgregarFecha
            // 
            this.btnAgregarFecha.Location = new System.Drawing.Point(341, 108);
            this.btnAgregarFecha.Name = "btnAgregarFecha";
            this.btnAgregarFecha.Size = new System.Drawing.Size(74, 47);
            this.btnAgregarFecha.TabIndex = 9;
            this.btnAgregarFecha.Text = "AGREGAR FECHA";
            this.btnAgregarFecha.UseVisualStyleBackColor = true;
            this.btnAgregarFecha.Click += new System.EventHandler(this.btnAgregarFecha_Click);
            // 
            // lsvFechaHora
            // 
            this.lsvFechaHora.Location = new System.Drawing.Point(12, 55);
            this.lsvFechaHora.Name = "lsvFechaHora";
            this.lsvFechaHora.Size = new System.Drawing.Size(182, 100);
            this.lsvFechaHora.TabIndex = 18;
            this.lsvFechaHora.UseCompatibleStateImageBehavior = false;
            // 
            // btnDefinirUbicaciones
            // 
            this.btnDefinirUbicaciones.Location = new System.Drawing.Point(256, 271);
            this.btnDefinirUbicaciones.Name = "btnDefinirUbicaciones";
            this.btnDefinirUbicaciones.Size = new System.Drawing.Size(159, 42);
            this.btnDefinirUbicaciones.TabIndex = 17;
            this.btnDefinirUbicaciones.Text = "DEFINIR UBICACIONES";
            this.btnDefinirUbicaciones.UseVisualStyleBackColor = true;
            this.btnDefinirUbicaciones.Click += new System.EventHandler(this.btnDefinirUbicaciones_Click);
            // 
            // FormGenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnMenuPrincipal;
            this.ClientSize = new System.Drawing.Size(427, 451);
            this.Controls.Add(this.btnDefinirUbicaciones);
            this.Controls.Add(this.lsvFechaHora);
            this.Controls.Add(this.btnAgregarFecha);
            this.Controls.Add(this.btnMenuPrincipal);
            this.Controls.Add(this.btnFinalizarPublicacion);
            this.Controls.Add(this.btnGuardarBorrador);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.MaximizeBox = false;
            this.Name = "FormGenerarPublicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PalcoNet";
            this.Load += new System.EventHandler(this.FormGenerarPublicacion_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinuto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAno;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbDia;
        private System.Windows.Forms.NumericUpDown nudHora;
        private System.Windows.Forms.NumericUpDown nudMinuto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.Button btnGuardarBorrador;
        private System.Windows.Forms.Button btnFinalizarPublicacion;
        private System.Windows.Forms.Button btnMenuPrincipal;
        private System.Windows.Forms.Button btnAgregarFecha;
        private System.Windows.Forms.ListView lsvFechaHora;
        private System.Windows.Forms.Button btnDefinirUbicaciones;


    }
}