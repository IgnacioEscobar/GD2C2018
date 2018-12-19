using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

using PalcoNet.Login;
using System.Configuration;

namespace PalcoNet.funciones_utiles
{
    class GestorDB
    {
        SqlConnection conexion;
        SqlCommand query;
        SqlDataReader registros;

        public void conectar()
        {
            conexion = new SqlConnection(Config.connectionString);
            conexion.Open();
        }

        public void desconectar()
        {
            conexion.Close();
        }

        public void consulta(string cadena)
        {
            SqlCommand comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();
        }

        public SqlDataReader obtenerRegistros()
        {
            return registros;
        }

        public void generarStoredProcedure(string procedure)
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
                query.ExecuteNonQuery();
                return Convert.ToInt32(query.Parameters["@ReturnVal"].Value);

            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EN DB: " + e.ToString());
                return -1;
            }
        }

        public object obtenerValor(string nombre)
        {
            return query.Parameters[nombre].Value;
        }
    }
}
