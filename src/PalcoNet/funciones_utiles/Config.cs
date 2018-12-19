using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.funciones_utiles
{
    public static class Config
    {
        public static string connectionString = ConfigurationManager.AppSettings["database"].ToString();
        public static string date = ConfigurationManager.AppSettings["date"].ToString();
    }
}
