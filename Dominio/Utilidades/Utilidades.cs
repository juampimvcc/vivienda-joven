using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Utilidades
{
    class Utilidades
    {

        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public static bool CerrarConexion(SqlConnection cn)
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
                return true;
            }
            return false;
        }

        public static bool AbrirConexion(SqlConnection cn)
        {
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
                return true;
            }
            return false;
        }

        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
