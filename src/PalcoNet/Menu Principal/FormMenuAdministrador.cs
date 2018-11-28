using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.Login;
using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Abm_Rol;
using PalcoNet.Abm_Grado;

namespace PalcoNet.Menu_Principal
{
    public partial class FormMenuAdministrador : Form
    {
        public FormMenuAdministrador()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormABMCliente formABMCliente = new FormABMCliente();
            this.Hide();
            formABMCliente.Show();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            FormABMEmpresa formABMEmpresa = new FormABMEmpresa();
            this.Hide();
            formABMEmpresa.Show();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            FormABMRol formABMRol = new FormABMRol();
            this.Hide();
            formABMRol.Show();
        }

        private void btnGrados_Click(object sender, EventArgs e)
        {
            FormABMGrado formABMGrado = new FormABMGrado();
            this.Hide();
            formABMGrado.Show();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

    }
}
