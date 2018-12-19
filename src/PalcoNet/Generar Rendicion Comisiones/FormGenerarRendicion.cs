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
        DateTime fecha_seleccionada;

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
                    lector["id_compra"].ToString(),
                    lector["razon_social"].ToString(),
                    lector["descripcion"].ToString(),
                    lector["fecha"].ToString(),
                    lector["monto"].ToString(),
                    lector["comision"].ToString()
                };
                dgvVentas.Rows.Add(row);
            }
            dgvVentas.AutoResizeColumns();
            dgvVentas.SelectedRows[0].Selected = false;
        }

        private void FormGenerarRendicion_Load(object sender, EventArgs e)
        {
            dgvVentas.ColumnCount = 6;
            dgvVentas.ColumnHeadersVisible = true;
            dgvVentas.Columns[0].Name = "ID_COMPRA";
            dgvVentas.Columns[0].Visible = false;
            dgvVentas.Columns[1].Name = "EMPRESA";
            dgvVentas.Columns[2].Name = "PUBLICACIÓN";
            dgvVentas.Columns[3].Name = "FECHA DE COMPRA";
            dgvVentas.Columns[4].Name = "MONTO";
            dgvVentas.Columns[5].Name = "COMISIÓN";
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
            btnFacturarVentas.Enabled = true;
            fecha_seleccionada = dtpFechaRendicion.Value;

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(
                "SELECT C.id_compra, E.razon_social, P.descripcion, CONVERT(DATE, C.fecha) as fecha, C.monto, (C.monto * G.multiplicador) AS comision " +
                "FROM PEAKY_BLINDERS.empresas E " +
                    "JOIN PEAKY_BLINDERS.publicaciones P ON E.id_empresa = P.id_empresa " +
                    "JOIN PEAKY_BLINDERS.grados G ON P.id_grado = G.id_grado " +
                    "JOIN PEAKY_BLINDERS.compras C ON P.id_publicacion = C.id_publicacion " +
                "WHERE C.facturada = 0 AND CONVERT(DATE, C.fecha) <= '" + fecha_seleccionada.ToShortDateString() + "' " +
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

        private void btnFacturarVentas_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT E.razon_social, SUM(C.monto) AS monto_total, SUM(C.monto * G.multiplicador) AS comision_total " +
                "FROM PEAKY_BLINDERS.empresas E " +
                    "JOIN PEAKY_BLINDERS.publicaciones P ON E.id_empresa = P.id_empresa " +
                    "JOIN PEAKY_BLINDERS.grados G ON P.id_grado = G.id_grado " +
                    "JOIN PEAKY_BLINDERS.compras C ON P.id_publicacion = C.id_publicacion " +
                "WHERE C.facturada = 0 AND CONVERT(DATE, C.fecha) <= '" + fecha_seleccionada.ToShortDateString() + "' " +
                "GROUP BY E.razon_social " +
                "ORDER BY E.razon_social ASC";

            FormConfirmarFacturacion formConfirmarFacturacion = new FormConfirmarFacturacion(query);
            if (formConfirmarFacturacion.ShowDialog(this) == DialogResult.OK)
            {
                GestorDB gestor = new GestorDB();

                gestor.conectar();
                gestor.consulta(
                    "SELECT SUM(C.monto) AS monto_total " +
                    "FROM PEAKY_BLINDERS.compras C " +
                    "WHERE C.facturada = 0 " +
                        "AND CONVERT(DATE, C.fecha) <= '" + fecha_seleccionada.ToShortDateString() + "'");
                SqlDataReader lector = gestor.obtenerRegistros();
                int monto_total = -1;
                if (lector.Read()) monto_total = Convert.ToInt32(lector["monto_total"]);
                gestor.desconectar();

                gestor.conectar();
                gestor.generarStoredProcedure("generar_factura");
                gestor.parametroPorValor("fecha", DateTime.Today);
                gestor.parametroPorValor("total", monto_total);
                int facturaID = gestor.ejecutarStoredProcedure();
                gestor.desconectar();

                foreach (DataGridViewRow row in dgvVentas.Rows)
                {
                    gestor.conectar();
                    gestor.generarStoredProcedure("agregar_item");
                    gestor.parametroPorValor("id_factura", facturaID);
                    gestor.parametroPorValor("descripcion", "Comision por compra");
                    gestor.parametroPorValor("id_compra", Convert.ToInt32(row.Cells[0]));
                    gestor.parametroPorValor("cantidad", 1);
                    gestor.parametroPorValor("comision", Convert.ToInt32(row.Cells[4]));
                    gestor.ejecutarStoredProcedure();
                    gestor.desconectar();
                }
            }
            formConfirmarFacturacion.Dispose();
        }

    }
}
