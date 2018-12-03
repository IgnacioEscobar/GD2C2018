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

namespace PalcoNet.Abm_Grado
{
    public partial class FormABMGrado : Form
    {       
        int userID;

        public FormABMGrado(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void btnPanelDeControl_Click(object sender, EventArgs e)
        {
            FormMenuAdministrador formAbmAdministrador = new FormMenuAdministrador(userID);
            this.Hide();
            formAbmAdministrador.Show();
        }

    }
}
