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

        // Metodos auxiliares

        private void mostrarPublicaciones(SqlDataReader lector)
        {
            lsvPublicaciones.View = View.Details;
            lsvPublicaciones.Columns.Add("DESCRIPCIÓN");
            lsvPublicaciones.Columns.Add("STOCK");
            lsvPublicaciones.Columns.Add("FECHA");
            lsvPublicaciones.Columns.Add("HORA");
            while (lector.Read())
            {
                ListViewItem item = new ListViewItem(lector["descripcion"].ToString());
                item.SubItems.Add(lector["stock"].ToString());
                DateTime fecha_hora = DateTime.Parse(lector["fecha_hora"].ToString());
                item.SubItems.Add(fecha_hora.ToShortDateString());
                item.SubItems.Add(fecha_hora.ToShortTimeString());
                lsvPublicaciones.Items.Add(item);
            }
            lsvPublicaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void mostrarCategorias(SqlDataReader lector)
        {
            int i = 0;
            while (lector.Read())
            {
                clbCategorias.Items.Add(lector["descripcion"]);
                clbCategorias.SetItemChecked(i, true);
                i++;
            }
        }

        // -------------------

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

        private void FormMenuCliente_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query_publicaciones = "SELECT ISNULL(PU.descripcion, '---') AS descripcion, " +
                "ISNULL(PU.stock, 0) AS stock, " +
                "PR.fecha_hora " +
                "FROM PEAKY_BLINDERS.publicaciones PU " +
                    "JOIN PEAKY_BLINDERS.presentaciones PR ON PU.id_publicacion = PR.id_publicacion";
            gestor.consulta(query_publicaciones);
            this.mostrarPublicaciones(gestor.obtenerRegistros());
            gestor.desconectar();
            gestor.conectar();
            string query_categorias = "SELECT descripcion FROM PEAKY_BLINDERS.rubros";
            gestor.consulta(query_categorias);
            this.mostrarCategorias(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            mcrDesde.SetDate(DateTime.Today);
            mcrHasta.SetDate(DateTime.Today);
            for (int i = 0; i < clbCategorias.Items.Count; i++)
            {
                clbCategorias.SetItemChecked(i, false);
            }
        }
    }
}
