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

            dgvPublicaciones.ColumnCount = 3;
            dgvPublicaciones.ColumnHeadersVisible = true;
            dgvPublicaciones.Columns[0].Name = "DESCRIPCIÓN";
            dgvPublicaciones.Columns[1].Name = "ESTADO";
            dgvPublicaciones.Columns[2].Name = "GRADO";

            gestor.conectar();
            string query2 = "SELECT P.descripcion AS descripcionP, E.descripcion AS descripcionE, G.muliplicador " +
                "FROM PEAKY_BLINDERS.publicaciones P " +
                    "JOIN PEAKY_BLINDERS.estados E ON P.id_estado = E.id_estado " +
                    "JOIN PEAKY_BLINDERS.grados G ON P.id_grado = G.id_grado " +
                "WHERE P.id_empresa = '" + empresaID.ToString() + "'";
            gestor.consulta(query2);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();

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
            ckbBorrador.Checked = false;
            ckbPublicada.Checked = false;
            ckbFinalizada.Checked = false;
            ckbAlto.Checked = false;
            ckbMedio.Checked = false;
            ckbBajo.Checked = false;
            txtDescripcion.Select();
        }

    }
}
