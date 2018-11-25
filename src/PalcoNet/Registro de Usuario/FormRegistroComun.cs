﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class FormRegistroComun : Form
    {
        public FormRegistroComun()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Form proximoForm;
            if (rbnCliente.Checked)
            {
                proximoForm = new FormRegistroCliente(false);
            }
            else
            {
                proximoForm = new FormRegistroEmpresa(false);
            }

            this.Hide();
            proximoForm.Show();
        }

        private void FormRegistroComun_Load(object sender, EventArgs e)
        {

        }
    }
}