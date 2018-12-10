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
using PalcoNet.Abm_Usuario;
using PalcoNet.Historial_Cliente;
using PalcoNet.Comprar;

namespace PalcoNet.Menu_Principal
{
    public partial class FormMenuCliente : Form
    {
        int userID;
        string query_defecto;

        public FormMenuCliente(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        // Metodos auxiliares

        private void mostrarPublicaciones(SqlDataReader lector)
        {
            while (lector.Read())
            {
                ListViewItem item = new ListViewItem(lector["descripcion"].ToString());
                item.SubItems.Add(lector["stock"].ToString());
                DateTime fecha_hora = DateTime.Parse(lector["fecha_presentacion"].ToString());
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
            FormMiUsuario formMiUsuario = new FormMiUsuario(userID, true, false);
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
            lsvPublicaciones.View = View.Details;
            lsvPublicaciones.Columns.Add("DESCRIPCIÓN");
            lsvPublicaciones.Columns.Add("STOCK");
            lsvPublicaciones.Columns.Add("FECHA");
            lsvPublicaciones.Columns.Add("HORA");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            query_defecto = "SELECT ISNULL(PU.descripcion, '---') AS descripcion, " +
                "ISNULL(PU.stock, 0) AS stock, " +
                "PR.fecha_presentacion " +
                "FROM PEAKY_BLINDERS.publicaciones PU " +
                    "JOIN PEAKY_BLINDERS.presentaciones PR ON PU.id_publicacion = PR.id_publicacion " +
                    "JOIN PEAKY_BLINDERS.estados E ON PU.id_estado = E.id_estado ";
            string query_publicaciones = query_defecto +
                "WHERE PR.fecha_presentacion > GETDATE() AND E.descripcion = 'Publicada' " +
                "ORDER BY PR.fecha_presentacion ASC";
            gestor.consulta(query_publicaciones);
            this.mostrarPublicaciones(gestor.obtenerRegistros());
            gestor.desconectar();
            gestor.conectar();
            string query_categorias = "SELECT descripcion FROM PEAKY_BLINDERS.rubros";
            gestor.consulta(query_categorias);
            this.mostrarCategorias(gestor.obtenerRegistros());
            gestor.desconectar();

            txtDescripcion.Select();
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
            txtDescripcion.Select();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FormHistorialCliente formHistorialCliente = new FormHistorialCliente(userID, 2);
            this.Hide();
            formHistorialCliente.Show();
        }

        private void btnAdministracionPuntos_Click(object sender, EventArgs e)
        {
            FormAdministracionDePuntos formAdministracionDePuntos = new FormAdministracionDePuntos(userID);
            this.Hide();
            formAdministracionDePuntos.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lsvPublicaciones.Items.Clear();

            string condicion = "LEFT JOIN PEAKY_BLINDERS.rubros R ON PU.id_rubro = R.id_rubro " +
                "WHERE PR.fecha_presentacion > GETDATE() AND E.descripcion = 'Publicada' ";
            string descripcion = txtDescripcion.Text;

            if (descripcion != "")
            {
                condicion += "AND PU.descripcion LIKE '%" + descripcion + "%' ";
            }

            if (ckbRangoFechas.Checked)
            {
                condicion += "AND PR.fecha_presentacion BETWEEN '" + mcrDesde.SelectionStart.ToShortDateString() + "' AND '" + mcrHasta.SelectionStart.ToShortDateString() + "' ";
            }

            List<string> funcionalidades_tildadas = new List<string> {};
            for (int i = 0; i < clbCategorias.Items.Count; i++)
            {
                if (clbCategorias.GetItemChecked(i))
                {
                    funcionalidades_tildadas.Add(clbCategorias.Items[i].ToString());
                }
            }

            int cant_categorias_seleccionadas = funcionalidades_tildadas.Count;
            if (cant_categorias_seleccionadas > 0)
            {
                condicion += "AND ";
                for (int i = 0; i < cant_categorias_seleccionadas; i++)
                {
                    condicion += "R.descripcion = '" + funcionalidades_tildadas[i] + "' ";
                    if (i != cant_categorias_seleccionadas - 1)
                    {
                        condicion += "OR ";
                    }
                }
            }

            condicion += "ORDER BY PR.fecha_presentacion ASC";

            GestorDB gestor = new GestorDB();
            gestor.conectar();

            string query = query_defecto + condicion;
            gestor.consulta(query);
            this.mostrarPublicaciones(gestor.obtenerRegistros());
            gestor.desconectar();
        }

    }
}
