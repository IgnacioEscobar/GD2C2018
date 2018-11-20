using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using PalcoNet.Login;

namespace PalcoNet.funciones_utiles
{
    class GestorDB
    {
        SqlConnection conexion;
        SqlCommand query;

        public void conectar()
        {
            conexion = new SqlConnection(@"Data source=localhost\SQLSERVER2012; Initial Catalog=GD2C2018;user=gdEspectaculos2018;password=gd2018");
        }

        public void storedProcedure(string procedure)
        {
            query = new SqlCommand("PEAKY_BLINDERS." + procedure, conexion);
            query.CommandType = CommandType.StoredProcedure;
        }

        public void parametroPorValor(string nombre, object valor)
        {
            query.Parameters.AddWithValue(nombre, valor);
        }

        public void parametroPorReferencia(string nombre, SqlDbType tipoDato)
        {
            query.Parameters.Add(new SqlParameter(nombre, tipoDato));
            query.Parameters[nombre].Direction = ParameterDirection.Output;
        }

        public int ejecutarStoredProcedure()
        {
            try
            {
                query.Parameters.Add("@ReturnVal", SqlDbType.Int);
                query.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;
                conexion.Open();
                query.ExecuteNonQuery();
                conexion.Close();
                return Convert.ToInt32(query.Parameters["@ReturnVal"].Value);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public object obtenerValor(string nombre)
        {
            return query.Parameters[nombre].Value;
        }
    }
}
