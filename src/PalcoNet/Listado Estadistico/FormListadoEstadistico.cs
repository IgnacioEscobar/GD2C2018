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
            this.ocultarMesGrado();
            this.cargarGrados();
        }

        private void cargarGrados()
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query_grados = "select descripcion from PEAKY_BLINDERS.grados";
            gestor.consulta(query_grados);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                comboGrado.Items.Add(lector["descripcion"].ToString());
            }
            gestor.desconectar();
        }

        private void ocultarMesGrado()
        {
            labelMes.Visible = false;
            labelGrado.Visible = false;
            comboMes.Visible = false;
            comboGrado.Visible = false;
        }

        private void mostrarMesGrado()
        {
            labelMes.Visible = true;
            labelGrado.Visible = true;
            comboMes.Visible = true;
            comboGrado.Visible = true;
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

                        string queryMesExacto = "";
                        string queryGrado = "";

                        if(comboGrado.Text != "") {
                            queryGrado = "and G.descripcion = '" + comboGrado.Text + "' ";
                        }

                        if(comboMes.Text != "") {
                            queryMesExacto = " AND MONTH(PR.fecha_vencimiento) = '" + comboMes.Text + "' ";
                        }


                        query =
                            "SELECT TOP 5 E.razon_social, COUNT(U.id_ubicacion) AS no_vendidas " +
                            "FROM PEAKY_BLINDERS.empresas E " +
                                "JOIN PEAKY_BLINDERS.publicaciones PU ON E.id_empresa = PU.id_empresa " +
                                "JOIN PEAKY_BLINDERS.presentaciones PR ON PU.id_publicacion = PR.id_publicacion " +
                                "JOIN PEAKY_BLINDERS.ubicaciones U ON PU.id_publicacion = U.id_publicacion " +
                                "join PEAKY_BLINDERS.grados G on PU.id_grado = G.id_grado " + queryGrado + " " +
                            "WHERE U.id_ubicacion NOT IN (SELECT C.id_ubicacion FROM PEAKY_BLINDERS.compras C) " +
                                "AND YEAR(PR.fecha_vencimiento) = '" + ano + "' " +
                                "AND MONTH(PR.fecha_vencimiento) BETWEEN '" + desdeMes + "' AND '" + hastaMes + "' " +
                                queryMesExacto + " " +
                            "GROUP BY E.razon_social, G.multiplicador " +
                            "ORDER BY G.multiplicador desc";
                        headers.Enqueue("razon_social");
                        headers.Enqueue("no_vendidas");
                        this.mostrarResultados(query, headers);
                        break;
                    case "CLIENTES CON MAYORES PUNTOS VENCIDOS":
                        query =
                            "SELECT TOP 5 CL.nombre, CL.apellido, ISNULL(CL.cuil, '---') AS cuil, COUNT(MP.id_movimiento) AS puntos " +
                            "FROM PEAKY_BLINDERS.clientes CL " +
                                "JOIN PEAKY_BLINDERS.movimientos_de_puntos MP ON CL.id_cliente = MP.id_cliente " +
                            "WHERE MP.fecha_vencimiento < GETDATE() " +
                                "AND YEAR(MP.fecha_vencimiento) = '" + ano + "' " +
                                "AND MONTH(MP.fecha_vencimiento) BETWEEN '" + desdeMes + "' AND '" + hastaMes + "' " +
                            "GROUP BY CL.nombre, CL.apellido, CL.cuil " +
                            "ORDER BY puntos DESC";
                        headers.Enqueue("nombre");
                        headers.Enqueue("apellido");
                        headers.Enqueue("cuil");
                        headers.Enqueue("puntos");
                        this.mostrarResultados(query, headers);
                        break;
                    case "CLIENTES CON MAYOR CANTIDAD DE COMPRAS":
                        query = "select CL.nombre as nombre, CL.apellido as apellido, count(C.id_compra) as compras, E.razon_social as 'razon social' from PEAKY_BLINDERS.compras C " +
                                "join PEAKY_BLINDERS.clientes CL on CL.id_cliente = C.id_cliente " +
                                "join PEAKY_BLINDERS.publicaciones P on C.id_publicacion = P.id_publicacion " +
                                "join PEAKY_BLINDERS.empresas E on P.id_empresa = E.id_empresa " +
                                "where MONTH(C.fecha) BETWEEN '" + desdeMes + "' AND '" + hastaMes + "' " + " and YEAR(C.fecha) = '" + ano + "' and " +
                                    "C.id_cliente in (select top 5 CL.id_cliente from PEAKY_BLINDERS.compras C " +
                                                     "join PEAKY_BLINDERS.clientes CL on CL.id_cliente = C.id_cliente " +
                                                     "group by CL.id_cliente order by count(C.id_compra) desc)" +
                               "group by CL.nombre, CL.apellido, C.id_cliente, E.razon_social " +
                               "order by CL.nombre, (select count(C.id_compra) from PEAKY_BLINDERS.compras C1 where C1.id_cliente =  C.id_cliente group by C1.id_cliente) desc";
                        headers.Enqueue("nombre");
                        headers.Enqueue("apellido");
                        headers.Enqueue("compras");
                        headers.Enqueue("razon social");
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta = cmbConsulta.Text;

            if (consulta == "EMPRESAS CON MAYOR CANTIDAD DE LOCALIDADES NO VENDIDAS")
            {
                this.mostrarMesGrado();
            }
            else { this.ocultarMesGrado(); }
        }

    }
}
