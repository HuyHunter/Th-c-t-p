using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyKho.Dao;
namespace QuanLyKho.Bus
{
    public class BusData
    {
        #region Hang Hoa
        public static DataTable HH_select()
        {
            return HangHoa_dal.Select();
        }

        public static DataTable HH_search(string mahang,string tenhang)
        {
            return HangHoa_dal.Search(mahang,tenhang);
        }

        
        public static int HH_insert(HangHoa_obj hh)
        {
            return HangHoa_dal.Insert(hh);
        }

        public static int HH_update(HangHoa_obj hh)
        {
            return HangHoa_dal.Update(hh);
        }

        public static int HH_delete(string id)
        {
            return HangHoa_dal.Delete(id);
        }
        #endregion

        #region Kho Hang
        public static DataTable KH_select()
        {
            return KhoHang_dal.Select();
        }
        #endregion
        #region Loai Hang Hoa
        public static DataTable LHH_select()
        {
            return LoaiHangHoa_dal.Select();
        }
        #endregion

        public static DataTable NCC_select()
        {
            return NhaCungCap_dal.Select();
        }
        
        public static DataTable TK_select()
        {
            return ThuKho_dal.Select();
        }
        #region Phiếu nhập

        public static DataTable PN_select()
        {
            return PhieuNhap_dal.Select();
        }

        public static DataTable PN_search(string maphieu)
        {
            return PhieuNhap_dal.Search(maphieu);
        }


        public static int PN_insert(PhieuNhap_obj pn)
        {
            return PhieuNhap_dal.Insert(pn);
        }

        public static int PN_update(PhieuNhap_obj pn)
        {
            return PhieuNhap_dal.Update(pn);
        }

        public static int PN_delete(string id)
        {
            return PhieuNhap_dal.Delete(id);
        }
        #endregion

        #region nhap hang
        public static DataTable NH_select()
        {
            return NhapHang.Select();
        }
        public static DataTable CHH_select()
        {
            return NhapHang.SelectHH();
        }
        public static int  NH_insert(ChiTietPhieuNhap_obj ct)
        { 
            return NhapHang.Insert(ct);
        }
        public static int NH_update(ChiTietPhieuNhap_obj ct)
        {
            return NhapHang.Update(ct);
        }
        public static int NH_delete(string id)
        {
            return NhapHang.Delete(id);
        }

       #endregion
    }
}
