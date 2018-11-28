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
using PalcoNet.ABM_Usuario;

namespace PalcoNet.Menu_Principal
{
    public partial class FormMenuCliente : Form
    {
        public FormMenuCliente()
        {
            InitializeComponent();
        }

        private void btnConfiguración_Click(object sender, EventArgs e)
        {
            FormMiUsuario formMiUsuario = new FormMiUsuario();
            this.Hide();
            formMiUsuario.Show();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }
    }
}
