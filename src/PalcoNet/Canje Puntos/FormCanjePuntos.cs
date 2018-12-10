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

namespace PalcoNet.Canje_Puntos
{
    public partial class FormCanjePuntos : Form
    {
        int userID;
        int rolID;

        public FormCanjePuntos(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        private void FormCanjePuntos_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMiUsuario = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMiUsuario.Show();
        }
    }
}
