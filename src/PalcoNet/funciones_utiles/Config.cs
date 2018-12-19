using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.funciones_utiles
{
    public static class Config
    {
        public static string connectionString;
        public static string date;
        public static DateTime dateTime;

        public static void initialize() {
            connectionString = ConfigurationManager.AppSettings["database"].ToString();
            try{
                date = ConfigurationManager.AppSettings["date"].ToString();
                dateTime = DateTime.Parse(date);
            }catch(System.TypeInitializationException){
                date = "GETDATE()";
                dateTime = DateTime.Now;
            }
        }
    }
}
