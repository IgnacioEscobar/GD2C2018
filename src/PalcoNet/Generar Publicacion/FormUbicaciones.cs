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
        int publicacionID;
        bool modif;
        bool puede_modif;
        List<ListViewItem> listaUbicaciones;

        public FormUbicaciones(FormGenerarPublicacion formGenerarPublicacion)
        {
            InitializeComponent();
            this.formGenerarPublicacion = formGenerarPublicacion;
            this.listaUbicaciones = new List<ListViewItem>();
            this.modif = false;
        }

        public FormUbicaciones(FormGenerarPublicacion formGenerarPublicacion, List<ListViewItem> listaUbicaciones, int publicacionID, bool puede_modif)
        {
            InitializeComponent();
            this.formGenerarPublicacion = formGenerarPublicacion;
            this.listaUbicaciones = listaUbicaciones;
            this.publicacionID = publicacionID;
            this.modif = true;
            this.puede_modif = puede_modif;
        }

        // Metodos auxiliares

        private void mostrarTiposDeUbicacion(SqlDataReader lector)
        {
            while (lector.Read())
            {
                cmbSector.Items.Add(lector["descripcion"]);
            }
        }

        private void mostrarUbicacion(string sector, int precio, int filas, int asientos, bool nuevo)
        {
            ListViewItem item = new ListViewItem(sector);
            item.SubItems.Add(precio.ToString());
            item.SubItems.Add(filas.ToString());
            item.SubItems.Add(asientos.ToString());
            if (nuevo)
            {
                item.SubItems.Add("NUEVO");
            }
            else
            {
                item.SubItems.Add("");
            }
            lsvUbicaciones.Items.Add(item);
            listaUbicaciones.Add(item);
        }

        private void mostrarUbicacionesCargadas(SqlDataReader lector)
        {
            while (lector.Read())
            {
                mostrarUbicacion(lector["descripcion"].ToString(),
                    Convert.ToInt32(lector["precio"]),
                    Convert.ToInt32(lector["filas"]),
                    Convert.ToInt32(lector["asientos"]),
                    false);
            }
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

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT descripcion FROM PEAKY_BLINDERS.tipos_de_ubicacion ORDER BY descripcion ASC");
            this.mostrarTiposDeUbicacion(gestor.obtenerRegistros());
            gestor.desconectar();

            if (listaUbicaciones.Count > 0)
            {
                foreach (ListViewItem item in listaUbicaciones)
                {
                    bool nuevo = false;
                    if (item.SubItems[4].Text == "NUEVO")
                    {
                        nuevo = true;
                    }
                    this.mostrarUbicacion(item.SubItems[0].Text,
                        Convert.ToInt32(item.SubItems[1].Text),
                        Convert.ToInt32(item.SubItems[2].Text),
                        Convert.ToInt32(item.SubItems[3].Text),
                        nuevo);
                }
            }
            else if (modif)
            {
                gestor.conectar();
                string query =
                    "SELECT TU.descripcion, " +
                        "U.precio, " +
                        "COUNT(U.fila) AS filas, " +
                        "COUNT(U.asiento) AS asientos " +
                    "FROM PEAKY_BLINDERS.ubicaciones U " +
                        "JOIN PEAKY_BLINDERS.tipos_de_ubicacion TU ON U.id_tipo_de_ubicacion = TU.id_tipo_de_ubicacion " +
                    "WHERE U.id_publicacion = '" + publicacionID + "' " +
                    "GROUP BY TU.descripcion, U.precio";
                gestor.consulta(query);
                this.mostrarUbicacionesCargadas(gestor.obtenerRegistros());
                gestor.desconectar();

                if (!puede_modif)
                {
                    btnAgregar.Enabled = false;
                }
            }

            lsvUbicaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string sector = cmbSector.Text;
            int precio = Convert.ToInt32(nudPrecio.Value);
            int filas = Convert.ToInt32(nudFilas.Value);
            int asientos = Convert.ToInt32(nudAsientos.Value);
            string mensaje = "Error:";
            bool hubo_error = false;

            if (cmbSector.Text == "")
            {
                mensaje += "\n- Debe seleccionar un sector";
                hubo_error = true;
            }
            else
            {
                bool sector_valido = false;
                int i = 0;
                while (!sector_valido && i < cmbSector.Items.Count)
                {
                    if (cmbSector.Items[i].ToString() == sector)
                    {
                        sector_valido = true;
                    }
                    i++;
                }
                if (!sector_valido)
                {
                    mensaje += "\n- Debe seleccionar un sector válido";
                    hubo_error = true;
                }
            }
            if (precio <= 0)
            {
                mensaje += "\n- El precio debe ser mayor a 0";
                hubo_error = true;                
            }
            if (filas <= 0)
            {
                mensaje += "\n- Las filas deben ser mayor a 0";
                hubo_error = true;
            }
            if (asientos <= 0)
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
                this.mostrarUbicacion(sector, precio, filas, asientos, true);
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
