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

using PalcoNet.Menu_Principal;
using PalcoNet.funciones_utiles;

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class FormGenerarRendicion : Form
    {
        int userID;
        int rolID;

        public FormGenerarRendicion(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        private void mostrarVentas(SqlDataReader lector)
        {
            dgvVentas.Rows.Clear();
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["razon_social"].ToString(),
                    lector["descripcion"].ToString(),
                    lector["fecha"].ToString(),
                    lector["monto"].ToString(),
                    lector["comision"].ToString()
                };
                dgvVentas.Rows.Add(row);
            }
            dgvVentas.AutoResizeColumns();
        }

        private void FormGenerarRendicion_Load(object sender, EventArgs e)
        {
            dgvVentas.ColumnCount = 5;
            dgvVentas.ColumnHeadersVisible = true;
            dgvVentas.Columns[0].Name = "EMPRESA";
            dgvVentas.Columns[1].Name = "PUBLICACIÓN";
            dgvVentas.Columns[2].Name = "FECHA DE COMPRA";
            dgvVentas.Columns[3].Name = "MONTO";
            dgvVentas.Columns[4].Name = "COMISIÓN";
            dgvVentas.AutoResizeColumns();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(
                "SELECT E.razon_social, PU.descripcion, CONVERT(DATE, C.fecha) as fecha, C.monto, (C.monto * G.multiplicador) AS comision " +
                "FROM PEAKY_BLINDERS.empresas E " +
                    "JOIN PEAKY_BLINDERS.publicaciones PU ON E.id_empresa = PU.id_empresa " +
                    "JOIN PEAKY_BLINDERS.grados G ON PU.id_grado = G.id_grado " +
                    "JOIN PEAKY_BLINDERS.compras C ON PU.id_publicacion = C.id_publicacion " +
                "WHERE C.facturada = 0 AND CONVERT(DATE, C.fecha) <= '" + dtpFechaRendicion.Value.ToShortDateString() + "' " +
                "ORDER BY C.fecha ASC");
            this.mostrarVentas(gestor.obtenerRegistros());
            gestor.desconectar();
            lblCantidad.Text = "CANTIDAD: " + dgvVentas.Rows.Count.ToString();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formDestino = new FormLogin();
            this.Hide();
            formDestino.Show();
        }

        private void btnTodas_Click(object sender, EventArgs e)
        {
            dtpFechaRendicion.Value = DateTime.Today;
            this.btnSeleccionar_Click(sender, e);
        }

    }
}
