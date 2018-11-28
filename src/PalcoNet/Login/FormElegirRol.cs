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

        public FormElegirRol(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Form formDestino;

            if (rbnCliente.Checked)
            {
                formDestino = new FormMenuCliente();
                this.Hide();
                formDestino.Show();
            }
            if (rbnEmpresa.Checked)
            {
                formDestino = new FormMenuEmpresa();
                this.Hide();
                formDestino.Show();
            }
            if (rbnAdministrativo.Checked)
            {
                formDestino = new FormMenuAdministrador();
                this.Hide();
                formDestino.Show();
            }
        }

        private void FormElegirRol_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT R.descripcion FROM PEAKY_BLINDERS.roles R " +
                "JOIN PEAKY_BLINDERS.roles_por_usuario RU ON R.id_rol = RU.id_rol " +
                "WHERE RU.id_usuario = '" + userID + "'";
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                string rolCargado = lector["descripcion"].ToString();
                switch (rolCargado)
                {
                    case "Cliente":
                        rbnCliente.Enabled = true;
                        break;

                    case "Empresa":
                        rbnEmpresa.Enabled = true;
                        break;

                    case "Administrativo":
                        rbnAdministrativo.Enabled = true;
                        break;
                }
            }
        }

    }
}
