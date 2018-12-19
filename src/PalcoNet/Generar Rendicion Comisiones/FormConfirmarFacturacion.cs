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

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class FormConfirmarFacturacion : Form
    {
        string query;

        public FormConfirmarFacturacion(string query)
        {
            InitializeComponent();
            this.query = query;
        }

        private void FormConfirmarFacturacion_Load(object sender, EventArgs e)
        {
            lsvItemsFactura.View = View.Details;
            lsvItemsFactura.Columns.Add("EMPRESA");
            lsvItemsFactura.Columns.Add("MONTO");
            lsvItemsFactura.Columns.Add("COMISION");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                ListViewItem item_factura = new ListViewItem(lector["razon_social"].ToString());
                item_factura.SubItems.Add(lector["monto_total"].ToString());
                item_factura.SubItems.Add(lector["comision_total"].ToString());
                lsvItemsFactura.Items.Add(item_factura);
            }
            lsvItemsFactura.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            gestor.desconectar();
        }

    }
}
