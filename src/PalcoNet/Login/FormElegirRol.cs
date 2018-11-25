using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.Administrador;

namespace PalcoNet.Login
{
    public partial class FormElegirRol : Form
    {
        public FormElegirRol()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (rdbAdministrativo.Checked)
            {
                FormAdministrador formAdministrador = new FormAdministrador();
                this.Hide();
                formAdministrador.Show();
            }
        }
    }
}
