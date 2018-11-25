using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Abm_Grado;
using PalcoNet.Abm_Rubro;
using PalcoNet.Abm_Rol;

namespace PalcoNet.Administrador
{
    public partial class FormAdministrador : Form
    {
        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void btnABMCliente_Click(object sender, EventArgs e)
        {
            FormABMCliente form = new FormABMCliente();
            this.Hide();
            form.Show();
        }

        private void btnABMEmpresa_Click(object sender, EventArgs e)
        {
            FormABMCliente form = new FormABMCliente();
            this.Hide();
            form.Show();
        }

        private void btnABMGrado_Click(object sender, EventArgs e)
        {
            FormABMGrado form = new FormABMGrado();
            this.Hide();
            form.Show();
        }

        private void btnABMRubro_Click(object sender, EventArgs e)
        {
            FormABMRubro form = new FormABMRubro();
            this.Hide();
            form.Show();
        }

        private void btnABMRol_Click(object sender, EventArgs e)
        {
            FormABMRol form = new FormABMRol();
            this.Hide();
            form.Show();
        }

    }
}
