using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SMSApp.Common
{
    public static class DbActivity
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        }

        public static SqlConnection Open()
        {
            string connectionString = DbActivity.ConnectionString();
            SqlConnection Con = new SqlConnection();
            Con.Open();
            return Con;
        }

        public static void Close(SqlConnection con)
        {
            con.Dispose();
        }

        public static void ExecReader(this SqlConnection dao, SqlCommand cmd, Action<IDataReader> action)
        {
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
        }
    }
}
