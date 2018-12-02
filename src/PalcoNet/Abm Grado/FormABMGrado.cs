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
    public partial class dgvPublicaciones : Form
    {
        public dgvPublicaciones()
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

        }

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["descripcion"].ToString(),
                
                };
                lsbPublicaciones.Items.Add(row);
            }
        }
        
        
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = " SELECT descripcion FROM PEAKY_BLINDERS.publicaciones"
                + " WHERE descripcion LIKE '%" + txtDescripcion.Text + "%'";
            gestor.consulta(query);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();

         

        }

    }
}
