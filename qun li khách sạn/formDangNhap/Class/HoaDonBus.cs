using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace formDangNhap.Class
{
    class HoaDonBus
    {
        public Connection doIt = null;
        public void close()
        {
            if (doIt == null) return;
            if (doIt.isOpen() < 0) return;
            doIt.close();
        }
        public int update(HoaDonObj gv)
        {
            int ret = 0;
            string sql = @"update btlHoaDon set MaHD=@MaHD,MaKh=@MaKH,NguoiLap=@NguoiLap,TongTien=@TongTien,TGMuon=@TGMuon,TGTra=@TGTra where MaHD=@MaHD";
            List<SqlParameter> li = new List<SqlParameter>();
            SqlParameter a;
            a = new SqlParameter("MaHD", SqlDbType.VarChar);
            a.Value = gv.MAHD;
            li.Add(a);
            a = new SqlParameter("ten", SqlDbType.NVarChar);
            a.Value = gv.MAKH;
            li.Add(a);
            a = new SqlParameter("ngaysinh", SqlDbType.Date);
            a.Value = gv.NGUOILAP;
            li.Add(a);
            a = new SqlParameter("gioitinh", SqlDbType.Bit);
            a.Value = gv.TONGTIEN;
            li.Add(a);
            a = new SqlParameter("email", SqlDbType.VarChar);
            a.Value = gv.TGMUON;
            li.Add(a);
            a = new SqlParameter("dienthoai", SqlDbType.VarChar);
            a.Value = gv.TGTRA;
            li.Add(a);
            if (doIt == null)
                doIt = new Connection();
            if (doIt.isOpen() < 0) ret = doIt.connect();
            if (ret < 0) return -2;
            ret = doIt.doSql(sql, li.ToArray());
            return ret;
        }
        public int insert(HoaDonObj dk)
        {
            int ret = 0;
            string sql = @"insert into HoaDon(MaHD,MaKH,NguoiLap,TongTien,THMuon,TGTra) 
                         values(@MaHD,@MaKH,@NguoiLap,@TongTien,@TGMuon,@TGTra)";

            List<SqlParameter> li = new List<SqlParameter>();
            SqlParameter a;
            a = new SqlParameter("MaHD", SqlDbType.NVarChar);
            a.Value = dk.MAHD;
            li.Add(a);
            a = new SqlParameter("MaKH", SqlDbType.NVarChar);
            a.Value = dk.MAKH;
            li.Add(a);
            a = new SqlParameter("NguoiLap", SqlDbType.NVarChar);
            a.Value = dk.NGUOILAP;
            li.Add(a);
            a = new SqlParameter("TongTien", SqlDbType.BigInt);
            a.Value = dk.TONGTIEN;
            li.Add(a);
            a = new SqlParameter("TGMuon", SqlDbType.DateTime);
            a.Value = dk.TGMUON;
            li.Add(a);
            a = new SqlParameter("TGTra", SqlDbType.DateTime);
            a.Value = dk.TGTRA;
            li.Add(a);


            if (doIt == null)
                doIt = new Connection();
            if (doIt.isOpen() < 0) ret = doIt.connect();
            if (ret < 0) return -2;
            if (ret >= 0)
            {
                ret = doIt.doSql(sql, li.ToArray());
            }
            return ret;
        }
    }
}
