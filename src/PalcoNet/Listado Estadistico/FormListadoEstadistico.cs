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

namespace PalcoNet.Listado_Estadistico
{
    public partial class FormListadoEstadistico : Form
    {
        int userID;
        int rolID;

        public FormListadoEstadistico(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        // Metodos auxiliares

        private void mostrarResultados(string query, Queue<string> headers)
        {
            lsvConsulta.Clear();
            lsvConsulta.View = View.Details;

            while (headers.Count > 0)
            {
                string header = headers.Dequeue();
                lsvConsulta.Columns.Add(header);
            }

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                ListViewItem item = new ListViewItem(lector[lsvConsulta.Columns[0].Text].ToString());
                for (int i = 1; i < lsvConsulta.Columns.Count; i++)
                {
                    item.SubItems.Add(lector[lsvConsulta.Columns[i].Text].ToString());
                }
                lsvConsulta.Items.Add(item);
            }

            for (int i = 0; i < lsvConsulta.Columns.Count; i++)
            {
                lsvConsulta.Columns[i].Text = lsvConsulta.Columns[i].Text.ToUpper().Replace('_', ' ');
            }

            lsvConsulta.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        // -------------------

        private void FormListado_Load(object sender, EventArgs e)
        {
            GeneradorDeFechas generador = new GeneradorDeFechas();
            generador.completarAno(cmbAno, true);
            generador.completarTrimestre(cmbTrimestre);
            cmbConsulta.Items.Add("EMPRESAS CON MAYOR CANTIDAD DE LOCALIDADES NO VENDIDAS");
            cmbConsulta.Items.Add("CLIENTES CON MAYORES PUNTOS VENCIDOS");
            cmbConsulta.Items.Add("CLIENTES CON MAYOR CANTIDAD DE COMPRAS");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string consulta = cmbConsulta.Text;
            string ano = cmbAno.Text;
            string trimestre = cmbTrimestre.Text;
            bool error = false;
            string mensaje = "Faltaron completar los siguientes campos:";

            if (consulta == "")
            {
                error = true;
                mensaje += "\n- Tipo de consulta";
            }
            if (ano == "")
            {
                error = true;
                mensaje += "\n- Año";
            }
            if (trimestre == "")
            {
                error = true;
                mensaje += "\n- Trimestre";
            }
            if (error)
            {
                MessageBox.Show(mensaje, "ALERTA");
            }
            else
            {
                string query;
                Queue<string> headers = new Queue<string>();
                int desdeMes = 0;
                int hastaMes = 0;

                switch (Convert.ToInt32(trimestre))
                {
                    case 1:
                        desdeMes = 1;
                        hastaMes = 3;
                        break;
                    case 2:
                        desdeMes = 4;
                        hastaMes = 6;
                        break;
                    case 3:
                        desdeMes = 7;
                        hastaMes = 9;
                        break;
                    case 4:
                        desdeMes = 10;
                        hastaMes = 12;
                        break;
                }

                switch (consulta)
                {
                    case "EMPRESAS CON MAYOR CANTIDAD DE LOCALIDADES NO VENDIDAS":
                        // TODO: query
                        query =
                            "SELECT TOP 5 E.razon_social, COUNT(id_ubicacion) AS no_vendidas " +
                            "FROM PEAKY_BLINDERS.empresas E " +
                                "JOIN PEAKY_BLINDERS.publicaciones PU ON E.id_empresa = PU.id_empresa " +
                                "JOIN PEAKY_BLINDERS.presentaciones PR ON PU.id_publicacion = PR.id_publicacion " +
                                "JOIN PEAKY_BLINDERS.ubicaciones U ON PU.id_publicacion = U.id_publicacion " +
                            "WHERE U.id_ubicacion NOT IN (SELECT C.id_ubicacion FROM PEAKY_BLINDERS.compras C) " +
                                "AND YEAR(PR.fecha_vencimiento) = '" + ano + "' " +
                                "AND MONTH(PR.fecha_vencimiento) BETWEEN '" + desdeMes + "' AND '" + hastaMes + "' " +
                            "GROUP BY E.razon_social " +
                            "ORDER BY no_vendidas DESC";
                        headers.Enqueue("razon_social");
                        headers.Enqueue("no_vendidas");
                        this.mostrarResultados(query, headers);
                        break;
                    case "CLIENTES CON MAYORES PUNTOS VENCIDOS":
                        // TODO: query
                        query = "";
                        this.mostrarResultados(query, headers);
                        break;
                    case "CLIENTES CON MAYOR CANTIDAD DE COMPRAS":
                        query =
                            "SELECT TOP 5 CL.nombre, CL.apellido, ISNULL(CL.cuil, ---), COUNT(CO.id_compra) AS compras " +
                            "FROM PEAKY_BLINDERS.clientes CL " +
                                "JOIN PEAKY_BLINDERS.compras CO ON CL.id_cliente = CO.id_cliente " +
                            "WHERE YEAR(CO.fecha) = '" + ano + "' " +
                                "AND MONTH(CO.fecha) BETWEEN '" + desdeMes + "' AND '" + hastaMes + "' " +
                            "GROUP BY CL.nombre, CL.apellido, CL.cuil " +
                            "ORDER BY compras DESC";
                        headers.Enqueue("nombre");
                        headers.Enqueue("apellido");
                        headers.Enqueue("cuil");
                        headers.Enqueue("compras");
                        this.mostrarResultados(query, headers);
                        break;
                }
            }            
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formDestino = new FormLogin();
            this.Hide();
            formDestino.Show();
        }

    }
}
