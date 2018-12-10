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
using PalcoNet.Abm_Usuario;
using PalcoNet.Abm_Rubro;

namespace PalcoNet.Menu_Principal
{
    public partial class FormMenuAdministrador : Form
    {
        int userID;

        public FormMenuAdministrador(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormABMCliente formABMCliente = new FormABMCliente(userID, 1);
            this.Hide();
            formABMCliente.Show();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            FormABMEmpresa formABMEmpresa = new FormABMEmpresa(userID, 1);
            this.Hide();
            formABMEmpresa.Show();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            FormABMRol formABMRol = new FormABMRol(userID, 1);
            this.Hide();
            formABMRol.Show();
        }

        private void btnGrados_Click(object sender, EventArgs e)
        {
            FormABMGrado formABMGrado = new FormABMGrado(userID, 1);
            this.Hide();
            formABMGrado.Show();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormABMUsuario formABMUsuario = new FormABMUsuario(userID);
            this.Hide();
            formABMUsuario.Show();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FormABMRubro formABMRubro = new FormABMRubro(userID, 1);
            this.Hide();
            formABMRubro.Show();
        }

    }
}
