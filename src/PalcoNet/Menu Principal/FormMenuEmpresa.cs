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
using PalcoNet.ABM_Usuario;

namespace PalcoNet.Menu_Principal
{
    public partial class FormMenuEmpresa : Form
    {
        int userID;

        public FormMenuEmpresa(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        // Metodos auxiliares

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["descripcionP"].ToString(),
                    lector["descripcionE"].ToString(),
                    lector["muliplicador"].ToString(),
                };
                dgvPublicaciones.Rows.Add(row);
            }
        }

        // -------------------

        private void FormMenuEmpresa_Load(object sender, EventArgs e)
        {
            dgvPublicaciones.ColumnCount = 3;
            dgvPublicaciones.ColumnHeadersVisible = true;
            dgvPublicaciones.Columns[0].Name = "DESCRIPCIÓN";
            dgvPublicaciones.Columns[1].Name = "ESTADO";
            dgvPublicaciones.Columns[2].Name = "GRADO";

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT P.descripcion AS descripcionP, E.descripcion AS descripcionE, G.muliplicador " +
                "FROM PEAKY_BLINDERS.publicaciones P " +
                    "JOIN PEAKY_BLINDERS.estados E ON P.id_estado = E.id_estado " +
                    "JOIN PEAKY_BLINDERS.grados G ON P.id_grado = G.id_grado";
            gestor.consulta(query);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
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

    }
}
