using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.funciones_utiles;
using PalcoNet.Menu_Principal;

namespace PalcoNet.Comprar
{
    public partial class FormFiltrarEspectaculos : Form
    {

        int userID;
        int rolID;
        string query_defecto = "select PP.id_presentacion, P.descripcion, PP.fecha_presentacion from PEAKY_BLINDERS.presentaciones PP "
                + "join PEAKY_BLINDERS.publicaciones P on PP.id_publicacion = P.id_publicacion "
                + "join PEAKY_BLINDERS.estados E on P.id_estado = E.id_estado and E.descripcion = 'Publicada' "
                + "join PEAKY_BLINDERS.grados G on P.id_grado = G.id_grado ";
        GestorDB gestor = new GestorDB();
        List<string> categorias = new List<string>();


        public FormFiltrarEspectaculos(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        // Metodos auxiliares

        private void mostrarCategorias(SqlDataReader lector)
        {
            int i = 0;
            while (lector.Read())
            {
                clbCategorias.Items.Add(lector["descripcion"]);
                clbCategorias.SetItemChecked(i, true);
                this.categorias.Add(lector["id_rubro"].ToString());
                i++;
            }
        }

        private void agregarButtonColumn(string header)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = header;
            column.Text = "-->";
            column.UseColumnTextForButtonValue = true;
            dgvEspectaculos.Columns.Add(column);
        }

        private void mostrarPublicaciones(string query)
        {
            gestor.conectar();
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();

            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["id_presentacion"].ToString(),
                    lector["descripcion"].ToString(),
                    lector["fecha_presentacion"].ToString(),
                };
                dgvEspectaculos.Rows.Add(row);
            }

            gestor.desconectar();
        }

        // -------------------

        private void FormFiltrarEspectaculos_Load(object sender, EventArgs e)
        {
            dgvEspectaculos.ColumnCount = 3;
            dgvEspectaculos.ColumnHeadersVisible = true;
            dgvEspectaculos.Columns[0].Name = "ID";
            dgvEspectaculos.Columns[0].Visible = false;
            dgvEspectaculos.Columns[1].Name = "DESCRIPCIÓN";
            dgvEspectaculos.Columns[2].Name = "FECHA_PRESENTACION";
            agregarButtonColumn("SELECCIONAR");

            gestor.conectar();
            string query_categorias = "SELECT id_rubro, descripcion FROM PEAKY_BLINDERS.rubros";
            gestor.consulta(query_categorias);
            this.mostrarCategorias(gestor.obtenerRegistros());
            gestor.desconectar();

            string query_presentaciones = query_defecto + "where PP.fecha_vencimiento > GETDATE() and "
                    + "P.id_rubro in (" + String.Join(",", this.categorias.Select(x => x).ToArray()) + ") "
                // + "PP.fecha_presentacion > " + fechaInicio + " "
                // + "PP.fecha_presentacion < " + fechaFin + " "
                + "order by G.muliplicador desc, PP.fecha_presentacion asc";
            this.mostrarPublicaciones(query_presentaciones);
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEspectaculos.Rows.Clear();

            string condicion = "LEFT JOIN PEAKY_BLINDERS.rubros R ON P.id_rubro = R.id_rubro " +
                "WHERE PP.fecha_vencimiento >= GETDATE() ";
            string descripcion = txtDescripcion.Text;

            if (descripcion != "")
            {
                condicion += "AND P.descripcion LIKE '%" + descripcion + "%' ";
            }

            if (ckbRangoFechas.Checked)
            {
                condicion += "AND PP.fecha_presentacion BETWEEN '" + mcrDesde.SelectionStart.ToShortDateString() + "' AND '" + mcrHasta.SelectionStart.ToShortDateString() + "' ";
            }

            List<string> funcionalidades_tildadas = new List<string> { };
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
            else
            {
                condicion += "AND P.id_rubro = NULL ";
            }

            condicion += "order by G.muliplicador desc, PP.fecha_presentacion asc";

            string query_actual = query_defecto + condicion;
            dgvEspectaculos.Rows.Clear();
            this.mostrarPublicaciones(query_actual);
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

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void dgvEspectaculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                FormComprarEntrada formComprarEntrada = new FormComprarEntrada(userID, rolID, Convert.ToInt32(dgvEspectaculos.CurrentRow.Cells[0].Value));
                this.Hide();
                formComprarEntrada.Show();
            }
        }

    }
}
