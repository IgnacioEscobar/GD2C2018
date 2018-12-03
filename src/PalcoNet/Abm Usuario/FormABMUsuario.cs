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

namespace PalcoNet.Abm_Usuario
{
    public partial class FormABMUsuario : Form
    {
        public FormABMUsuario()
        {
            InitializeComponent();
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
            dgvUsuarios.ColumnCount = 1;
            dgvUsuarios.ColumnHeadersVisible = true;
            dgvUsuarios.Columns[0].Name = "NOMBRE DE USUARIO";
            agregarCheckBoxColumn("ADMINISTRADOR");
            agregarCheckBoxColumn("CLIENTE");
            agregarCheckBoxColumn("EMPRESA");
            agregarCheckBoxColumn("HABILITADO");
            agregarButtonColumn("CONFIGURACIÓN");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT U.nombre_de_usuario, R.descripcion, U.habilitado " +
                "FROM PEAKY_BLINDERS.usuarios U " +
                    "JOIN PEAKY_BLINDERS.roles_por_usuario RU ON U.id_usuario = RU.id_usuario " +
                    "JOIN PEAKY_BLINDERS.roles R ON RU.id_rol = R.id_rol";
            gestor.consulta(query);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnPanelDeControl_Click(object sender, EventArgs e)
        {
            FormMenuAdministrador formAbmAdministrador = new FormMenuAdministrador();
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
    }
}
