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

        // Metodos auxiliares

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                cmbRubro.Items.Add(lector["descripcion"].ToString());
            }
        }

        private void enviarPublicacionPorFecha(GestorDB gestor, char estado, DateTime fecha_presentacion)
        {
            gestor.parametroPorValor("id_estado", estado);
            gestor.parametroPorValor("descripcion", txtDescripcion.Text);
            gestor.parametroPorValor("stock", txtStock.Text);
            gestor.parametroPorValor("fecha_nacimiento", fecha_presentacion);
            gestor.parametroPorValor("calle", txtCalle.Text);
            gestor.parametroPorValor("numero", txtAltura.Text);
            gestor.parametroPorValor("codigo_postal", txtCodPostal.Text);
            gestor.parametroPorValor("localidad", txtLocalidad.Text);
            gestor.parametroPorValor("rubro", cmbRubro.Text);
            gestor.parametroPorValor("precio", txtPrecio.Text);
        }

        private void persistirPublicacion(string procedure, char estado)
        {
            /*
             * INICIO TRANSACCION
             */
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.generarStoredProcedure(procedure);

            foreach (ListViewItem item in lsvFechaHora.Items)
            {
                enviarPublicacionPorFecha(gestor, estado, DateTime.Parse(item.Text + " " + item.SubItems[1].Text));
            }

            gestor.ejecutarStoredProcedure();
            gestor.desconectar();
            /*
             * FIN TRANSACCION
             */
        }

        // -------------------

        private void FormGenerarPublicacion_Load(object sender, EventArgs e)
        {
            GeneradorDeFechas generador = new GeneradorDeFechas();
            generador.completar(cmbDia, cmbMes, cmbAno, false);

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
            string campos_fecha = cmbAno.Text + "/" + cmbMes.Text + "/" + cmbDia.Text + " " + nudHora.Value.ToString() + ":" + nudMinuto.Value.ToString();
            DateTime fecha_ingresada = DateTime.Parse(campos_fecha);

            int cant_items = lsvFechaHora.Items.Count;
            if (cant_items > 0)
            {
                DateTime ultima_cargada = DateTime.Parse(lsvFechaHora.Items[cant_items - 1].Text + " " + lsvFechaHora.Items[cant_items - 1].SubItems[1].Text);

                if (ultima_cargada > fecha_ingresada)
                {
                    MessageBox.Show("La fecha de presentación ingresada no puede ser anterior a una que ya esté cargada, intente con otra fecha.", "ALERTA");
                    return;
                }
            }

            ListViewItem item = new ListViewItem(cmbAno.Text + "/" + cmbMes.Text + "/" + cmbDia.Text);
            string hora = nudHora.Value.ToString();
            string minuto = nudMinuto.Value.ToString();
            if (hora.Length == 1) hora = "0" + hora;
            if (minuto.Length == 1) minuto = "0" + minuto;
            item.SubItems.Add(hora + ":" + minuto);
            item.SubItems.Add("NUEVO");
            lsvFechaHora.Items.Add(item);
            lsvFechaHora.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            this.persistirPublicacion("crear_publicacion", '2');
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.persistirPublicacion("crear_publicacion", '1');
        }

    }
}
