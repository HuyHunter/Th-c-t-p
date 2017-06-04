using System.Data;
using System.Data.SqlClient;

namespace QuanLyKho.Dao
{
    class KetNoi
    {
        public static SqlConnection conn;

        public static SqlConnection Connect()
        {
            try
            {
                string sql = @"Data Source=JOJO-PC\SQLEXPRESS;Database=QuanLyKho;Integrated Security=True;";
                SqlConnection con = new SqlConnection(sql);
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                    con.Open();
                return con;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public static DataTable GetList(string proc, SqlParameter[] para)
        {
            try
            {
                conn = Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                return null;
            }
        }

        public static int Execute(string proc, SqlParameter[] para)
        {
            try
            {
                conn = Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);
                int res = cmd.ExecuteNonQuery();
                conn.Close();
                return res;
            }
            catch (SqlException)
            {
                return 0;
            }
        }
    }
}
