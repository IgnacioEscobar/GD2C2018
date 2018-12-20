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

using PalcoNet.Login;
using PalcoNet.funciones_utiles;
using PalcoNet.Menu_Principal;
using PalcoNet.Generar_Publicacion;

namespace PalcoNet.Abm_Grado
{
    public partial class FormABMGrado : Form
    {
        int userID;
        int rolID;
        string query_defecto;
        string query_actual;

        public FormABMGrado(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        // Metodos auxiliares

        private void agregarButtonColumn(string header)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = header;
            column.Text = "-->";
            column.UseColumnTextForButtonValue = true;
            dgvPublicaciones.Columns.Add(column);
        }

        private void mostrarPublicaciones(SqlDataReader lector)
        {
            dgvPublicaciones.Rows.Clear();
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["id_publicacion"].ToString(),
                    lector["descripcionP"].ToString(),
                    lector["descripcionE"].ToString(),
                    lector["descripcionG"].ToString(),
                };
                dgvPublicaciones.Rows.Add(row);
            }
        }

        public void actualizar()
        {
            dgvPublicaciones.Rows.Clear();

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(query_actual);
            this.mostrarPublicaciones(gestor.obtenerRegistros());
            gestor.desconectar();
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

        private void FormMenuEmpresa_Load(object sender, EventArgs e)
        {
            dgvPublicaciones.ColumnCount = 4;
            dgvPublicaciones.ColumnHeadersVisible = true;
            dgvPublicaciones.Columns[0].Name = "ID";
            dgvPublicaciones.Columns[0].Visible = false;
            dgvPublicaciones.Columns[1].Name = "DESCRIPCIÓN";
            dgvPublicaciones.Columns[2].Name = "ESTADO";
            dgvPublicaciones.Columns[3].Name = "GRADO";
            agregarButtonColumn("SELECCIONAR");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            query_defecto = "SELECT PU.id_publicacion, PU.descripcion AS descripcionP, " +
                    "E.descripcion AS descripcionE, G.descripcion AS descripcionG " +
                "FROM PEAKY_BLINDERS.publicaciones PU " +
                    "JOIN PEAKY_BLINDERS.estados E ON PU.id_estado = E.id_estado " +
                    "JOIN PEAKY_BLINDERS.grados G ON PU.id_grado = G.id_grado ";
            query_actual = query_defecto + "WHERE NOT E.descripcion = 'Finalizada' ORDER BY PU.id_publicacion ASC";
            gestor.consulta(query_actual);
            this.mostrarPublicaciones(gestor.obtenerRegistros());
            gestor.desconectar();

            gestor.conectar();
            string query_categorias = "SELECT descripcion FROM PEAKY_BLINDERS.rubros";
            gestor.consulta(query_categorias);
            this.mostrarCategorias(gestor.obtenerRegistros());
            gestor.desconectar();

            dgvPublicaciones.AutoResizeColumns();
            txtDescripcion.Select();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            mcrDesde.SetDate(Config.dateTime);
            mcrHasta.SetDate(Config.dateTime);
            for (int i = 0; i < clbCategorias.Items.Count; i++)
            {
                clbCategorias.SetItemChecked(i, false);
            }
            txtDescripcion.Select();
        }

        private void dgvPublicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                FormModificarGrado formModificarGrado = new FormModificarGrado(this, Convert.ToInt32(dgvPublicaciones.CurrentRow.Cells[0].Value), dgvPublicaciones.CurrentRow.Cells[3].Value.ToString());
                formModificarGrado.Show();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPublicaciones.Rows.Clear();

            string condicion = "JOIN PEAKY_BLINDERS.presentaciones PR ON PU.id_publicacion = PR.id_publicacion " +
                    "LEFT JOIN PEAKY_BLINDERS.rubros R ON PU.id_rubro = R.id_rubro " +
                "WHERE NOT E.descripcion = 'Finalizada' ";
            string descripcion = txtDescripcion.Text.Trim();

            if (descripcion != "")
            {
                condicion += "AND PU.descripcion LIKE '%" + descripcion + "%' ";
            }

            if (ckbRangoFechas.Checked)
            {
                condicion += "AND PR.fecha_presentacion BETWEEN '" + mcrDesde.SelectionStart.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND '" + mcrHasta.SelectionStart.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' ";
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

            condicion += "ORDER BY PR.fecha_presentacion ASC";

            GestorDB gestor = new GestorDB();
            gestor.conectar();

            query_actual = query_defecto + condicion;
            gestor.consulta(query_actual);
            this.mostrarPublicaciones(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMiUsuario = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMiUsuario.Show();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            mcrDesde.SetDate(Config.dateTime);
            mcrHasta.SetDate(Config.dateTime);
            for (int i = 0; i < clbCategorias.Items.Count; i++)
            {
                clbCategorias.SetItemChecked(i, false);
            }
            txtDescripcion.Select();
        }

    }
}
