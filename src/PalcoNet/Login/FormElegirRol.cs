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

using PalcoNet.Menu_Principal;
using PalcoNet.funciones_utiles;

namespace PalcoNet.Login
{
    public partial class FormElegirRol : Form
    {
        int userID;
        bool cambiar_pass;

        public FormElegirRol(int userID, bool cambiar_pass)
        {
            InitializeComponent();
            this.userID = userID;
            this.cambiar_pass = cambiar_pass;
        }

        // Metodos auxiliares

        private void agregarButtonColumn(string header)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = header;
            column.Text = "-->";
            column.UseColumnTextForButtonValue = true;
            dgvRoles.Columns.Add(column);
        }

        // -------------------

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void FormElegirRol_Load(object sender, EventArgs e)
        {
            dgvRoles.ColumnCount = 2;
            dgvRoles.ColumnHeadersVisible = true;
            dgvRoles.Columns[0].Name = "ID";
            dgvRoles.Columns[0].Visible = false;
            dgvRoles.Columns[1].Name = "ROL";
            agregarButtonColumn("SELECCIONAR");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = 
                "SELECT R.id_rol, R.descripcion " +
                "FROM PEAKY_BLINDERS.roles R " +
                    "JOIN PEAKY_BLINDERS.roles_por_usuario RU ON R.id_rol = RU.id_rol " +
                "WHERE RU.id_usuario = '" + userID + "'";
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                object[] row = new object[]
                {
                    lector["id_rol"].ToString(),
                    lector["descripcion"].ToString()
                };
                dgvRoles.Rows.Add(row);
            }
        }

        private void dgvRoles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int rolID = Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value);
                Form formDestino;

                if (cambiar_pass)
                {
                    formDestino = new FormNuevaContrasena(userID, rolID, true);
                }
                else
                {
                    formDestino = new FormMenuPrincipal(userID, rolID);
                }

                this.Hide();
                formDestino.Show();
            }
        }

    }
}
