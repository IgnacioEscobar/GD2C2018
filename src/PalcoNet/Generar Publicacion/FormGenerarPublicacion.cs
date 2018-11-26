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

namespace PalcoNet.Generar_Publicacion
{
    public partial class FormGenerarPublicacion : Form
    {
        public FormGenerarPublicacion()
        {
            InitializeComponent();
        }

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                cmbRubros.Items.Add(lector["descripcion"].ToString());
            }
        }

        private void FormGenerarPublicacion_Load(object sender, EventArgs e)
        {
            GeneradorDeFechas generador = new GeneradorDeFechas();
            generador.completar(cmbDia, cmbMes, cmbAno);

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT descripcion FROM PEAKY_BLINDERS.rubros");
            gestor.ejecutarStoredProcedure();
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

    }
}
