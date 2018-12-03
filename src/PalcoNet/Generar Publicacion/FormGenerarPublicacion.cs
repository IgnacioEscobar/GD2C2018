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

namespace PalcoNet.Generar_Publicacion
{
    public partial class FormGenerarPublicacion : Form
    {
        int userID;

        public FormGenerarPublicacion(int userID)
        {
            InitializeComponent();
            this.userID = userID;
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

            lsvFechaHora.View = View.Details;
            lsvFechaHora.Columns.Add("FECHA");
            lsvFechaHora.Columns.Add("HORA");
            lsvFechaHora.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT descripcion FROM PEAKY_BLINDERS.rubros");
            gestor.ejecutarStoredProcedure();
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormMenuEmpresa formMenuEmpresa = new FormMenuEmpresa(userID);
            this.Hide();
            formMenuEmpresa.Show();
        }

        private void btnAgregarFecha_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(cmbDia.Text + "-" + cmbMes.Text + "-" + cmbAno.Text);
            item.SubItems.Add(nudHora.Value.ToString() + ":" + nudMinuto.Value.ToString());
            lsvFechaHora.Items.Add(item);
            lsvFechaHora.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

    }
}
