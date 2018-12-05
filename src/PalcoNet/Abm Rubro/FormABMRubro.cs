using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using PalcoNet.funciones_utiles;
using PalcoNet.Menu_Principal;

namespace PalcoNet.Abm_Rubro
{
    public partial class FormABMRubro : Form
    {
        int userID;
        ValidadorDeDatos validador;

        public FormABMRubro(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void FormABMRubro_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT id_publicacion, ISNULL(descripcion, '---') AS descripcion " +
                "FROM PEAKY_BLINDERS.publicaciones";
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();

            lsvPublicaciones.View = View.Details;
            lsvPublicaciones.Columns.Add("ID");
            lsvPublicaciones.Columns.Add("DESCRIPCIÓN");
            while (lector.Read())
            {
                ListViewItem item = new ListViewItem(lector["id_publicacion"].ToString());
                item.SubItems.Add(lector["descripcion"].ToString());
                lsvPublicaciones.Items.Add(item);
            }
            lsvPublicaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            gestor.desconectar();

            validador = new ValidadorDeDatos();
            txtIDPublicacion.Select();
        }

        private void btnPanelDeControl_Click(object sender, EventArgs e)
        {
            FormMenuAdministrador formMenuAdministrador = new FormMenuAdministrador(userID);
            this.Hide();
            formMenuAdministrador.Show();
        }

        private void txtIDPublicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }
    }
}
