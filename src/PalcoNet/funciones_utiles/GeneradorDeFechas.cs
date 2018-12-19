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

        public void completarDia (ComboBox cmbDia)
        {
            for (int i = 1; i <= 31; i++)
            {
                cmbDia.Items.Add(i);
            }            
        }

        public void completarMes (ComboBox cmbMes, bool texto)
        {
            if (texto)
            {
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
            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    cmbMes.Items.Add(i);
                }
            }
        }

        public void completarTrimestre(ComboBox cmbTrimestre)
        {
            for (int i = 1; i <= 4; i++)
            {
                cmbTrimestre.Items.Add(i);
            }    
        }

        public void completarAno(ComboBox cmbAno, bool pasado)
        {
            int ano_actual = Config.dateTime.Year;
            if (pasado)
            {
                for (int i = ano_actual; i >= 1900; i--)
                {
                    cmbAno.Items.Add(i);
                }
            }
            else
            {
                for (int i = ano_actual; i <= ano_actual + 50; i++)
                {
                    cmbAno.Items.Add(i);
                }
            }
        }

    }
}
