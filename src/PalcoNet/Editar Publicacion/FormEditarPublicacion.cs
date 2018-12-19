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
using PalcoNet.Menu_Principal;

namespace PalcoNet.Editar_Publicacion
{
    public partial class FormEditarPublicacion : Form
    {
        int userID;
        int rolID;
        int empresaID;
        string select_defecto = "SELECT PU.id_publicacion, PU.descripcion AS descripcionP, " +
                    "E.descripcion AS descripcionE, G.descripcion AS descripcionG " +
                    "FROM PEAKY_BLINDERS.publicaciones PU ";
        string join_defecto = "JOIN PEAKY_BLINDERS.estados E ON PU.id_estado = E.id_estado " +
                    "JOIN PEAKY_BLINDERS.grados G ON PU.id_grado = G.id_grado ";
        string query_defecto;
        string query_actual;
        int pagina;
        int maxPaginas;
        GestorDB gestor = new GestorDB();

        public FormEditarPublicacion(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.query_defecto = select_defecto + join_defecto;
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

        private void mostrarPublicaciones(string query)
        {
            gestor.conectar();
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();

            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["id_publicacion"].ToString(),
                    lector["descripcionP"].ToString(),
                    lector["descripcionE"].ToString(),
                    lector["descripcionG"].ToString()
                };
                dgvPublicaciones.Rows.Add(row);
            }

            gestor.desconectar();
        }

        /* METODO PARA MANTENER FILTROS CUANDO VUELVE DE OTRO FORM
        public void actualizar()
        {
            dgvPublicaciones.Rows.Clear();

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(query_actual);
            this.mostrarPublicaciones(gestor.obtenerRegistros());
            gestor.desconectar();
        }
        */
        private void mostrarCategorias(string query_categorias)
        {
            gestor.conectar();
            gestor.consulta(query_categorias);
            SqlDataReader lector = gestor.obtenerRegistros();
            int i = 0;
            while (lector.Read())
            {
                clbCategorias.Items.Add(lector["descripcion"]);
                clbCategorias.SetItemChecked(i, true);
                i++;
            }
            gestor.desconectar();
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

            gestor.conectar();

            gestor.consulta("SELECT id_empresa FROM PEAKY_BLINDERS.empresas WHERE id_usuario = '" + userID + "'");
            SqlDataReader lector = gestor.obtenerRegistros();
            if (lector.Read())
            {
                empresaID = Convert.ToInt32(lector["id_empresa"]);
            }
            gestor.desconectar();
            pagina = 1;

            query_actual = query_defecto + "WHERE PU.id_empresa = '" + empresaID + "' ORDER BY PU.id_publicacion ASC";
            string query_publicaciones = aplicarPagina(query_actual, pagina);
            this.mostrarPublicaciones(query_publicaciones);

            string query_categorias = "SELECT descripcion FROM PEAKY_BLINDERS.rubros";
            this.mostrarCategorias(query_categorias);
            
            maxPaginas = maximoPaginas(join_defecto, " WHERE PU.id_empresa = '" + empresaID + "'");
            showPageNum();

            dgvPublicaciones.AutoResizeColumns();
            txtDescripcion.Select();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void dgvPublicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                FormGenerarPublicacion formGenerarPublicacion = new FormGenerarPublicacion(userID, rolID, Convert.ToInt32(dgvPublicaciones.CurrentRow.Cells[0].Value));
                this.Hide();
                formGenerarPublicacion.Show();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPublicaciones.Rows.Clear();

            string condicion = "JOIN PEAKY_BLINDERS.presentaciones PR ON PU.id_publicacion = PR.id_publicacion " +
                    "LEFT JOIN PEAKY_BLINDERS.rubros R ON PU.id_rubro = R.id_rubro " +
                "WHERE PU.id_empresa = '" + empresaID + "' ";
            string descripcion = txtDescripcion.Text.Trim();

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
            else
            {
                condicion += "AND PU.id_rubro = NULL ";
            }
            maxPaginas = maximoPaginas(join_defecto, condicion);
            condicion += "ORDER BY PR.fecha_presentacion ASC";
            pagina = 1;

            query_actual = query_defecto + condicion;
            string condicion_paginada = aplicarPagina(query_actual, pagina);
            this.mostrarPublicaciones(condicion_paginada);
            showPageNum();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
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

        private string aplicarPagina(string condicion, int pagina, int tamanio_pagina = 10)
        {
            int offset = (pagina - 1) * tamanio_pagina;
            string complemento = " OFFSET " + offset + " ROWS FETCH NEXT " + tamanio_pagina + " ROWS ONLY";
            return condicion + complemento;
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            pagina = Math.Min(maxPaginas, pagina + 1);
            paginarYCorrer(query_actual);
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            pagina = Math.Max(1, pagina - 1);
            paginarYCorrer(query_actual);
        }

        private void paginarYCorrer(string condicion)
        {
            string condicion_paginada = aplicarPagina(condicion, pagina);
            correrQuery(condicion_paginada);
            showPageNum();
        }

        private void showPageNum()
        {
            paginaLabel.Text = pagina + " / " + maxPaginas;
        }

        private void correrQuery(string condicion_paginada)
        {
            dgvPublicaciones.Rows.Clear();
            this.mostrarPublicaciones(condicion_paginada);
        }

        private void Ultima_Click(object sender, EventArgs e)
        {
            pagina = maxPaginas;
            paginarYCorrer(query_actual);
        }

        private void Primera_Click(object sender, EventArgs e)
        {
            pagina = 1;
            paginarYCorrer(query_actual);
        }

        private int maximoPaginas(string joins_defecto, string filtro, int tamanio_pagina = 10)
        {
            string count_querry = "select count(distinct PU.id_publicacion) as presentaciones FROM PEAKY_BLINDERS.publicaciones PU ";
            count_querry += joins_defecto;
            count_querry += filtro;
            gestor.conectar();
            gestor.consulta(count_querry);
            SqlDataReader lector = gestor.obtenerRegistros();
            lector.Read();
            int count = lector.GetInt32(0);
            gestor.desconectar();
            return Math.Max(1,(count + tamanio_pagina - 1) / tamanio_pagina);
        }


    }
}
