using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.funciones_utiles;
using PalcoNet.Menu_Principal;
using System.Data.SqlClient;

namespace PalcoNet.Abm_Grado
{
    public partial class FormABMGrado : Form
    {
        public FormABMGrado()
        {
            InitializeComponent();
        }

        private void btnPanelDeControl_Click(object sender, EventArgs e)
        {
            FormMenuAdministrador formAbmAdministrador = new FormMenuAdministrador();
            this.Hide();
            formAbmAdministrador.Show();
        }

        private void FormABMGrado_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT ISNULL(descripcion, 'Sin descripción') AS descripcion FROM PEAKY_BLINDERS.publicaciones";
            gestor.consulta(query);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                lsbPublicaciones.Items.Add(lector["descripcion"]);
            }
        }
        
        
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = " SELECT ISNULL(descripcion, 'Sin descripción' FROM PEAKY_BLINDERS.publicaciones"
                + " WHERE descripcion LIKE '%" + txtDescripcion.Text + "%'";
            gestor.consulta(query);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();

         

        }

    }
}
