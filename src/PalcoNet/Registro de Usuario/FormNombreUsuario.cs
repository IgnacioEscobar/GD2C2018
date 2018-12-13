using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.funciones_utiles;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class FormNombreUsuario : Form
    {
        ValidadorDeDatos validador;

        public FormNombreUsuario()
        {
            InitializeComponent();
        }

        public string getNombreUsuario()
        {
            return txtNombreUsuario.Text;
        }

        private void FormNombreUsuario_Load(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = false;
            txtNombreUsuario.Select();
            validador = new ValidadorDeDatos();
        }

        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.alfanumerico(e);
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text.Length == 0)
            {
                btnConfirmar.Enabled = false;
            }
            else
            {
                btnConfirmar.Enabled = true;
            }
        }

    }
}
