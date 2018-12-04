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

namespace PalcoNet.Listado_Estadistico
{
    public partial class FormListadoEstadistico : Form
    {
        public FormListadoEstadistico()
        {
            InitializeComponent();
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
    }
}
