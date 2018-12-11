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
    public partial class FormUbicaciones : Form
    {
        FormGenerarPublicacion formGenerarPublicacion;
        List<ListViewItem> listaUbicaciones;

        public FormUbicaciones(FormGenerarPublicacion formGenerarPublicacion)
        {
            InitializeComponent();
            this.formGenerarPublicacion = formGenerarPublicacion;
        }

        // Metodos auxiliares

        private void mostrarTiposDeUbicacion(SqlDataReader lector)
        {
            while (lector.Read())
            {
                cmbSector.Items.Add(lector["descripcion"]);
            }
        }

        private void mostrarNuevaUbicacion()
        {
            ListViewItem item = new ListViewItem(cmbSector.Text);
            item.SubItems.Add(nudPrecio.Value.ToString());
            item.SubItems.Add(nudFilas.Value.ToString());
            item.SubItems.Add(nudAsientos.Value.ToString());
            item.SubItems.Add("NUEVO");
            lsvUbicaciones.Items.Add(item);
            listaUbicaciones.Add(item);
        }

        // -------------------

        private void FormUbicaciones_Load(object sender, EventArgs e)
        {
            lsvUbicaciones.View = View.Details;
            lsvUbicaciones.Columns.Add("SECTOR");
            lsvUbicaciones.Columns.Add("PRECIO");
            lsvUbicaciones.Columns.Add("FILAS");
            lsvUbicaciones.Columns.Add("ASIENTOS");
            lsvUbicaciones.Columns.Add("");

            listaUbicaciones = new List<ListViewItem>();

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT descripcion FROM PEAKY_BLINDERS.tipos_de_ubicacion");
            this.mostrarTiposDeUbicacion(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = "Error:";
            bool hubo_error = false;

            if (cmbSector.Text == "")
            {
                mensaje += "\n- Debe seleccionar un sector";
                hubo_error = true;                
            }
            if (nudPrecio.Value <= 0)
            {
                mensaje += "\n- El precio debe ser mayor a 0";
                hubo_error = true;                
            }
            if (nudFilas.Value <= 0)
            {
                mensaje += "\n- Las filas deben ser mayor a 0";
                hubo_error = true;
            }
            if (nudAsientos.Value <= 0)
            {
                mensaje += "\n- Los asientos deben ser mayor a 0";
                hubo_error = true;
            }
            if (hubo_error)
            {
                MessageBox.Show(mensaje, "Alerta");
            }
            else
            {
                this.mostrarNuevaUbicacion();
                lsvUbicaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            formGenerarPublicacion.reaparecer(listaUbicaciones);
        }
    }
}
