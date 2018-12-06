using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.funciones_utiles
{
    class GeneradorDeContrasenasAleatorias
    {
        public string generar(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }
    }
}
