using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKho.Dao
{
    public class HangHoa_dal
    {

        #region Hàng Hóa
        public static DataTable Select()
        {
            return KetNoi.GetList("xem_hanghoa", null);
        }
        public static DataTable Search(string mahang,string tenhang)
        {
            SqlParameter[] para = new SqlParameter[]
                { new SqlParameter("@mahang", mahang),
                   new SqlParameter("@tenhang", tenhang)

                 };
            return KetNoi.GetList("timkiem_hanghoa", para);
        }

        public static int Insert(HangHoa_obj hh)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mahang",hh.mahang),
                new SqlParameter("@tenhang",hh.tenhang),
                new SqlParameter("@tinhtrang",hh.tinhtrang),
                new SqlParameter("@dongia",hh.dongia),
                new SqlParameter("@makho",hh.makho),
                new SqlParameter("@maloaihang",hh.maloaihang)
            };
            return KetNoi.Execute("them_hanghoa", para);
        }

        public static int Update(HangHoa_obj hh)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mahang",hh.mahang),
                new SqlParameter("@tenhang",hh.tenhang),
                new SqlParameter("@tinhtrang",hh.tinhtrang),
                new SqlParameter("@dongia",hh.dongia),
                new SqlParameter("@makho",hh.makho),
                new SqlParameter("@maloaihang",hh.maloaihang)
            };
            return KetNoi.Execute("sua_hanghoa", para);
        }

        public static int Delete(string id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mahang",id)
            };
            return KetNoi.Execute("xoa_hanghoa", para);
        }
        #endregion

    }
}
