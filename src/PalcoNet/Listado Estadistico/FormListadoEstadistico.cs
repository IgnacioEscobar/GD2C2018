using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            bool error = false;
            string mensaje = "Faltaron completar los siguientes campos:";

            if (cmbConsulta.Text == "")
            {
                error = true;
                mensaje += "\n- Tipo de consulta";
            }
            if (cmbAno.Text == "")
            {
                error = true;
                mensaje += "\n- Año";
            }
            if (cmbTrimestre.Text == "")
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
                switch (cmbConsulta.Text)
                {
                    case "EMPRESAS CON MAYOR CANTIDAD DE LOCALIDADES NO VENDIDAS":
                        // TODO: query
                        break;
                    case "CLIENTES CON MAYORES PUNTOS VENCIDOS":
                        // TODO: query
                        break;
                    case "CLIENTES CON MAYOR CANTIDAD DE COMPRAS":
                        // TODO: query
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
