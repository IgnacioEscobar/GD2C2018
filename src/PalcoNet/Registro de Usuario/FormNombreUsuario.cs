using System;
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
    public partial class FormNombreUsuario : Form
    {
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
            txtNombreUsuario.Select();
        }

    }
}
