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
            lsvFechaHora.Columns.Add("");
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
            string fecha_ingresada = cmbDia.Text + "/" + cmbMes.Text + "/" + cmbAno.Text + " " + nudHora.Value.ToString() + ":" + nudMinuto.Value.ToString();

            int cant_items = lsvFechaHora.Items.Count;
            if (cant_items > 0)
            {
                DateTime ultima_cargada = DateTime.Parse(lsvFechaHora.Items[cant_items - 1].Text + " " + lsvFechaHora.Items[cant_items - 1].SubItems[1].Text);
                DateTime ingresada = DateTime.Parse(fecha_ingresada);

                if (ultima_cargada > ingresada)
                {
                    MessageBox.Show("La fecha de presentación ingresada no puede ser anterior a una que ya esté cargada, intente con otra fecha.", "ALERTA");
                    return;
                }
            }

            ListViewItem item = new ListViewItem(cmbDia.Text + "/" + cmbMes.Text + "/" + cmbAno.Text);
            string hora = nudHora.Value.ToString();
            string minuto = nudMinuto.Value.ToString();
            if (hora.Length == 1) hora = "0" + hora;
            if (minuto.Length == 1) minuto = "0" + minuto;
            item.SubItems.Add(hora + ":" + minuto);
            item.SubItems.Add("NUEVO");
            lsvFechaHora.Items.Add(item);
            lsvFechaHora.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

    }
}
