using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.funciones_utiles
{
    class ValidadorDeDatos
    {
        public void texto(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void numero(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void alfanumerico(KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || char.IsSeparator(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public bool validar_CUIL_CUIT(string numero_ingresado)
        {
            //Controlamos si son 11 números los que quedaron, si no es el caso, ya devuelve falso
            if (numero_ingresado.Length != 11)
            {
                return false;
            }
            //Inicializamos una matriz por la cual se multiplicarán cada uno de los dígitos
            int[] serie = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            //Creamos una variable auxiliar donde guardaremos los resultados del cálculo del número validador
            int aux = 0;
            //Recorremos las matrices de forma simultanea, sumando los productos de la serie por el número en la misma posición
            for (int i = 0; i < 10; i++)
            {
                aux += Convert.ToInt32(numero_ingresado[i].ToString()) * serie[i];
            }
            //Hacemos como se especifica: 11 menos el resto de de la división de la suma de productos anterior por 11
            aux = 11 - (aux % 11);
            //Si el resultado anterior es 11 el código es 0
            if (aux == 11)
            {
                aux = 0;
            }
            //Si el resultado anterior es 10 el código no tiene que validar, cosa que de todas formas pasa
            //en la siguiente comparación.
            //Devuelve verdadero si son iguales, falso si no lo son
            return (Convert.ToInt32(numero_ingresado[10].ToString()) == aux);
        }

        public bool validar_campos_obligatorios(List<string[]> lista, ref string mensaje)
        {
            bool completo = true;
            mensaje = "Faltaron completar los siguientes campos:";
            foreach (string[] item in lista)
            {
                if (item[0] == "")
                {
                    completo = false;
                    mensaje += "\n - " + item[1];
                }
            }
            if (completo)
            {
                mensaje = "";
            }
            return completo;
        }

        public string atraparValorCombo(ComboBox cmb)
        {
            foreach (object item in cmb.Items)
            {
                if (item.ToString() == cmb.Text)
                {
                    return cmb.Text;
                }
            }
            return "";
        }

    }
}
