using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.funciones_utiles
{
    class GeneradorDeFechas
    {
        public GeneradorDeFechas()
        {
        }

        public void completar (ComboBox cmbDia, ComboBox cmbMes, ComboBox cmbAno)
        {
            for (int i = 1; i <= 31; i++)
            {
                cmbDia.Items.Add(i);
            }

            cmbMes.Items.Add("Enero");
            cmbMes.Items.Add("Febrero");
            cmbMes.Items.Add("Marzo");
            cmbMes.Items.Add("Abril");
            cmbMes.Items.Add("Mayo");
            cmbMes.Items.Add("Junio");
            cmbMes.Items.Add("Julio");
            cmbMes.Items.Add("Agosto");
            cmbMes.Items.Add("Septiembre");
            cmbMes.Items.Add("Octubre");
            cmbMes.Items.Add("Noviembre");
            cmbMes.Items.Add("Diciembre");

            for (int i = DateTime.Today.Year; i >= 1900; i--)
            {
                cmbAno.Items.Add(i);
            }
        }

    }
}
