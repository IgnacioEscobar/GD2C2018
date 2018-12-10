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
using PalcoNet.Abm_Usuario;
using PalcoNet.Generar_Publicacion;

namespace PalcoNet.Menu_Principal
{
    public partial class FormMenuEmpresa : Form
    {
        int userID;
        int empresaID;
        string query_defecto;

        public FormMenuEmpresa(int userID)
        {
            InitializeComponent();
            this.userID = userID;
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
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["id_publicacion"].ToString(),
                    lector["descripcionP"].ToString(),
                    lector["descripcionE"].ToString(),
                    lector["muliplicador"].ToString(),
                };
                dgvPublicaciones.Rows.Add(row);
            }
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
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT id_empresa FROM PEAKY_BLINDERS.empresas WHERE id_usuario = '" + userID + "'";
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            if (lector.Read())
            {
                this.empresaID = Convert.ToInt32(lector["id_empresa"]);
            }
            gestor.desconectar();

            dgvPublicaciones.ColumnCount = 4;
            dgvPublicaciones.ColumnHeadersVisible = true;
            dgvPublicaciones.Columns[0].Name = "ID";
            dgvPublicaciones.Columns[0].Visible = false;
            dgvPublicaciones.Columns[1].Name = "DESCRIPCIÓN";
            dgvPublicaciones.Columns[2].Name = "ESTADO";
            dgvPublicaciones.Columns[3].Name = "GRADO";
            agregarButtonColumn("SELECCIONAR");

            gestor.conectar();
            query_defecto = "SELECT PU.id_publicacion, PU.descripcion AS descripcionP, " +
                    "E.descripcion AS descripcionE, G.muliplicador " +
                "FROM PEAKY_BLINDERS.publicaciones PU " +
                    "JOIN PEAKY_BLINDERS.estados E ON PU.id_estado = E.id_estado " +
                    "JOIN PEAKY_BLINDERS.grados G ON PU.id_grado = G.id_grado ";
            string query2 = query_defecto + "WHERE PU.id_empresa = '" + empresaID.ToString() + "'";
            gestor.consulta(query2);
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

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            FormMiUsuario formMiUsuario = new FormMiUsuario(userID, false, true);
            this.Hide();
            formMiUsuario.Show();
        }

        private void btnGenerarPublicacion_Click(object sender, EventArgs e)
        {
            FormGenerarPublicacion formGenerarPublicacion = new FormGenerarPublicacion(userID, empresaID);
            this.Hide();
            formGenerarPublicacion.Show();
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

        private void dgvPublicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                FormGenerarPublicacion formGenerarPublicacion = new FormGenerarPublicacion(userID, empresaID, Convert.ToInt32(dgvPublicaciones.CurrentRow.Cells[0].Value));
                this.Hide();
                formGenerarPublicacion.Show();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPublicaciones.Rows.Clear();

            string condicion = "JOIN PEAKY_BLINDERS.presentaciones PR ON PU.id_publicacion = PR.id_publicacion " +
                    "LEFT JOIN PEAKY_BLINDERS.rubros R ON PU.id_rubro = R.id_rubro " +
                "WHERE PU.id_empresa = '" + empresaID.ToString() + "' ";
            string descripcion = txtDescripcion.Text;

            if (descripcion != "")
            {
                condicion += "AND PU.descripcion LIKE '%" + descripcion + "%' ";
            }

            if (ckbRangoFechas.Checked)
            {
                condicion += "AND PR.fecha_presentacion BETWEEN '" + mcrDesde.SelectionStart.ToShortDateString() + "' AND '" + mcrHasta.SelectionStart.ToShortDateString() + "' ";
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

            condicion += "ORDER BY PR.fecha_presentacion ASC";

            GestorDB gestor = new GestorDB();
            gestor.conectar();

            string query = query_defecto + condicion;
            MessageBox.Show(query);
            gestor.consulta(query);
            this.mostrarPublicaciones(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
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

    }
}
