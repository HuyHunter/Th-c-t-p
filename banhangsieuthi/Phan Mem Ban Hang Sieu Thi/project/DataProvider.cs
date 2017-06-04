using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace project
{
    class DataProvider
    {
        static string cnStr = @"Data Source=JOJO-PC\SQLEXPRESS;Initial Catalog=BANHANGSIEUTHI;Integrated Security=True";
        // tạo kết nối
        static SqlConnection cn;
        static public DataTable LoadCSDL(string sql)
        {
            DataTable dt = new DataTable(); //  tạo bảng
            cn = new SqlConnection(cnStr); // tạo kết nối
            SqlCommand cm = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt); // lấp đầy bảng
            return dt;
        }
        // insert, update, delete
        static public int change(string sql)
        {
            cn = new SqlConnection(cnStr);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cm = new SqlCommand(sql, cn);
            int kq = cm.ExecuteNonQuery();
            cn.Close();
            return kq;
        }
    }
}
