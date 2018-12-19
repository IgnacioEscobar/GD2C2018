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
        int rolID;
        ValidadorDeDatos validador;

        public FormABMRubro(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        private void FormABMRubro_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT PU.id_publicacion, " +
                    "ISNULL(PU.descripcion, '---') AS descripcionP, " +
                    "ISNULL(R.descripcion, '---') AS descripcionR " +
                "FROM PEAKY_BLINDERS.publicaciones PU " +
                    "JOIN PEAKY_BLINDERS.presentaciones PR ON PU.id_publicacion = PR.id_publicacion " +
                    "LEFT JOIN PEAKY_BLINDERS.rubros R ON PU.id_rubro = R.id_rubro " +
                "WHERE PR.fecha_presentacion >= " + Config.date + " ORDER BY PU.id_publicacion ASC";
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();

            lsvPublicaciones.View = View.Details;
            lsvPublicaciones.Columns.Add("ID");
            lsvPublicaciones.Columns.Add("DESCRIPCIÓN");
            lsvPublicaciones.Columns.Add("CATEGORÍA");
            while (lector.Read())
            {
                ListViewItem item = new ListViewItem(lector["id_publicacion"].ToString());
                item.SubItems.Add(lector["descripcionP"].ToString());
                item.SubItems.Add(lector["descripcionR"].ToString());
                lsvPublicaciones.Items.Add(item);
            }
            lsvPublicaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            gestor.desconectar();

            gestor.conectar();
            string query2 = "SELECT descripcion FROM PEAKY_BLINDERS.rubros";
            gestor.consulta(query2);
            SqlDataReader lector2 = gestor.obtenerRegistros();
            while (lector2.Read())
            {
                cmbCategoria.Items.Add(lector2["descripcion"]);
            }
            gestor.desconectar();

            validador = new ValidadorDeDatos();
            txtIDPublicacion.Select();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formDestino = new FormLogin();
            this.Hide();
            formDestino.Show();
        }

        private void txtIDPublicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

    }
}
