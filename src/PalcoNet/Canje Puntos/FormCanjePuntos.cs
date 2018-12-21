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

namespace PalcoNet.Canje_Puntos
{
    public partial class FormCanjePuntos : Form
    {
        int userID;
        int rolID;
        int puntos_disponibles;

        public FormCanjePuntos(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        // Metodos auxiliares

        private void mostrarCanjeados()
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(
                "SELECT TP.descripcion, COUNT(*) AS cantidad " +
                "FROM PEAKY_BLINDERS.premios P " +
                    "JOIN PEAKY_BLINDERS.tipos_de_premios TP ON P.id_tipo_de_premio = TP.id_tipo_de_premio " +
                    "JOIN PEAKY_BLINDERS.clientes C ON P.id_cliente = C.id_cliente " +
                "WHERE C.id_usuario = '" + userID + "' AND P.usado = 0 " +
                "GROUP BY TP.descripcion " +
                "ORDER BY TP.descripcion ASC");
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                ListViewItem item = new ListViewItem(lector["descripcion"].ToString());
                item.SubItems.Add(lector["cantidad"].ToString());
                lsvPremiosCanjeados.Items.Add(item);
            }
            lsvPremiosCanjeados.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void mostrarPuntosDisponibles()
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT PEAKY_BLINDERS.obtener_puntos(" + userID + ", " + Config.dateTime.ToString("yyyy-MM-dd") + ") AS puntos");
            SqlDataReader lector = gestor.obtenerRegistros();
            if (lector.Read())
            {
                puntos_disponibles = Convert.ToInt32(lector["puntos"]);
                lblPuntosDisponibles.Text = "PUNTOS DISPONIBLES: " + puntos_disponibles.ToString();
            }
            gestor.desconectar();
        }

        // -------------------

        private void FormCanjePuntos_Load(object sender, EventArgs e)
        {
            mostrarPuntosDisponibles();

            lsvPremiosDisponibles.View = View.Details;
            lsvPremiosDisponibles.Columns.Add("DESCRIPCIÓN");
            lsvPremiosDisponibles.Columns.Add("PUNTOS");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT descripcion, puntos FROM PEAKY_BLINDERS.tipos_de_premios");
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                ListViewItem item = new ListViewItem(lector["descripcion"].ToString());
                item.SubItems.Add(lector["puntos"].ToString());
                lsvPremiosDisponibles.Items.Add(item);
            }
            lsvPremiosDisponibles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lsvPremiosCanjeados.View = View.Details;
            lsvPremiosCanjeados.Columns.Add("DESCRIPCIÓN");
            lsvPremiosCanjeados.Columns.Add("CANTIDAD");
            this.mostrarCanjeados();
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (lsvPremiosDisponibles.SelectedItems.Count == 1)
            {
                string premio_seleccionado = lsvPremiosDisponibles.SelectedItems[0].SubItems[0].Text;
                int puntos_requeridos = Convert.ToInt32(lsvPremiosDisponibles.SelectedItems[0].SubItems[1].Text);

                if (puntos_requeridos > puntos_disponibles)
                {
                    MessageBox.Show("No tiene la cantidad necesaria de puntos acumulados.", "Alerta");
                }
                else
                {
                    string mensaje = "¿Confirma que desea canjear " + puntos_requeridos + " puntos por " + premio_seleccionado + "?";
                    DialogResult result = MessageBox.Show(mensaje, "Confirmar canje", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        GestorDB gestor = new GestorDB();
                        gestor.conectar();
                        gestor.generarStoredProcedure("canjear_premio");
                        gestor.parametroPorValor("id_usuario", userID);
                        gestor.parametroPorValor("descripcion", premio_seleccionado);
                        gestor.parametroPorValor("puntos", puntos_requeridos);
                        gestor.parametroPorValor("fecha", Config.dateTime);
                        gestor.ejecutarStoredProcedure();
                        gestor.desconectar();

                        mostrarPuntosDisponibles();
                        lsvPremiosCanjeados.Items.Clear();
                        mostrarCanjeados();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar algún premio.", "Alerta");
            }
        }

    }
}
