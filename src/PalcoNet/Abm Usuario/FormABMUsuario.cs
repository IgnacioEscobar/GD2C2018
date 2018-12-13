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
using PalcoNet.Registro_de_Usuario;
using PalcoNet.Abm_Usuario;

namespace PalcoNet.Abm_Usuario
{
    public partial class FormABMUsuario : Form
    {
        int userID;
        string query_defecto;

        public FormABMUsuario(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        // Metodos auxiliares

        private void agregarCheckBoxColumn(string header)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = header;
            dgvUsuarios.Columns.Add(column);
        }

        private void agregarButtonColumn(string header)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = header;
            column.Text = "-->";
            column.UseColumnTextForButtonValue = true;
            dgvUsuarios.Columns.Add(column);
        }

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                string rolAsignado = lector["descripcion"].ToString();
                object[] row = new object[]
                {
                    lector["id_usuario"].ToString(),
                    lector["nombre_de_usuario"].ToString(),
                    (rolAsignado == "Administrador"),
                    (rolAsignado == "Cliente"),
                    (rolAsignado == "Empresa"),
                    lector["habilitado"]
                };
                dgvUsuarios.Rows.Add(row);
            }
        }

        // -------------------

        private void FormABMUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuarios.ColumnCount = 2;
            dgvUsuarios.ColumnHeadersVisible = true;
            dgvUsuarios.Columns[0].Name = "ID";
            dgvUsuarios.Columns[0].Visible = false;
            dgvUsuarios.Columns[1].Name = "NOMBRE DE USUARIO";
            agregarCheckBoxColumn("ADMINISTRADOR");
            agregarCheckBoxColumn("CLIENTE");
            agregarCheckBoxColumn("EMPRESA");
            agregarCheckBoxColumn("HABILITADO");
            agregarButtonColumn("SELECCIONAR");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            query_defecto = "SELECT U.id_usuario, U.nombre_de_usuario, R.descripcion, U.habilitado " +
                "FROM PEAKY_BLINDERS.usuarios U " +
                    "JOIN PEAKY_BLINDERS.roles_por_usuario RU ON U.id_usuario = RU.id_usuario " +
                    "JOIN PEAKY_BLINDERS.roles R ON RU.id_rol = R.id_rol";
            gestor.consulta(query_defecto);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();

            txtUsuario.Select();
        }

        private void btnPanelDeControl_Click(object sender, EventArgs e)
        {
            FormMenuAdministrador formAbmAdministrador = new FormMenuAdministrador(userID);
            this.Hide();
            formAbmAdministrador.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            ckbHabilitado.Checked = false;
            ckbAdministrador.Checked = false;
            ckbCliente.Checked = false;
            ckbEmpresa.Checked = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormRegistroComun formRegistroComun = new FormRegistroComun();
            this.Hide();
            formRegistroComun.Show();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                FormNuevaContrasena formMiUsuario = new FormNuevaContrasena(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value), userID);
                this.Hide();
                formMiUsuario.Show();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;

            List<object[]> listaCampos = new List<object[]>();

            if (usuario != "")
            {
                object[] tuplaUsuario = { "U.nombre_de_usuario", usuario, false };
                listaCampos.Add(tuplaUsuario);
            }

            object[] tuplaHabilitado = { "U.habilitado", Convert.ToInt32(ckbHabilitado.Checked), true };
            listaCampos.Add(tuplaHabilitado);

            /*
            object[] tuplaAdministrador = { "administrador", Convert.ToInt32(ckbAdministrador.Checked), true };
            listaCampos.Add(tuplaAdministrador);

            object[] tuplaCliente = { "cliente", Convert.ToInt32(ckbCliente.Checked), true };
            listaCampos.Add(tuplaCliente);

            object[] tuplaEmpresa = { "empresa", Convert.ToInt32(ckbEmpresa.Checked), true };
            listaCampos.Add(tuplaEmpresa);
            */
 
            int cant_filtros = listaCampos.Count();
            dgvUsuarios.Rows.Clear();

            string filtro = "";
            for (int i = 0; i < cant_filtros; i++)
            {
                object[] tuplaCampos = listaCampos[i];
                string comparacion, cierre;
                bool busqueda_exacta = Convert.ToBoolean(tuplaCampos[2]);
                if (busqueda_exacta) // busqueda exacta
                {
                    comparacion = " = '";
                    cierre = "'";
                }
                else // busqueda aproximada
                {
                    comparacion = " LIKE '%";
                    cierre = "%'";
                }
                filtro += tuplaCampos[0] + comparacion + tuplaCampos[1] + cierre;
                if (i != listaCampos.Count() - 1) filtro += " AND ";
            }

            GestorDB gestor = new GestorDB();
            gestor.conectar();

            string query = query_defecto;
            query += " WHERE " + filtro;
            gestor.consulta(query);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

    }
}
