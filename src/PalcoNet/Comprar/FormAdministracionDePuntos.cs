using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.Menu_Principal;

namespace PalcoNet.Comprar
{
    public partial class FormAdministracionDePuntos : Form
    {
        int userID;

        public FormAdministracionDePuntos(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuCliente formMenuCliente = new FormMenuCliente(userID);
            this.Hide();
            formMenuCliente.Show();
        }

        private void FormAdministracionDePuntos_Load(object sender, EventArgs e)
        {
            MessageBox.Show("NO HAY DE DONDE SACAR LOS PUNTOS DEL USUARIO");
        }
    }
}
