using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;


namespace TieBaManage
{
    public class DBHelper
    {
        public static string connStr = ConfigurationManager.AppSettings["strCon"];

        public static DataTable Select(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                DataTable dt = new DataTable();
                conn.Open();
                SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
                dap.Fill(dt);
                return dt;
            }
        }

        public static int Update(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }

            }
        }
    }
}