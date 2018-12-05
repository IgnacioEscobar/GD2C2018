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
using PalcoNet.Abm_Usuario;
using PalcoNet.Menu_Principal;

namespace PalcoNet.ABM_Usuario
{
    public partial class FormMiUsuario : Form
    {
        int userID;
        int adminID;
        bool cliente;
        bool empresa;

        public FormMiUsuario(int userID, bool cliente, bool empresa)
        {
            InitializeComponent();
            this.userID = userID;
            this.cliente = cliente;
            this.empresa = empresa;
        }

        public FormMiUsuario(int userID, int adminID)
        {
            InitializeComponent();
            this.userID = userID;
            this.adminID = adminID;
            this.cliente = false;
            this.empresa = false;
        }

        private void FormMiUsuario_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT nombre_de_usuario FROM PEAKY_BLINDERS.usuarios WHERE id_usuario = '" + userID + "'";
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            if (lector.Read())
            {
                lblUsuario.Text = "Usuario: " + lector["nombre_de_usuario"].ToString();
            }
            gestor.desconectar();

            txtPassActual.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (cliente)
            {
                FormMenuCliente formMenuCliente = new FormMenuCliente(userID);
                this.Hide();
                formMenuCliente.Show();
            }
            else if (empresa)
            {
                FormMenuEmpresa formMenuEmpresa = new FormMenuEmpresa(userID);
                this.Hide();
                formMenuEmpresa.Show();
            }
            else
            {
                FormABMUsuario formABMUsuario = new FormABMUsuario(adminID);
                this.Hide();
                formABMUsuario.Show();
            }

            
        }
    }
}
