using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace PalcoNet
{
    class DB_Espectaculos
    {
        private static SqlConnection connection = new SQL_Connector().conection;
        private static SqlCommand cmd = new SqlCommand();
        private static SqlDataReader reader;

        public static void setCmd(String query)
        {
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
        }
        public static void mostrarEmpresas()
        {
            DB_Espectaculos.setCmd("select razon_social from empresas");
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetString(0));
                }
            }
            else
            {
                Console.WriteLine("No se encontraron filas");
            }
            reader.Close();
        }
    }
}