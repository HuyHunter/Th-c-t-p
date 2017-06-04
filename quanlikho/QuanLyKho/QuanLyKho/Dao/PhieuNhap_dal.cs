using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKho.Dao
{
    public class PhieuNhap_dal
    {

        #region Phiếu nhập
        public static DataTable Select()
        {
            return KetNoi.GetList("xem_phieunhap", null);
        }
       public static DataTable Search(string maphieu)
        {
            SqlParameter[] para = new SqlParameter[]
                { new SqlParameter("@maphieu", maphieu),
                  

                 };
            return KetNoi.GetList("timkiem_phieunhap", para);
        }

        public static int Insert(PhieuNhap_obj pn)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@maphieu",pn.maphieunhap),
                new SqlParameter("@makho",pn.makho),
                new SqlParameter("@mathukho",pn.mathukho),
                new SqlParameter("@nhacungcap",pn.manhacc),
                new SqlParameter("@ngaynhap",pn.ngaynhap)
               
            };
            return KetNoi.Execute("them_phieunhap", para);
        }

        public static int Update(PhieuNhap_obj pn)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@maphieu",pn.maphieunhap),
                new SqlParameter("@makho",pn.makho),
                new SqlParameter("@mathukho",pn.mathukho),
                new SqlParameter("@nhacungcap",pn.manhacc),
                new SqlParameter("@ngaynhap",pn.ngaynhap)
            };
            return KetNoi.Execute("sua_phieunhap", para);
        }

        public static int Delete(string id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@maphieu",id)
            };
            return KetNoi.Execute("xoa_phieunhap", para);
        }
        #endregion

    }
}
