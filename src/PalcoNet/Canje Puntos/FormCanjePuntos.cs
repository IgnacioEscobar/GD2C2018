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

        public FormCanjePuntos(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        private void FormCanjePuntos_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT SUM(MP.variacion) AS puntos FROM PEAKY_BLINDERS.movimiento_de_puntos MP " +
                "JOIN PEAKY_BLINDERS.clientes C ON MP.id_cliente = C.id_cliente " +
                "WHERE C.id_usuario = '" + userID + "' AND MP.fecha >= GETDATE()");
            SqlDataReader lector = gestor.obtenerRegistros();
            if (lector.Read())
            {
                lblPuntosDisponibles.Text = "PUNTOS DISPONIBLES " + lector["puntos"].ToString();
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
