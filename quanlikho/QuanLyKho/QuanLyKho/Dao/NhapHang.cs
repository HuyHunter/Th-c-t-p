using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyKho.Bus;

namespace QuanLyKho.Dao
{
   public class NhapHang
    {
        public static DataTable Select()
        {
            return KetNoi.GetList("xem_nhaphang", null);
        }
        public static DataTable SelectHH()
        {
            return KetNoi.GetList("chon_hanghoa", null);
        }
      /*  public static DataTable Search(string mahang, string tenhang)
        {
            SqlParameter[] para = new SqlParameter[]
                { new SqlParameter("@mahang", mahang),
                   new SqlParameter("@tenhang", tenhang)

                 };
            return KetNoi.GetList("timkiem_hanghoa", para);
        }*/

        public static int Insert(ChiTietPhieuNhap_obj ct)
        {
            SqlParameter[] para = new SqlParameter[]
            {
              
                new SqlParameter("@mahang",ct.mahang),
                new SqlParameter("@maphieu",ct.maphieu)
                
            };
            return KetNoi.Execute("them_nhaphang", para);
        }

        public static int Update(ChiTietPhieuNhap_obj ct)
        {
            SqlParameter[] para = new SqlParameter[]
            {
               
                new SqlParameter("@mahang",ct.mahang),
                new SqlParameter("@maphieu",ct.maphieu)
            };
            return KetNoi.Execute("sua_nhaphang", para);
        }

        public static int Delete(string id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@maphieu",id)
            };
            return KetNoi.Execute("xoa_nhaphang", para);
        }
    }
}
