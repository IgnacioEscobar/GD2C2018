using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PalcoNet
{
    class SQL_Connector
    {
        public SqlConnection conection;

        public SQL_Connector()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
                conection = new SqlConnection(connectionString);
                conection.Open();
                Console.WriteLine("Conexión a la BD correcta");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Hubo un error al conectarse con la BD");
            }
        }
    }
}