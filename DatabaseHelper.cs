using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmNhapHang
{

    internal class DatabaseHelper
    {
        private static SqlConnection conn = new SqlConnection("Data Source= DESKTOP-42OU7AB;Initial Catalog=QuanLyCuaHangQuanAo;Integrated Security=True");

        public static void Connect()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public static void Disconnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public static SqlConnection GetConnection()
        {
            return conn;
        }
    }
}
        