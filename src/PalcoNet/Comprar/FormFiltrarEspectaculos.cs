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
        string query_defecto;
        string select_defecto = "select PP.id_presentacion, P.descripcion, PP.fecha_presentacion from PEAKY_BLINDERS.presentaciones PP ";
        string joins_defecto = " join PEAKY_BLINDERS.publicaciones P on PP.id_publicacion = P.id_publicacion "
                + "join PEAKY_BLINDERS.estados E on P.id_estado = E.id_estado and E.descripcion = 'Publicada' "
                + "join PEAKY_BLINDERS.grados G on P.id_grado = G.id_grado ";

        GestorDB gestor = new GestorDB();
        List<string> categorias = new List<string>();
        string condicion;
        int pagina;
        int maxPaginas;


        public FormFiltrarEspectaculos(int userID, int rolID)
        {
            InitializeComponent();
            this.query_defecto = select_defecto + joins_defecto;
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

        private void mostrarPresentaciones(string query)
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

            string filtro_default = "where PP.fecha_vencimiento > GETDATE() and "
                    + "P.id_rubro in (" + String.Join(",", this.categorias.Select(x => x).ToArray()) + ") ";
                // + "PP.fecha_presentacion > " + fechaInicio + " "
                // + "PP.fecha_presentacion < " + fechaFin + " "

            string query_presentaciones = query_defecto + filtro_default
                + "order by G.multiplicador desc, PP.fecha_presentacion asc ";
            condicion = query_presentaciones;
            pagina = 1;
            maxPaginas = maximoPaginas(joins_defecto, filtro_default);
            query_presentaciones = aplicarPagina(query_presentaciones, pagina);
            this.mostrarPresentaciones(query_presentaciones);
            dgvEspectaculos.AutoResizeColumns();
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

            string filtro = "LEFT JOIN PEAKY_BLINDERS.rubros R ON P.id_rubro = R.id_rubro " +
                "WHERE PP.fecha_vencimiento >= GETDATE() ";
            string descripcion = txtDescripcion.Text;

            if (descripcion != "")
            {
                filtro += "AND P.descripcion LIKE '%" + descripcion + "%' ";
            }

            if (ckbRangoFechas.Checked)
            {
                filtro += "AND PP.fecha_presentacion BETWEEN '" + mcrDesde.SelectionStart.ToShortDateString() + "' AND '" + mcrHasta.SelectionStart.ToShortDateString() + "' ";
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
                filtro += "AND ";
                for (int i = 0; i < cant_categorias_seleccionadas; i++)
                {
                    filtro += "R.descripcion = '" + funcionalidades_tildadas[i] + "' ";
                    if (i != cant_categorias_seleccionadas - 1)
                    {
                        filtro += "OR ";
                    }
                }
            }
            else
            {
                filtro += "AND P.id_rubro = NULL ";
            }

            maxPaginas = maximoPaginas(joins_defecto, filtro);
            filtro += "order by G.multiplicador desc, PP.fecha_presentacion asc";
            condicion += filtro;
            pagina = 1;
            

            string condicion_paginada = aplicarPagina(condicion, pagina);

            string query_actual = query_defecto + condicion_paginada;
            dgvEspectaculos.Rows.Clear();
            this.mostrarPresentaciones(query_actual);
        }

        private int maximoPaginas(string joins_defecto, string filtro)
        {
            string count_querry = "select count(distinct PP.id_presentacion) as presentaciones from PEAKY_BLINDERS.presentaciones PP ";
            count_querry += joins_defecto;
            count_querry += filtro;
            gestor.conectar();
            gestor.consulta(count_querry);
            SqlDataReader lector = gestor.obtenerRegistros();
            lector.Read();
            int count = lector.GetInt32(0);
            gestor.desconectar();
            return (count + 10 - 1) / 10;
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

        private string aplicarPagina(string condicion, int pagina, int tamanio_pagina = 10){
            int offset = (pagina - 1) * tamanio_pagina;
            string complemento = "OFFSET "+ offset +" ROWS FETCH NEXT "+ tamanio_pagina +" ROWS ONLY";
            return condicion + complemento;
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            pagina = Math.Min(maxPaginas, pagina + 1);
            paginarYCorrer();
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            pagina = Math.Max(1, pagina - 1);
            paginarYCorrer();
        }

        private void paginarYCorrer()
        {
            string condicion_paginada = aplicarPagina(condicion, pagina);
            correrQuery(condicion_paginada);
        }

        private void correrQuery(string condicion_paginada)
        {
            dgvEspectaculos.Rows.Clear();
            this.mostrarPresentaciones(condicion_paginada);
        }

    }
}
